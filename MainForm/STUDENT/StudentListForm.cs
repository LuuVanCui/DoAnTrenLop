using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MainForm
{
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        { 
            InitializeComponent();
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }


        /// <summary>
        /// sử dụng double click trong datagridview để vào form khác, chứa thông tin chi tiết của từng sinh viên
        /// </summary>
        /// <param name="sender">dataGridView1</param>
        /// <param name="e">DoubleClick</param>
        public void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // lấy dữ liệu từ datagridview qua
            UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
            updateDeleteStdF.comboBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStdF.txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStdF.txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStdF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            // gender
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female")
                updateDeleteStdF.rBntFemale.Checked = true;
            else
                updateDeleteStdF.rBntMale.Checked = true;

            updateDeleteStdF.txtPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStdF.txtAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            // code xử lý up hình ảnh lên, version1, chạy OK, tìm hiểu thêm để code nhẹ hơn
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStdF.pictureBoxImage.Image = Image.FromStream(picture);
            
            updateDeleteStdF.ShowDialog();
            
        }

        STUDENT student = new STUDENT();

        // sử dụng datagridview để lấy dữ liệu của sinh viên
        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.qLSVDataSet.std);

            SqlCommand command = new SqlCommand("SELECT *FROM std");
            dataGridView1.ReadOnly = true;
            
            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridView1.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp
            dataGridView1.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.AllowUserToAddRows = false;
        }
        public void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT *FROM std");
            dataGridView1.ReadOnly = true;


            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridView1.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp
            dataGridView1.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
