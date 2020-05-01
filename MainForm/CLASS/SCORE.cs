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
    class SCORE
    {
        MY_DB mydb = new MY_DB();

        public bool insertScore(int studentID, int courseID, float studentScore, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (student_id, course_id, student_score, description) VALUES (@sid, @cid, @ss, @des)", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@ss", SqlDbType.Float).Value = studentScore;
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

        public bool deleteScore(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE student_id = @sid AND course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

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

        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Course.label, AVG(score.student_score) AS AverageGrade FROM Course, Score "
                + "WHERE Course.id = score.course_id GROUP BY Course.label";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public bool studentScoreExist(int studentID, int courseID) // Kiểm tra trùng
        {
            SqlCommand command = new SqlCommand("SELECT *FROM Score WHERE student_id = @sid AND course_id = @cid", mydb.getConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }    

        public DataTable getStudentsScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT SCORE.student_id, std.fname, std.lname, SCORE.course_id, COURSE.label, SCORE.student_score " +
                "FROM std INNER JOIN Score on std.id = Score.student_id INNER JOIN Course on Course.id = Score.course_id";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getData(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getScoreByCourseID(SqlCommand command, int courseID)
        {
            command.Connection = mydb.getConnection;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getScoreByStudentID(SqlCommand command, int studentID)
        {
            command.Connection = mydb.getConnection;
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
