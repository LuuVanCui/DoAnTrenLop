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
    public partial class contactFullListForm : Form
    {
        public contactFullListForm()
        {
            InitializeComponent();
        }

        private void contactFullListForm_Load(object sender, EventArgs e)
        {
            dataGridViewShowData.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // đối tượng làm việc với dạng hình ảnh của datagridview
            dataGridViewShowData.RowTemplate.Height = 80; // căng chỉnh hình ảnh cho đẹp

            CONTACT contact = new CONTACT();
            string query = "SELECT fname as 'First Name', lname as 'Last Name', " +
                "[group].name as 'Group', phone as 'Phone', email as 'Email', " +
                "address as 'Address', pic as 'Picture' " +
                "FROM mycontact INNER JOIN [group] on mycontact.group_id = [group].id " + 
                "WHERE mycontact.userid = @userid";

            dataGridViewShowData.DataSource = contact.getContactByUserId(new SqlCommand(query));
            picCol = (DataGridViewImageColumn)dataGridViewShowData.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewShowData.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridViewShowData.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridViewShowData.Rows[i].DefaultCellStyle.BackColor = Color.DarkBlue;
                }    
            }

            GROUP group = new GROUP();
            listBoxGroup.DataSource = group.getGroups(Globals.GlobalUserID);
            listBoxGroup.ValueMember = "id";
            listBoxGroup.DisplayMember = "name";

            listBoxGroup.SelectedItem = null;
            listBoxGroup.ClearSelected();
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void listBoxGroup_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                int groupid = (Int32)listBoxGroup.SelectedValue;
                string query = "SELECT fname as 'First Name', lname as 'Last Name', " +
                    "[group].name as 'Group', phone as 'Phone', email as 'Email', " +
                    "address as 'Address', pic as 'Picture' " +
                    "FROM mycontact INNER JOIN [group] on mycontact.group_id = [group].id " +
                    "WHERE mycontact.userid = @userid AND mycontact.group_id = @groupid";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserID;
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupid;
                dataGridViewShowData.DataSource = contact.getContact(new SqlCommand(query));

                for (int i = 0; i < dataGridViewShowData.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {
                        dataGridViewShowData.Rows[i].DefaultCellStyle.BackColor = Color.DarkBlue;
                    }
                }
            }
            catch { }
            dataGridViewShowData.ClearSelection();
        }
    }
}