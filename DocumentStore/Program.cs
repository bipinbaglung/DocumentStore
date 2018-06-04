using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentStore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (args != null && args.Length > 0)
                    DBSupport.StartUp(args[0]);
                else
                    DBSupport.StartUp(null);

            }
            catch
            {
                MessageBox.Show("Could not connect to database. Program will not function properly.");
            }
            try
            {
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}
