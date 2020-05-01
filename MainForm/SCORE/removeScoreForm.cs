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

namespace MainForm
{
    public partial class removeScoreForm : Form
    {
        public removeScoreForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();

        private void removeScoreForm_Load(object sender, EventArgs e)
        {
            fillGid();
        }

        void fillGid()
        {
            dataGridViewScore.ReadOnly = true;
            dataGridViewScore.DataSource = score.getStudentsScore();
            dataGridViewScore.Columns[0].HeaderText = "Student ID";
            dataGridViewScore.Columns[1].HeaderText = "First Name";
            dataGridViewScore.Columns[2].HeaderText = "Last Name";
            dataGridViewScore.Columns[3].HeaderText = "Course ID";
            dataGridViewScore.Columns[4].HeaderText = "Course Name";
            dataGridViewScore.Columns[5].HeaderText = "Score";
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete this score?", "Remove Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int sid = int.Parse(dataGridViewScore.CurrentRow.Cells[0].Value.ToString());
                    int cid = int.Parse(dataGridViewScore.CurrentRow.Cells[3].Value.ToString());
                    if (score.deleteScore(sid, cid))
                    {
                        MessageBox.Show("Score deleted.", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGid();
                    }
                    else
                    {
                        MessageBox.Show("Can not delete this score.", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
