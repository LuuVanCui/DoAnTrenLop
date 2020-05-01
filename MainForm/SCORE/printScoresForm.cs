﻿using System;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;

namespace MainForm
{
    public partial class printScoresForm : Form
    {
        public printScoresForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();


        private void buttonShowStudent_Click(object sender, EventArgs e)
        {
            showStudent();
        }

        void showStudent()
        {
            dataGridViewPrint.DataSource = score.getData(new SqlCommand("SELECT id, fname, lname, bdate FROM std"));
            dataGridViewPrint.Columns[0].HeaderText = "Student ID";
            dataGridViewPrint.Columns[1].HeaderText = "First Name";
            dataGridViewPrint.Columns[2].HeaderText = "Last Name";
            dataGridViewPrint.Columns[3].HeaderText = "Birth Date";
        }

        void showScores()
        {
            dataGridViewPrint.DataSource = score.getStudentsScore();
            dataGridViewPrint.Columns[0].HeaderText = "Student ID";
            dataGridViewPrint.Columns[1].HeaderText = "First Name";
            dataGridViewPrint.Columns[2].HeaderText = "Last Name";
            dataGridViewPrint.Columns[3].HeaderText = "Course ID";
            dataGridViewPrint.Columns[4].HeaderText = "Course Name";
            dataGridViewPrint.Columns[5].HeaderText = "Score";
        }

        private void buttonShowScores_Click(object sender, EventArgs e)
        {
            showScores();
        }

        private void buttonExport_Click(object sender, EventArgs e)
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
                dataGridViewPrint.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }
       
        private void copyAlltoClipboard()
        {
            dataGridViewPrint.SelectAll();
            DataObject dataObj = dataGridViewPrint.GetClipboardContent();
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

        private void printScoresForm_Load(object sender, EventArgs e)
        {
            showScores();
        }
    }
}
