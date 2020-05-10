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
    public partial class manageStudentForm : Form
    {
        public manageStudentForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void manageStudentForm_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand(@"SELECT *FROM std"));
            fillDataFromGridView();
        }

        void fillDataFromGridView()
        {
            if (dataGridViewStudent.Rows.Count > 0)
            {
                textBoxStudentID.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
                textBoxFirstName.Text = dataGridViewStudent.CurrentRow.Cells[1].Value.ToString();
                textBoxLastName.Text = dataGridViewStudent.CurrentRow.Cells[2].Value.ToString();
                dateTimePickerBirthDate.Value = (DateTime)dataGridViewStudent.CurrentRow.Cells[3].Value;
                if (dataGridViewStudent.CurrentRow.Cells[4].Value.ToString() == "Male")
                    radioButtonMale.Checked = true;
                else
                    radioButtonFemale.Checked = true;
                textBoxPhone.Text = dataGridViewStudent.CurrentRow.Cells[5].Value.ToString();
                textBoxAddress.Text = dataGridViewStudent.CurrentRow.Cells[6].Value.ToString();
                // get image
                byte[] bytes = (byte[])dataGridViewStudent.CurrentRow.Cells[7].Value;
                MemoryStream ms = new MemoryStream(bytes);
                pictureBoxPicture.Image = Image.FromStream(ms);
            }
            else
            {
                MessageBox.Show("No data");
            }
        }

        public void fillGrid(SqlCommand command)
        {
            dataGridViewStudent.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridViewStudent.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp
            dataGridViewStudent.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridViewStudent.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewStudent.AllowUserToAddRows = false;
            // Đếm sinh viên
            labelTotal.Text = "Total Student: " + dataGridViewStudent.Rows.Count;
        }

        // làm trống thông tin
        void emptyInfor()
        {
            textBoxStudentID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            dateTimePickerBirthDate.Value = DateTime.Now;
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            pictureBoxPicture.Image = null;
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (textBoxFirstName.Text.Trim() == ""
                || textBoxLastName.Text.Trim() == ""
                || textBoxAddress.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || pictureBoxPicture.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *gif)|*.jpg; *.png; *gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPicture.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "student_" + textBoxStudentID.Text;
            if (pictureBoxPicture.Image == null)
            {
                MessageBox.Show("No Image in the PictureBox");
            }
            else if (svf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPicture.Image.Save(svf.FileName + ("." + System.Drawing.Imaging.ImageFormat.Jpeg.ToString()));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id = Convert.ToInt32(textBoxStudentID.Text);
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            DateTime bdate = dateTimePickerBirthDate.Value;
            string phone = textBoxPhone.Text;
            string adrs = textBoxAddress.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();

            int born_year = dateTimePickerBirthDate.Value.Year;
            int this_year = DateTime.Now.Year;

            // sinh viên từ 10-100 có thể thay đổi
            if (this_year - born_year < 10 || this_year - born_year > 100)
            {
                MessageBox.Show("The student age must be bewteen 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
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
            fillGrid(new SqlCommand("SELECT *FROM std"));
            fillDataFromGridView();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            DateTime bdate = dateTimePickerBirthDate.Value;
            string phone = textBoxPhone.Text;
            string adrs = textBoxAddress.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();

            int born_year = dateTimePickerBirthDate.Value.Year;
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
                    id = Convert.ToInt32(textBoxStudentID.Text);
                    pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
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
            emptyInfor();
            fillGrid(new SqlCommand("SELECT *FROM std"));
            fillDataFromGridView();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            // delete student
            try
            {
                //  int studentID = Convert.ToInt32(textBoxID.Text);
                int studentID = Convert.ToInt32(dataGridViewStudent.CurrentRow.Cells[0].Value.ToString());
                // dislay a confirmation message before the delete
                if (MessageBox.Show("Are you sure you want to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentID))
                    {
                        MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            fillGrid(new SqlCommand("SELECT *FROM std"));
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT *FROM std"));
            fillDataFromGridView();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM std WHERE CONCAT(id, fname, lname, bdate, gender, phone, address) LIKE '%" + textBoxSearch.Text + "%'";
                dataGridViewStudent.DataSource = student.getStudent(new SqlCommand(query));
            }
            catch { }
        }

        private void dataGridViewStudent_Click(object sender, EventArgs e)
        {
            fillDataFromGridView();
        }
    }
}