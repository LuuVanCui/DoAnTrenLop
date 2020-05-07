using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    class CONTACT
    {
        MY_DB mydb = new MY_DB();

        public bool insertContact(int id, string fname, string lname, int groupID, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO mycontact (id, fname, lname, group_id, phone, email, address, pic, userid)" +
                "VALUES (@id, @fn, @ln, @gID, @phn, @email, @adr, @pic, @uid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gID", SqlDbType.Int).Value = groupID;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@adr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserID;

            mydb.openConnection();

            try
            {
                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteContact(int id, int group_id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM mycontact WHERE id = @id AND group_id = @gid AND userid = @uid", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserID;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = group_id;

            mydb.openConnection();

            try
            {
                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool updateContact(int id, string fname, string lname, int groupID, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE mycontact SET fname=@fn, lname=@ln, group_id=@gID, phone=@phn, email=@email, address=@adr, pic=@pic WHERE id=@ID AND userid = @uid", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gID", SqlDbType.Int).Value = groupID;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@adr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserID;

            mydb.openConnection();

            try
            {
                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable getContact(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getContactByUserId(SqlCommand command)
        {
            command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserID;
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        
        public bool contactExist(int contactId, int groupId)
        {
            string query = "SELECT * FROM mycontact WHERE id = @cid AND group_id = @gid AND userid = " + Globals.GlobalUserID;
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = contactId;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupId;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
