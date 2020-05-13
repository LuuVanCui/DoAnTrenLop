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
    public partial class manageScoreForm : Form
    {
        public manageScoreForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        COURSE1 course = new COURSE1();
        STUDENT student = new STUDENT();
        bool removeStudent = true; // Nếu remove student = false thì bạn đang chọn remove SCore

        private void manageScoreForm_Load(object sender, EventArgs e)
        {
            showStudent();
            comboBoxSelectCourse.DataSource = course.getCourse(new SqlCommand("SELECT * FROM Course"));
            comboBoxSelectCourse.ValueMember = "id";
            comboBoxSelectCourse.DisplayMember = "label";
        }

        void showStudent()
        {
            dataGridViewManageScore.DataSource = score.getData(new SqlCommand("SELECT id, fname, lname, bdate FROM std"));
            dataGridViewManageScore.Columns[0].HeaderText = "Student ID";
            dataGridViewManageScore.Columns[1].HeaderText = "First Name";
            dataGridViewManageScore.Columns[2].HeaderText = "Last Name";
            dataGridViewManageScore.Columns[3].HeaderText = "Birth Date";
            labelTableName.Text = "Student Table";
            labelTableName.ForeColor = Color.White;
        }

        void showScores()
        {
            dataGridViewManageScore.DataSource = score.getStudentsScore();
            dataGridViewManageScore.Columns[0].HeaderText = "Student ID";
            dataGridViewManageScore.Columns[1].HeaderText = "First Name";
            dataGridViewManageScore.Columns[2].HeaderText = "Last Name";
            dataGridViewManageScore.Columns[3].HeaderText = "Course ID";
            dataGridViewManageScore.Columns[4].HeaderText = "Course Name";
            dataGridViewManageScore.Columns[5].HeaderText = "Score";
            labelTableName.Text = "Score of Student Table";
            labelTableName.ForeColor = Color.Black;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = int.Parse(textBoxStudentID.Text);
                int courseID = Convert.ToInt32(comboBoxSelectCourse.SelectedValue);
                float scoreValue = float.Parse(textBoxScore.Text);
                string description = textBoxDescription.Text;

                if (!(score.studentScoreExist(studentID, courseID)))
                {
                    if (score.insertScore(studentID, courseID, scoreValue, description))
                    {
                        MessageBox.Show("Student Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showScores();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonShowStudents_Click(object sender, EventArgs e)
        {
            showStudent();
            removeStudent = true;
        }

        private void ButtonShowScores_Click(object sender, EventArgs e)
        {
            showScores();
            removeStudent = false;
        }
       
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (removeStudent == true) // Nếu là remove student 
                {
                    if (MessageBox.Show("Do you want to delete this student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int studentID = int.Parse(dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString());
                        if (student.deleteStudent(studentID))
                        {
                            MessageBox.Show("Deleted student.", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showStudent();
                        }
                        else
                        {
                            MessageBox.Show("Can not delete this student.", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else // Nếu là remove score
                {
                    if (MessageBox.Show("Do you want to delete this score?", "Remove Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int sid = int.Parse(dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString());
                        int cid = int.Parse(dataGridViewManageScore.CurrentRow.Cells[3].Value.ToString());
                        if (score.deleteScore(sid, cid))
                        {
                            MessageBox.Show("Score deleted.", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showScores();
                        }
                        else
                        {
                            MessageBox.Show("Can not delete this score.", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Scores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAvgScore_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm avgForm = new avgScoreByCourseForm();
            avgForm.ShowDialog(this);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = int.Parse(textBoxStudentID.Text);
                int courseID = Convert.ToInt32(comboBoxSelectCourse.SelectedValue);
                float scoreValue = float.Parse(textBoxScore.Text);
                string description = textBoxDescription.Text;

                if (score.editScore(studentID, courseID, scoreValue, description))
                {
                    MessageBox.Show("Student Score Updated", "Edit Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showScores();
                }
                else
                {
                    MessageBox.Show("Student Score Not Updated", "Edit Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewManageScore_Click(object sender, EventArgs e)
        {
            if (removeStudent == false)
            {
                int sid = Convert.ToInt32(dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString());
                int cid = Convert.ToInt32(dataGridViewManageScore.CurrentRow.Cells[3].Value.ToString());
                string query = "SELECT SCORE.student_id, COURSE.label, SCORE.student_score, SCORE.description " +
                "FROM std INNER JOIN Score on std.id = Score.student_id INNER JOIN Course on Course.id = Score.course_id " +
                "WHERE SCORE.student_id = " + sid + " AND Course.id =" + cid;
                DataTable table = score.getData(new SqlCommand(query));
                textBoxStudentID.Text = table.Rows[0][0].ToString();
                comboBoxSelectCourse.Text = table.Rows[0][1].ToString();
                textBoxScore.Text = table.Rows[0][2].ToString();
                textBoxDescription.Text = table.Rows[0][3].ToString();
            }
            else
            {
                textBoxStudentID.Text = dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString();
                comboBoxSelectCourse.DataSource = course.getCourse(new SqlCommand("SELECT * FROM Course"));
                comboBoxSelectCourse.ValueMember = "id";
                comboBoxSelectCourse.DisplayMember = "label";
                textBoxScore.Text = null;
                textBoxDescription.Text = null;
            }    
        }
    }
}
