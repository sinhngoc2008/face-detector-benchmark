using System;
using System.Windows.Forms;

namespace Xisom.FaceDetection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GC.Collect(2, GCCollectionMode.Optimized);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FaceDetector());
        }
    }
}
