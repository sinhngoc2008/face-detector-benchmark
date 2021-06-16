using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadWorker
{
    /// <summary>
    /// Main thread Winform class 
    /// </summary>
    public partial class MainWorker : Form
    {
        
        private bool isProcessing;
        private delegate void DisplayCountDelegate(int i);
        private Thread thread;
        public MainWorker()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 3000;
            this.isProcessing = false;
            this.thread = new Thread(StartCounting);
            this.thread.IsBackground = true;

        }


        private void mainButton_Click(object sender, EventArgs e)
        {

            if (!this.isProcessing)
            {  
                this.thread.Start();
                mainButton.Visible = false;
            }
            
        }

        private void StartCounting() 
        {
                try
                {
                for (int i = 0; i <= progressBar1.Maximum; i++)
                {
                    this.Invoke(new DisplayCountDelegate(DisplayCount), i);
                    Thread.Sleep(10);
                    
                }
                }
                catch (Exception e)
                {
                    //catching the exception if sudden exit occours. 
                    MessageBox.Show(e.Message.ToString());
                }  
        }

        private void DisplayCount(int i)
        {
            fileLabelName.Text = "File : "+ i.ToString();
            progressBar1.Value = i;
            progressBar1.Update();
        }
    }
}
