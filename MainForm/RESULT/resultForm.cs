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

            dataGridViewResult.DataSource = result.getResult();

            #region Code nháp theo bài mẫu của thầy
            //string query = "SELECT DISTINCT dbo.std.id, fname, lname " +
            //    "FROM dbo.Score INNER JOIN dbo.std ON dbo.Score.student_id = std.id" +
            //    " INNER JOIN dbo.Course ON dbo.Course.id = dbo.Score.course_id " +
            //    "ORDER BY dbo.std.id";

            //DataTable tableGrid = score.getData(new SqlCommand(query));

            //string query2 = "SELECT student_id, label, student_score " +
            //    "FROM Course INNER JOIN dbo.Score ON dbo.Course.id = dbo.Score.course_id " +
            //    "ORDER BY student_id";

            //DataTable table_score = score.getData(new SqlCommand(query2));

            //DataTable tableAddColumn = score.getData(new SqlCommand("SELECT label FROM Course"));

            //for(int i = 0; i < tableAddColumn.Rows.Count; i++)
            //{
            //    string colName = tableAddColumn.Rows[i][0].ToString();
            //    tableGrid.Columns.Add(colName, typeof(System.Double));
            //}

            

            //for (int i = 0; i < tableGrid.Rows.Count; i++)
            //{
            //    for (int j = 0; j < table_score.Rows.Count; j++)
            //    {
            //        string colName = table_score.Rows[j]["label"].ToString();
            //        if (tableGrid.Rows[i][0] == table_score.Rows[j][0])
            //        {
            //            tableGrid.Rows[i][colName] = table_score.Rows[j]["student_score"];
            //        }
            //    }
            //}
            //dataGridViewResult.DataSource = tableGrid;
            ////dataGridViewResult.Columns.Add("Result", "result");
            #endregion
        }

        void calculateScore()
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT id, fname, lname, avg(student_score) as avg_score" +
                "FROM std inner join score on std.id = score.student_id" +
                "WHERE CONCAT(id, fname, lname) LIKE '%" + textBoxSearch.Text + "%'" +
                "GROUP BY id, fname, lname";
            SqlCommand command = new SqlCommand();
            dataGridViewResult.DataSource = score.getData(command);
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
