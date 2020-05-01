using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MainForm
{
    class COURSE1
    {
        MY_DB mydb = new MY_DB();

        // function to insert a course
        public bool insertCourse(int id, string label, int period, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, label, period, description) VALUES (@id, @lb, @period, @des)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@lb", SqlDbType.NVarChar).Value = label;
            command.Parameters.Add("@period", SqlDbType.Int).Value = period;
            command.Parameters.Add("@des", SqlDbType.Text).Value = description;

            mydb.openConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1)
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

        // get Course from database
        public DataTable getCourse(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int totalCourses()
        {
            SqlCommand command = new SqlCommand("SELECT *FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count;
        }

        public DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("SELECT *FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseById(int id)
        {

            SqlCommand command = new SqlCommand("SELECT *FROM Course WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateCourse(int id, string label, int period, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE Course SET label=@lb,period=@period,description=@des WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@lb", SqlDbType.NVarChar).Value = label;
            command.Parameters.Add("@period", SqlDbType.Int).Value = period;
            command.Parameters.Add("@des", SqlDbType.Text).Value = description;

            mydb.openConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1)
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

        public bool deleteCourseById(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1)
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

        public bool checkCourseName(string courseName, int courseID = 0)
        {
            // id <> @cID de phan biet xem co ton tai khong, chi la parameter
            SqlCommand command = new SqlCommand("SELECT *FROM Course WHERE label=@cName AND id <> @cID", mydb.getConnection);
            command.Parameters.Add("cName", SqlDbType.NVarChar).Value = courseName;
            command.Parameters.Add("@cID", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                // Neu phat hien co 1 dong ton tai trung ten
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
