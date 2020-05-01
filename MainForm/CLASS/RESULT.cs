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
        public DataTable getResult()
        {
            SCORE score = new SCORE();
            string query = "SELECT student_id, fname, lname, AVG(student_score) as avg_score FROM dbo.Score, std " +
                "WHERE dbo.Score.student_id = std.id GROUP BY student_id, fname, lname";
            DataTable table = score.getData(new SqlCommand(query));

            table.Columns.Add("Result", typeof(System.String));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                float _score = float.Parse(table.Rows[i]["avg_score"].ToString());

                if (_score >= 8.5)
                {
                    table.Rows[i]["Result"] = "Excellent";
                }
                else if (_score >= 7)
                {
                    table.Rows[i]["Result"] = "Good";
                }
                else if (_score >= 5.5)
                {
                    table.Rows[i]["Result"] = "Average";
                }
                else if (_score >= 4)
                {
                    table.Rows[i]["Result"] = "Below Average";
                }
                else
                {
                    table.Rows[i]["Result"] = "Weak";
                }
            }
            
            return table;
        }
    }
}
