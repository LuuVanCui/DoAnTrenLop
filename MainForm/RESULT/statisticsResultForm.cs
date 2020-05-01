﻿using System;
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
    public partial class statisticsResultForm : Form
    {
        public statisticsResultForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();

        private void statisticsResultForm_Load(object sender, EventArgs e)
        {
            statisticsCourses();
            statisticsResult();
        }

        void statisticsCourses()
        {
            try
            {
                string query = "SELECT label, AVG(student_score) " +
                    "FROM dbo.Course INNER JOIN dbo.Score ON dbo.Score.course_id = dbo.Course.id " +
                    "GROUP BY label";
                DataTable table = score.getData(new SqlCommand(query));

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string item = table.Rows[i][0].ToString();
                    float value = float.Parse(table.Rows[i][1].ToString());
                    chartCourses.Series["Courses"].Points.AddXY(item, value);
                }
            }
            catch { }
        }

        void statisticsResult()
        {
           
                RESULT result = new RESULT();
                DataTable table = result.getResult();

                string[] item = new string[5] { "Excellent", "Good", "Average", "Below Average", "Weak" };
                int[] arr = new int[5] { 0, 0, 0, 0, 0 };

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    
                    float _score = float.Parse(table.Rows[i]["avg_score"].ToString());

                    if (_score >= 8.5)
                    {
                        arr[0]++;
                    }
                    else if (_score >= 7)
                    {
                        arr[1]++;
                    }
                    else if (_score >= 5.5)
                    {
                        arr[2]++;
                    }
                    else if (_score >= 4)
                    {
                        arr[3]++;
                    }
                    else
                    {
                        arr[4]++;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (arr[i] > 0)
                      chartResult.Series["Result"].Points.AddXY(item[i], arr[i]);
                }
        }
            
        
    }
}
