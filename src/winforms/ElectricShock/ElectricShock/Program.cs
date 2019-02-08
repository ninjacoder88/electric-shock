using System;
using System.Windows.Forms;
using ElectricShock.AppForms;

namespace ElectricShock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var viewModel = new FormMainViewModel();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(viewModel));
        }
    }
}
