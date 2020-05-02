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
            SqlCommand command = new SqlCommand("INSERT INTO group (id, name, userid)" +
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
            SqlCommand command = new SqlCommand("DELETE FROM group WHERE id = @id", mydb.getConnection);
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

        public bool updateGroup(int id, string name, int userid)
        {
            SqlCommand command = new SqlCommand("UPDATE group SET name = @name, userid = @userid WHERE id=@ID", mydb.getConnection);
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

        public DataTable getGroupList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
