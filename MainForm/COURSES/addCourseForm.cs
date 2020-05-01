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
    public partial class addCourseForm : Form
    {
        public addCourseForm()
        {
            InitializeComponent();
        }

        COURSE1 course = new COURSE1();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxCourseID.Text);
                string courseName = textBoxLabel.Text;
                int period = Convert.ToInt32(textBoxPeriod.Text);
                string description = textBoxDescription.Text;
            
                if (courseName.Trim() == "")    
                {
                    MessageBox.Show("Add Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (course.checkCourseName(courseName))
                    {
                        if (course.insertCourse(id, courseName, period, description))
                        {
                            MessageBox.Show("New course added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
