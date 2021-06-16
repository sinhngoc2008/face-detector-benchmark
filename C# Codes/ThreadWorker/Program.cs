using System;
using System.Windows.Forms;

namespace ThreadWorker
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
            Application.Run(new MainWorker());
            //Application.Run(new LayoutDesign());
        }
    }
}
