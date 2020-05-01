using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class StaticsForm : Form
    {
        public StaticsForm()
        {
            InitializeComponent();
        }
        // đặt màu nếu muốn
        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;

        private void StaticsForm_Load(object sender, EventArgs e)
        {
            // get pannel color
            panTotalColor = panelTotal.BackColor;
            panMaleColor = panelMale.BackColor;
            panFemaleColor = panelFemale.BackColor;

            // display the values
            STUDENT student = new STUDENT();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

            // tinh %
            // (tong students x 100) / (total students)
            double maleStudentsPercentage = (totalMale * 100 / total);
            double femaleStudentsPercentage = totalFemale * 100 / total;
            labelTotal.Text = ("Total Students: " + total.ToString());
            labelMale.Text = "Male: " + maleStudentsPercentage.ToString("0.00") + "%";
            labelFemale.Text = "Female: " + femaleStudentsPercentage.ToString("0.00") + "%";
        }
    }
}
