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
    public partial class editCourseForm : Form
    {
        public editCourseForm()
        {
            InitializeComponent();
        }

        COURSE1 course = new COURSE1();

        public void fillCombo(int index)
        {
            comboBoxCourseID.DataSource = course.getAllCourse();
            comboBoxCourseID.DisplayMember = "label";
            comboBoxCourseID.ValueMember = "id";
            comboBoxCourseID.SelectedItem = index;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBoxCourseID.SelectedValue);
            string name = textBoxCourseName.Text;
            int period = Convert.ToInt32(numericUpDownPeriod.Value);          
            string description = textBoxDescription.Text;

            // Neu trung ten
            if (!course.checkCourseName(name, id))
            {
                MessageBox.Show("The course is already exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (course.updateCourse(id, name, period, description))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillCombo(comboBoxCourseID.SelectedIndex);
            }    
            else
            {
                MessageBox.Show("Course not updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editCourseForm_Load(object sender, EventArgs e)
        {
            comboBoxCourseID.DataSource = course.getAllCourse();
            comboBoxCourseID.DisplayMember = "label";
            comboBoxCourseID.ValueMember = "id";
            comboBoxCourseID.SelectedItem = null;
        }

        private void comboBoxCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBoxCourseID.SelectedValue); ;
                DataTable table = new DataTable();
                table = course.getCourseById(id);
                textBoxCourseName.Text = table.Rows[0][1].ToString();
                numericUpDownPeriod.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBoxDescription.Text = table.Rows[0][3].ToString();
            }
            catch { }            
        }
    }
}
