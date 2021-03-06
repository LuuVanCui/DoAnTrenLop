﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainForm
{
    public partial class addContactForm : Form
    {
        public addContactForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonUploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *gif)|*.jpg; *.png; *gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPicture.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                int id = Int32.Parse(textBoxID.Text);
                string fname = textBoxFirstName.Text;
                string lname = textBoxLastName.Text;
                int group_id = Int32.Parse(comboBoxGroupID.SelectedValue.ToString());
                string phone = textBoxPhone.Text;
                string email = textBoxEmail.Text;
                string address = textBoxAddress.Text;
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    if (contact.contactExist(id, group_id))
                    {
                        MessageBox.Show("Contact ID are already exist.", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                    else
                    {
                        pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
                        if (contact.insertContact(id, fname, lname, group_id, phone, email, address, pic))
                        {
                            MessageBox.Show("New Contact Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "add contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (textBoxFirstName.Text == null
                || textBoxLastName.Text == null
                || comboBoxGroupID.Text == null
                || textBoxPhone.Text == null
                || textBoxEmail.Text == null
                || textBoxAddress.Text == null
                || pictureBoxPicture.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void addContactForm_Load(object sender, EventArgs e)
        {
            GROUP group = new GROUP();
            DataTable table = group.getGroups(Globals.GlobalUserID);
            if (table.Rows.Count > 0)
            {
                comboBoxGroupID.DataSource = table;
                comboBoxGroupID.ValueMember = "id";
                comboBoxGroupID.DisplayMember = "name";
            }
            else
            {
                MessageBox.Show("You have to Create Group before adding new contact.", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }    
        }
    }
}
