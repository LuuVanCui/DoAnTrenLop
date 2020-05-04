using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MainForm
{
    public partial class contactFullListForm : Form
    {
        public contactFullListForm()
        {
            InitializeComponent();
            dataGridViewShowData.Click += DataGridViewShowData_Click;
        }

        private void DataGridViewShowData_Click(object sender, EventArgs e)
        {
            if (dataGridViewShowData.Rows.Count > 0)
            {
                textBoxFullAddress.Text = dataGridViewShowData.CurrentRow.Cells[5].Value.ToString();
                textBoxFullAddress.ReadOnly = true;
            }
            else
            {
                textBoxFullAddress.Text = null;
                textBoxFullAddress.ReadOnly = true;
            }
        }

        private void contactFullListForm_Load(object sender, EventArgs e)
        {
            dataGridViewShowData.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridViewShowData.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp

            CONTACT contact = new CONTACT();
            string query = "SELECT fname as 'First Name', lname as 'Last Name', " +
                "[group].name as 'Group', phone as 'Phone', email as 'Email', " +
                "address as 'Address', pic as 'Picture' " +
                "FROM mycontact INNER JOIN [group] on mycontact.group_id = [group].id " + 
                "WHERE mycontact.userid = @userid";

            dataGridViewShowData.DataSource = contact.getContactByUserId(new SqlCommand(query));
            picCol = (DataGridViewImageColumn)dataGridViewShowData.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewShowData.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridViewShowData.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridViewShowData.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }    
            }

            GROUP group = new GROUP();
            listBoxGroup.DataSource = group.getGroups(Globals.GlobalUserID);
            listBoxGroup.ValueMember = "id";
            listBoxGroup.DisplayMember = "name";

            listBoxGroup.SelectedItem = null;
            listBoxGroup.ClearSelected();

            DataGridViewShowData_Click(sender, e);
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void listBoxGroup_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                int groupid = (Int32)listBoxGroup.SelectedValue;
                string query = "SELECT fname as 'First Name', lname as 'Last Name', " +
                    "[group].name as 'Group', phone as 'Phone', email as 'Email', " +
                    "address as 'Address', pic as 'Picture' " +
                    "FROM mycontact INNER JOIN [group] on mycontact.group_id = [group].id " +
                    "WHERE mycontact.userid = @userid AND mycontact.group_id = @groupid";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserID;
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupid;
                dataGridViewShowData.DataSource = contact.getContact(command);

                for (int i = 0; i < dataGridViewShowData.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {
                        dataGridViewShowData.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                    }
                }

                DataGridViewShowData_Click(sender, e);
            }
            catch { }
            dataGridViewShowData.ClearSelection();
        }

        private void buttonExportExelFile_Click(object sender, EventArgs e)
        {
            // Tham khảo link: https://stackoverflow.com/questions/18182029/how-to-export-datagridview-data-instantly-to-excel-on-button-click

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Inventory_Adjustment_Export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format column D as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dataGridViewShowData.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void copyAlltoClipboard()
        {
            dataGridViewShowData.SelectAll();
            DataObject dataObj = dataGridViewShowData.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
    }
}