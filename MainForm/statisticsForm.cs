using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainForm
{
    public partial class statisticsForm : Form
    {
        public statisticsForm()
        {
            InitializeComponent();
        }

        private void statisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                CONTACT contact = new CONTACT();
                string query = "SELECT DISTINCT [group].name, COUNT(mycontact.id) " +
                    "FROM mycontact inner join [group] on mycontact.group_id = [group].id " +
                    "WHERE mycontact.userid = " + Globals.GlobalUserID +
                    "GROUP BY [group].name";
                DataTable table = contact.getContact(new System.Data.SqlClient.SqlCommand(query));

                var chartArea = new ChartArea("Group");
                chartArea.AxisX.Title = "xxx";
                chartArea.AxisY.Title = "yyy";
              //  chartGroup.ChartAreas.Axist

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string item = table.Rows[i][0].ToString();
                    int value = Int32.Parse(table.Rows[i][1].ToString());
                    chartGroup.Series["Group"].Points.AddXY(item, value);
                }
            }
            catch { }
        }
    }
}
