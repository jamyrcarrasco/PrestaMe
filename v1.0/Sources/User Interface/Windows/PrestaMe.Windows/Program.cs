using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestaMe.Windows
{
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

            //Forms.splashForm splashForm = new Forms.splashForm();
            //splashForm.Show();

            //Application.Run();

            Application.Run(new Forms.loginForm());
        }
    }
}
