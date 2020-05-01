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
using System.IO;

namespace MainForm
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
            txtID.KeyPress += TxtID_KeyPress;
            btnUploadImage.Click += BtnUploadImage_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        STUDENT student = new STUDENT();

        // edit selected student data
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            
            string gender = "Male";           
            if (rBntFemale.Checked)
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
                try
                {
                    id = Convert.ToInt32(txtID.Text);
                    pictureBoxImage.Image.Save(pic, pictureBoxImage.Image.RawFormat);
                    if (student.updateStudent(id, lname, fname, bdate, gender, phone, adrs, pic))
                    {
                        MessageBox.Show("Student Info Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (txtFirstName.Text.Trim() == ""
                || txtLastName.Text.Trim() == ""
                || txtAddress.Text.Trim() == ""
                || txtPhone.Text.Trim() == ""
                || pictureBoxImage.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        // take image
        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        // Search with ID
        private void bntFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
           
                SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);

                DataTable table = student.getStudent(command);

                if (table.Rows.Count > 0)
                {
                    txtFirstName.Text = table.Rows[0]["fname"].ToString();
                    txtLastName.Text = table.Rows[0]["lname"].ToString();
                    dateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];

                    // gender
                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        rBntFemale.Checked = true;
                    }
                    else
                    {
                        rBntMale.Checked = true;
                    }

                    txtPhone.Text = table.Rows[0]["phone"].ToString();
                    txtAddress.Text = table.Rows[0]["address"].ToString();

                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBoxImage.Image = Image.FromStream(picture);
                }
                else
                {
                    MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Insert Student ID", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Remove selected student
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // delete student
            try
            {
                int studentID = Convert.ToInt32(txtID.Text);
                // dislay a confirmation message before the delete
                if (MessageBox.Show("Are you sure you want to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentID))
                    {
                        MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear field after delete
                        txtID.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtAddress.Text = "";
                        txtPhone.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        pictureBoxImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {               
                MessageBox.Show("Please enter a valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
