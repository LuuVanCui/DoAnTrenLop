using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace MainForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStudent frmAddStudent = new frmAddStudent();
            frmAddStudent.Show(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm listForm = new StudentListForm();
            try
            {
                listForm.Show();
            }           
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm staticsForm = new StaticsForm();
            staticsForm.Show(this);
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageStudentForm manageStudent = new manageStudentForm();
            manageStudent.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDelete = new UpdateDeleteStudentForm();
            updateDelete.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            print.Show(this);
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCourseForm addCourse = new addCourseForm();
            addCourse.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeCourseForm removeCourse = new removeCourseForm();
            removeCourse.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editCourseForm editCourse = new editCourseForm();
            editCourse.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageCourseForm manageCourse = new manageCourseForm();
            manageCourse.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourseForm printCourse = new PrintCourseForm();
            printCourse.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addScoreForm addScoreForm = new addScoreForm();
            addScoreForm.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeScoreForm removeScoreForm = new removeScoreForm();
            removeScoreForm.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageScoreForm manageScoreForm = new manageScoreForm();
            manageScoreForm.Show(this);
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm avgScoreForm = new avgScoreByCourseForm();
            avgScoreForm.Show(this);
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            printScoresForm printForm = new printScoresForm();
            printForm.Show(this);
        }

        private void aVGResultByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultForm result = new resultForm();
            result.Show(this);
        }

        private void staticsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statisticsResultForm statisticsForm = new statisticsResultForm();
            statisticsForm.Show(this);
        }
    }
}
