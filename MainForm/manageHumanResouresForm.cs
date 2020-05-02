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
            selectContact.Show(this);
        }

        private void buttonRemoveContact_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonShowFullList_Click(object sender, EventArgs e)
        {
            contactFullListForm contactList = new contactFullListForm();
            contactList.Show(this);
        }
    }
}
