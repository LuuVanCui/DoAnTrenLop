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
        public bool insertGroup(int id,string name, int userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [group] (id, name, userid)" +
                "VALUES (@id, @name, @userid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NChar).Value = name;
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;

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

        public bool deleteGroup(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [group] WHERE id = @id", mydb.getConnection);
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

        public bool updateGroup(int id, string name)
        {
            SqlCommand command = new SqlCommand("UPDATE [group] SET name = @name WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NChar).Value = name;

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

        public DataTable getGroups(int userid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [group] WHERE userid = @uid");
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool groupExist(string name, string operation, int userid = 0, int groupid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if (operation == "add")
            {
                query = "SELECT * FROM [group] WHERE (name = @name OR id = @gid) AND userid = @uid";
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM [group] WHERE name = @name AND userid = @uid";
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            }

            command.Connection = mydb.getConnection;
            command.CommandText = query;

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
