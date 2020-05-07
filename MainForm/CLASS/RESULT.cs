using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MainForm
{
    class RESULT
    {
        public DataTable getResult(string query)
        {
            // get student
            SCORE score = new SCORE();

            DataTable tableShowData = score.getData(new SqlCommand(query));

            // get Course
            string queryCourse = "SELECT * FROM Course";
            DataTable tableCourse = score.getData(new SqlCommand(queryCourse));

            // get Score
            string queryScore = "SELECT * FROM Score";
            DataTable tableScore = score.getData(new SqlCommand(queryScore));

            // Add Clumns
            for (int i = 0;  i < tableCourse.Rows.Count; i++)
            {
                tableShowData.Columns.Add(tableCourse.Rows[i]["label"].ToString(), typeof(String));
            }

            // fill score in table
            for (int i = 0; i < tableShowData.Rows.Count; i++)
            {
                int std_id = Convert.ToInt32(tableShowData.Rows[i][0].ToString());
                for (int j = 0; j < tableScore.Rows.Count; j++)
                {
                    int course_id = Convert.ToInt32(tableScore.Rows[j]["course_id"].ToString());
                    if (getEachScore(std_id, course_id) != -1)
                    {
                        tableShowData.Rows[i][2 + course_id] = getEachScore(std_id, course_id);
                    }
                }    
            }

            // Add Columns AVG & Result
            tableShowData.Columns.Add("AVG Score", typeof(Double));
            tableShowData.Columns.Add("Result", typeof(String));

            // Calculate Result
            string queryResult = "SELECT AVG(student_score) FROM dbo.Score GROUP BY student_id";
            DataTable tableResult = score.getData(new SqlCommand(queryResult));
            for (int i = 0; i < tableShowData.Rows.Count; i++)
            {
                float _score = float.Parse(tableResult.Rows[i][0].ToString());
                tableShowData.Rows[i]["AVG Score"] = tableResult.Rows[i][0];
                tableShowData.Rows[i]["Result"] = getTextResult(_score);
            }  
            return tableShowData;
        }

        public float getEachScore(int studentID, int courseID)
        {
            SCORE score = new SCORE();
            // get Score Table
            string queryScore = "SELECT * FROM Score";
            DataTable tableScore = score.getData(new SqlCommand(queryScore));
            for (int i = 0; i < tableScore.Rows.Count; i++)
            {
                if (Convert.ToInt32(tableScore.Rows[i]["student_id"].ToString()) == studentID
                    && Convert.ToInt32(tableScore.Rows[i]["course_id"].ToString()) == courseID)
                {
                    return float.Parse(tableScore.Rows[i]["student_score"].ToString());
                }
            }
            return -1;
        }

        public string getTextResult(float _score)
        {
            if (_score >= 8.5)
            {
                return "Excellent";
            }
            else if (_score >= 7)
            {
                return "Good";
            }
            else if (_score >= 5.5)
            {
                return "Average";
            }
            else if (_score >= 4)
            {
                return "Below Average";
            }
            else
            {
                return "Weak";
            }
        }
    }
}
