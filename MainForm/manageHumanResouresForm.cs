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
    public partial class manageHumanResouresForm : Form
    {
        public manageHumanResouresForm()
        {
            InitializeComponent();
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            addContactForm addContact = new addContactForm();
            addContact.Show(this);
        }

        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            editContactForm editContact = new editContactForm();
            editContact.Show(this);
        }

        private void buttonSelectContact_Click(object sender, EventArgs e)
        {
            selectContactForm selectContact = new selectContactForm();
            selectContact.ShowDialog();
            textBoxContactID.Text = selectContact.dataGridViewData.CurrentRow.Cells[0].Value.ToString();
        }

        private void buttonRemoveContact_Click(object sender, EventArgs e)
        {
            try
            {
                int contactId = Convert.ToInt32(textBoxContactID.Text);
                CONTACT contact = new CONTACT();
                if (MessageBox.Show("Do you want to delete this contact?", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (contact.deleteContact(contactId))
                    {
                        MessageBox.Show("This contact deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can not delete this contact", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void buttonShowFullList_Click(object sender, EventArgs e)
        {
            contactFullListForm contactList = new contactFullListForm();
            contactList.Show(this);
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                GROUP group = new GROUP();
                string name = textBoxGroupName.Text.Trim();
                int id = Int32.Parse(textBoxGroupID.Text);
               
                if (verif())
                {
                    if (group.insertGroup(id, name, Globals.GlobalUserID))
                    {
                        MessageBox.Show("New Group Added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if (textBoxGroupName.Text == null || textBoxGroupID.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void manageHumanResouresForm_Load(object sender, EventArgs e)
        {
            GROUP group = new GROUP();
            comboBoxSelectGroup.DataSource = group.getGroups(Globals.GlobalUserID);
            comboBoxSelectGroup.ValueMember = "id";
            comboBoxSelectGroup.DisplayMember = "name";

            comboBoxSelectGroupName.DataSource = group.getGroups(Globals.GlobalUserID);
            comboBoxSelectGroupName.ValueMember = "id";
            comboBoxSelectGroupName.DisplayMember = "name";
        }

        private void buttonEditGroupName_Click(object sender, EventArgs e)
        {
            try
            {
                GROUP group = new GROUP();
                int id = Convert.ToInt32(comboBoxSelectGroup.SelectedValue.ToString());
                string name = textBoxNewGroupName.Text;

                if (verif())
                {
                    if (group.updateGroup(id, name))
                    {
                        MessageBox.Show("New Group Updated", "Edit Group Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        manageHumanResouresForm_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Group Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Group Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Group Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupId = Convert.ToInt32(comboBoxSelectGroupName.SelectedValue.ToString());
                GROUP group = new GROUP();
                if (MessageBox.Show("Do you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (group.deleteGroup(GroupId))
                    {
                        MessageBox.Show("This group deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        manageHumanResouresForm_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Can not delete this group", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
    }
}
