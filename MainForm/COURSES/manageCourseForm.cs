using MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class manageCourseForm : Form
    {
        public manageCourseForm()
        {
            InitializeComponent();
        }

        COURSE1 course = new COURSE1();
        int pos;

        private void manageCourseForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }

        void reloadListBoxData()
        {
            listBoxCourses.DataSource = course.getAllCourse();
            listBoxCourses.ValueMember = "id";
            listBoxCourses.DisplayMember = "label";
            listBoxCourses.SelectedItem = null;
            labelTotalCourse.Text = "Total Courses: " + course.totalCourses();
        }

        private void listBoxCourses_Click(object sender, EventArgs e)
        {
            // Dùng DataRow view để xem từng dòng
            DataRowView dataRowView = (DataRowView)listBoxCourses.SelectedItem;
            pos = listBoxCourses.SelectedIndex;
            showData(pos);
        }

        void showData(int index)
        {
            try
            {
                DataRow dr = course.getAllCourse().Rows[index];
                listBoxCourses.SelectedIndex = index;
                textBoxID.Text = dr.ItemArray[0].ToString();
                textBoxLabel.Text = dr.ItemArray[1].ToString();
                numericUpDownHour.Value = int.Parse(dr.ItemArray[2].ToString());
                textBoxDes.Text = dr.ItemArray[3].ToString();
            }
            catch { }
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            showData(0);
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            showData(course.getAllCourse().Rows.Count - 1);
        }

        private void buttonPre_Click(object sender, EventArgs e)
        {
            if (pos > 0)
                pos -= 1;
            showData(pos);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pos < course.getAllCourse().Rows.Count - 1)
                pos += 1;
            showData(pos);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string courseName = textBoxLabel.Text;
                int hour = (int)numericUpDownHour.Value;
                string des = textBoxDes.Text;
                
                if (courseName.Trim() == "")
                {
                    MessageBox.Show("Add Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (course.checkCourseName(courseName))
                    {
                        if (course.insertCourse(id, courseName, hour, des))
                        {
                            MessageBox.Show("New course added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reloadListBoxData();
                        }
                        else
                        {
                            MessageBox.Show("The course not added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The course is already exist", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string name = textBoxLabel.Text;
                int period = (int)numericUpDownHour.Value;
                string description = textBoxDes.Text;

                // Neu trung ten
                if (!course.checkCourseName(name, id))
                {
                    MessageBox.Show("The course is already exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (course.updateCourse(id, name, period, description))
                {
                    MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadListBoxData();
                }
                else
                {
                    MessageBox.Show("Course not updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Do you want to delete the course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (course.deleteCourseById(id))
                    {
                        MessageBox.Show("Deleted Course", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showData(pos);
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("The Course is not already exist", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
