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
using System.Drawing.Printing;

namespace MainForm
{
    public partial class resultForm : Form
    {
        public resultForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        SCORE score = new SCORE();

        private void resultForm_Load(object sender, EventArgs e)
        {
            RESULT result = new RESULT();
            dataGridViewResult.ReadOnly = true;
            string query = "SELECT id, fname, lname FROM std";
            dataGridViewResult.DataSource = result.getResult(query);
            dataGridViewResult_Click(sender, e);
            makeUpGid();
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

        private void dataGridViewResult_Click(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridViewResult.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewResult.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewResult.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RESULT result = new RESULT();
            string query = "SELECT id, fname, lname FROM std WHERE CONCAT(id, fname, lname) LIKE '%" + textBoxSearch.Text + "%'";
            dataGridViewResult.DataSource = result.getResult(query);
            makeUpGid();
        }

        void makeUpGid()
        {
            dataGridViewResult.Columns[0].HeaderText = "Student ID";
            dataGridViewResult.Columns[1].HeaderText = "First Name";
            dataGridViewResult.Columns[2].HeaderText = "Last Name";
        }
    }
}
