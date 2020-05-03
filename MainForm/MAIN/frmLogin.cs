using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            rBtnStudent.Checked = true;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (rBtnStudent.Checked == true)
            {
                MY_DB db = new MY_DB();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User AND password = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = txtUser.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPass.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    //  login with student
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MY_DB db = new MY_DB();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE uname = @User AND pwd = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = txtUser.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPass.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    Globals.GlobalUserID = Convert.ToInt32(table.Rows[0]["id"].ToString());
                    
                    //  login with human resourses
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createNewAccountForm newAccount = new createNewAccountForm();
            newAccount.Show(this);
        }
    }
}
