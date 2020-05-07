using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MainForm
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnUpploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *gif)|*.jpg; *.png; *gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        // button cancel (close the form)
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // button insert a student
        private void button2_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id = Convert.ToInt32(txtStudentID.Text);
            string fname = txtFName.Text;
            string lname = txtLName.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();

            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            // sinh viên từ 10-100 có thể thay đổi
            if (this_year - born_year < 10 || this_year - born_year > 100)
            {
                MessageBox.Show("The student age must be bewteen 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if (student.insertStudent(id, lname, fname, bdate, gender, phone, adrs, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            emptyInfor();
        }

        // làm trống thông tin
        void emptyInfor()
        {
            txtStudentID.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtPhone.Text = "";
            txtAddress.Text = "";
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            pictureBox1.Image = null;
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (txtFName.Text.Trim() == ""
                || txtLName.Text.Trim() == ""
                || txtAddress.Text.Trim() == ""
                || txtPhone.Text.Trim() == ""
                || pictureBox1.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
