using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class editContactForm : Form
    {
        public editContactForm()
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

        private void buttonSelectContact_Click(object sender, EventArgs e)
        {
            selectContactForm selectContact = new selectContactForm();
            selectContact.ShowDialog();

            try
            {

                int contactId = Convert.ToInt32(selectContact.dataGridViewData.CurrentRow.Cells[0].Value.ToString());

                CONTACT contact = new CONTACT();
                string query = "SELECT * FROM mycontact WHERE id = " + contactId;
                DataTable table = contact.getContact(new SqlCommand(query));

                textBoxID.Text = table.Rows[0]["id"].ToString();
                textBoxFirstName.Text = table.Rows[0]["fname"].ToString();
                textBoxLastName.Text = table.Rows[0]["lname"].ToString();
                comboBoxGroup.SelectedValue = table.Rows[0]["group_id"];
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxEmail.Text = table.Rows[0]["email"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["pic"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxPicture.Image = Image.FromStream(picture);

            }
            catch (Exception)
            {

            }

        }

        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                int id = Int32.Parse(textBoxID.Text);
                string fname = textBoxFirstName.Text;
                string lname = textBoxLastName.Text;
                string group_id = comboBoxGroup.SelectedValue.ToString();
                string phone = textBoxPhone.Text;
                string email = textBoxEmail.Text;
                string address = textBoxAddress.Text;
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    pictureBoxPicture.Image.Save(pic, pictureBoxPicture.Image.RawFormat);
                    if (contact.updateContact(id, fname, lname, group_id, phone, email, address, pic))
                    {
                        MessageBox.Show("Updated Contact", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // chức năng kiểm tra dữ liệu input
        bool verif()
        {
            if (textBoxFirstName.Text.Trim() == ""
                || textBoxLastName.Text.Trim() == ""
                || comboBoxGroup.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || textBoxEmail.Text.Trim() == ""
                || textBoxAddress.Text.Trim() == ""
                || pictureBoxPicture.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void editContactForm_Load(object sender, EventArgs e)
        {
            GROUP group = new GROUP();
            DataTable table = group.getGroups(Globals.GlobalUserID);
            if (table.Rows.Count > 0)
            {
                comboBoxGroup.DataSource = table;
                comboBoxGroup.ValueMember = "id";
                comboBoxGroup.DisplayMember = "name";
            }
            else
            {
                MessageBox.Show("You have to Create Group before editing contact.", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
