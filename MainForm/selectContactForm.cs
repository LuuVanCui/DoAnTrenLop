using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class selectContactForm : Form
    {
        public selectContactForm()
        {
            InitializeComponent();
        }

        private void selectContactForm_Load(object sender, EventArgs e)
        {
            dataGridViewData.ReadOnly = true;
            CONTACT contact = new CONTACT();
            //SqlCommand command = new SqlCommand("SELECT  id ,  fname  as'first name',  lname  as 'last name',  group_id  as'group id' FROM  mycontact  WHERE  userid  = @uid");
            //command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserId;
            string query = "SELECT  id as 'Contact ID',  fname  as 'First Name',  lname  as 'Last Name',  group_id  as 'Group ID' FROM  mycontact";
            dataGridViewData.DataSource = contact.getContact(new SqlCommand(query));
            dataGridViewData.AllowUserToAddRows = false;
        }

        private void dataGridViewData_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
