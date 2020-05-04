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

                    if (user.usernameExist(uname, "register"))
                    {
                        MessageBox.Show("This User Name are already exist.", "Create New Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                    else
                    {
                        pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
                        if (user.insertUser(id, fname, lname, uname, pwd, pic))
                        {
                            MessageBox.Show("Register Success!", "Create New Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Create New Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Create New Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create New Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (textBoxFirstName.Text == null
                || textBoxLastName.Text == null
                || textBoxUser.Text == null
                || textBoxPass.Text == null
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
