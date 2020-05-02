using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class createNewAccountForm : Form
    {
        public createNewAccountForm()
        {
            InitializeComponent();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void buttonloadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *gif)|*.jpg; *.png; *gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPicture.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                USER user = new USER();
                int id = Int32.Parse(textBoxID.Text);
                string fname = textBoxFirstName.Text;
                string lname = textBoxLastName.Text;
                string uname = textBoxUser.Text;
                string pwd = textBoxPass.Text;
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
                    if (user.insertUser(id, fname, lname, uname, pwd, pic))
                    {
                        MessageBox.Show("New User Added", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (textBoxFirstName.Text.Trim() == ""
                || textBoxLastName.Text.Trim() == ""
                || textBoxUser.Text.Trim() == ""
                || textBoxPass.Text.Trim() == ""
                || pictureBoxPicture.Image == null)
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
