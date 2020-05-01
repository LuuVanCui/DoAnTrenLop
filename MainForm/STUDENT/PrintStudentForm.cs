using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;

namespace MainForm
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void Print_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select *from std");
            fillGrid(command);
            // Điều kiện các radioButton chuyển trạng thái
            if (radioButtonNo.Checked)
            {
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridViewStudent.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridViewStudent.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp
            dataGridViewStudent.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridViewStudent.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewStudent.AllowUserToAddRows = false;
            dataGridViewStudent.Columns[0].HeaderText = "Student ID";
            dataGridViewStudent.Columns[1].HeaderText = "First Name";
            dataGridViewStudent.Columns[2].HeaderText = "Last Name";
            dataGridViewStudent.Columns[3].HeaderText = "BirthDate Student";
            dataGridViewStudent.Columns[4].HeaderText = "Gender";
            dataGridViewStudent.Columns[5].HeaderText = "Phone";
            dataGridViewStudent.Columns[6].HeaderText = "Address";
            dataGridViewStudent.Columns[7].HeaderText = "Picture";
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select *from std");
            fillGrid(command);
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select *from std where gender='Male'");
            fillGrid(command);
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select *from std where gender='Female'");
            fillGrid(command);
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = true;
            dateTimePickerTo.Enabled = true;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = false;
            dateTimePickerTo.Enabled = false;
        }

        private void buttonSaveToTextFile_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\student_list.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                DateTime bdate;
                for (int i = 0; i < dataGridViewStudent.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewStudent.Columns.Count; j++)
                    {
                        if (j == 3)
                        {
                            bdate = Convert.ToDateTime(dataGridViewStudent.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                        }
                        else if (j == dataGridViewStudent.Columns.Count - 2)
                        {
                            writer.Write("\t" + dataGridViewStudent.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridViewStudent.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                writer.Close();
                MessageBox.Show("Saved File", "Save To Text File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonToPrinter_Click(object sender, EventArgs e)
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

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string query;
            if (radioButtonYes.Checked) // Neu theo Date
            {
                string dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd");
                string dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd");
                if (radioButtonMale.Checked)
                {
                    query = "SELECT *FROM std WHERE gender='Male' AND bdate BETWEEN '" + dateFrom + "' AND '" + dateTo + "'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "SELECT *FROM std WHERE gender='Female' AND bdate BETWEEN '" + dateFrom + "' AND '" + dateTo + "'";
                }
                else
                {
                    query = "SELECT *FROM std WHERE bdate BETWEEN '" + dateFrom + "' AND '" + dateTo + "'";
                }                
            }
            else // Neu khong theo Date
            {
                if (radioButtonMale.Checked)
                {
                    query = "SELECT *FROM std WHERE gender = 'Male'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "SELECT *FROM std WHERE gender='Female'";
                }
                else
                {
                    query = "SELECT *FROM std";
                }
            }
            command = new SqlCommand(query);
            fillGrid(command);
        }
    }
}
