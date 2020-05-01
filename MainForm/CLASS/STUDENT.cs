using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MainForm
{
    class STUDENT
    {
        MY_DB mydb = new MY_DB();
       
        // function to insert a new student
        public bool insertStudent(int id, string lname, string fname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {            
            SqlCommand command = new SqlCommand("INSERT INTO std (id, lname, fname, bdate, gender, phone, address, picture)" +
                "VALUES (@id, @ln, @fn, @bd, @gd, @phn, @adr, @pic)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@bd", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gd", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
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
            catch(Exception ex)
            {           
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // function to get all students from database
        public DataTable getStudent(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table; 
        }

        // delete sutudent by id
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
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

        // update student information
        public bool updateStudent(int id, string lname, string fname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln,bdate=@bd,gender=@gd,phone=@phn,address=@adr,picture=@pic WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@bd", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gd", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

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

        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }

        public string totalStudent()
        {
            return execCount("SELECT COUNT(*) FROM std");
        }

        public string totalMaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM std WHERE gender='Male'");
        }

        public string totalFemaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM std WHERE gender='Female'");
        }
    }
}
