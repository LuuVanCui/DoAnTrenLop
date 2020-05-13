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
    public partial class addScoreForm : Form
    {
        public addScoreForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        STUDENT student = new STUDENT();
        COURSE1 course = new COURSE1();
        int index;

        private void addScoreForm_Load(object sender, EventArgs e)
        {
            comboBoxCourse.DataSource = course.getAllCourse();
            comboBoxCourse.ValueMember = "id";
            comboBoxCourse.DisplayMember = "label";

            string commandText = "SELECT id, fname, lname FROM std";
            dataGridViewStudent.DataSource = student.getStudent(new SqlCommand(commandText));
            dataGridViewStudent.Columns[0].HeaderText = "Student ID";
            dataGridViewStudent.Columns[1].HeaderText = "First Name";
            dataGridViewStudent.Columns[2].HeaderText = "Last Name";
            dataGridViewStudent.ReadOnly = true;

            
            //textBoxStudentID.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            //int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue.ToString());
            //showData(index, courseID);
            
            if (textBoxScore.Text == "")
            {
                labelStatus.Text = "Status: No Score";
                labelStatus.ForeColor = Color.Red;
            }    
            else
            {
                labelStatus.Text = "Status: OK";
                labelStatus.ForeColor = Color.Blue;
            }    
        }

        private void buttonAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = int.Parse(textBoxStudentID.Text);
                int courseID = (int)comboBoxCourse.SelectedValue;
                float scoreValue = float.Parse(textBoxScore.Text);
                string description = textBoxDesciption.Text;

                if (!(score.studentScoreExist(studentID, courseID)))
                {
                    if (score.insertScore(studentID, courseID, scoreValue, description))
                    {
                        MessageBox.Show("Student Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelStatus.Text = "Status: OK";
                        labelStatus.ForeColor = Color.Blue;
                    }
                    else
                    {
                        MessageBox.Show("Student Score Not Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Score For This Course Are Already Set", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewStudent_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            index = dataGridViewStudent.CurrentRow.Index;
            int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue.ToString());
            showData(index, courseID);
        }

        void showData(int index, int courseID)
        {
            try
            {
                DataRow dr = score.getScoreByCourseID(new SqlCommand("SELECT *FROM Score WHERE course_id=@cid"), courseID).Rows[index];
                textBoxScore.Text = dr.ItemArray[2].ToString();
                textBoxDesciption.Text = dr.ItemArray[3].ToString();
            }
            catch // Nếu Row không tồn tại thì làm mới dữ liệu
            {
                textBoxScore.Text = "";
                textBoxDesciption.Text = "";
            }

            if (textBoxScore.Text == "")
            {
                labelStatus.Text = "Status: No Score";
                labelStatus.ForeColor = Color.Red;
            }
            else
            {
                labelStatus.Text = "Status: OK";
                labelStatus.ForeColor = Color.Blue;
            }
        }

        private void comboBoxCourse_DropDownClosed(object sender, EventArgs e)
        {
            int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue.ToString());
            showData(index, courseID);
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
