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
    public partial class removeCourseForm : Form
    {
        public removeCourseForm()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            COURSE1 course = new COURSE1();

            try
            {
                int id = Convert.ToInt32(textBoxCourseID.Text);
                if (MessageBox.Show("Do you want to delete the course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (course.deleteCourseById(id))
                    {
                        MessageBox.Show("Deleted Course", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void removeCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
