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
    class GROUP
    {
        MY_DB mydb = new MY_DB();
        public bool insertGroup(int id, string fname, string lname, string groupID, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO mycontact (id, fname, lname, group_id, phone, email, address, pic)" +
                "VALUES (@id, @fn, @ln, @gID, @phn, @email, @adr, @pic)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gID", SqlDbType.NChar).Value = groupID;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@adr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool deleteContact(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM mycontact WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

        public bool updateContact(int id, string fname, string lname, string groupID, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn, lname=@ln, group_id=@gID, phone=@phn, email=@email, address=@adr, picture=@pic WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gID", SqlDbType.NChar).Value = groupID;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@adr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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
    }
}
