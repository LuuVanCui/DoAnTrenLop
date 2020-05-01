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
            buttonShowScores.Click += ButtonShowScores_Click;
        }

        SCORE score = new SCORE();
        COURSE1 course = new COURSE1();
        STUDENT student = new STUDENT();
        bool removeStudent = true; // Nếu remove student = false thì bạn đang chọn remove SCore

        private void manageScoreForm_Load(object sender, EventArgs e)
        {
            showStudent();
            comboBoxSelectCourse.DataSource = course.getCourse(new SqlCommand("SELECT label FROM Course"));
            comboBoxSelectCourse.ValueMember = "label";
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
                int courseID = (int)comboBoxSelectCourse.SelectedValue;
                float scoreValue = float.Parse(textBoxScore.Text);
                string description = textBoxDescription.Text;

                if (!(score.studentScoreExist(studentID, courseID)))
                {
                    if (score.insertScore(studentID, courseID, scoreValue, description))
                    {
                        MessageBox.Show("Student Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
