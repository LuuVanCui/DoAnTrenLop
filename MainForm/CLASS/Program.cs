using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public static class Globals
    {
        public static Int32 GlobalUserID; // Modifiable in Code
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new frmLogin());
            
            frmLogin fLogin = new frmLogin();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Run(new manageHumanResouresForm());
            }   
        }
    }
}
