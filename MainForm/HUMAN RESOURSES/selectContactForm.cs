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
            SqlCommand command = new SqlCommand("SELECT distinct id as 'Contact ID',  fname  as 'First Name',  lname  as 'Last Name',  group_id  as 'Group ID' FROM mycontact WHERE  userid  = @uid");
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserID;
            dataGridViewData.DataSource = contact.getContact(command);
            dataGridViewData.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                if (isOdd(i))
                {
                    dataGridViewData.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }
            }
        }

        bool isOdd(int value)
        {
            return value % 2 != 0;
        }

        private void dataGridViewData_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
