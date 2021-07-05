using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ThreadWorker
{
    public partial class LayoutDesign : Form
    {

        private string DirString;
        private bool HasDir;
        private List<string> Filelist;

        private readonly object ProcessLock = new object();
        private bool LockTaken;

        private DataSet MainDataSet;
        private DataTable MainTable;

        private bool Hasloaded;
        private bool CancelMainThread;

        private Thread MainThread;

        public LayoutDesign()
        {
            
            this.DirString = string.Empty;
            this.HasDir = false;
            this.Filelist = new List<string>();
            InitializeComponent();

            this.Hasloaded = false;
            this.LockTaken = false;
            this.InitDataset();

            this.MainThread = new Thread(() => this.StartProcessing(string.Empty));
            this.MainThread.IsBackground = true;

        }

        private delegate void UpdateDatasetDeligate(int id, string fileName, string processName); 
        public void UpdateDataset(int id, string fileName,string processName)
        {
            DataRow dataRow = this.MainTable.NewRow();
            dataRow["Row ID"] = id;
            dataRow["File Name"] = fileName;
            dataRow["Accessed By"] = processName;

            this.MainTable.Rows.Add(dataRow);
            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ReadOnly = true;
        }

        private void StartProcessing(string access)
        {
            try
            {
                lock (this.ProcessLock)
                {
                    this.LockTaken = true;
                    if (this.LockTaken)
                    {
                        for (int i = 1; i <= this.Filelist.Count; i++)
                        {
                            if (this.CancelMainThread)
                            {
                                break;
                            }

                            this.Invoke(new UpdateDatasetDeligate(UpdateDataset), i, this.Filelist[i - 1], access);
                            Thread.Sleep(100);
                        }
                    }
                }
            }
            catch (SynchronizationLockException SyncEx)
            {
                MessageBox.Show("Process is busy. ", SyncEx.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    this.LockTaken = false;
                    this.Invoke(new Action(() => 
                    {
                        switch (access)
                        {
                            case "Process 1":
                                ProcessOneButton.Text = access;
                                break;
                            case "Process 2":
                                ProcessTwoButton.Text = access;
                                break;
                            case "Process 3":
                                ProcessThreeButton.Text = access;
                                break;
                            default:
                                break;
                        }
                    }));
                }
            }
        }

        private void ProcessOneButton_Click(object sender, System.EventArgs e)
        {
            if (this.Hasloaded)
            {
                string accessedString = "Process 1";

                this.MainThread = new Thread(() => this.StartProcessing(accessedString));
                this.MainThread.IsBackground = true;

                if (ProcessOneButton.Text == "Cancel")
                {
                    this.CancelMainThread = true;
                    ProcessOneButton.Text = "Process 1";
                }
                else
                {
                    this.CancelMainThread = false;
                    this.MainThread.Start();
                    ProcessOneButton.Text = "Cancel";
                }
            }
        }

        private void ProcessTwoButton_Click(object sender, System.EventArgs e)
        {
            if (this.Hasloaded)
            {
                string accessedString = "Process 2";

                this.MainThread = new Thread(() => this.StartProcessing(accessedString));
                this.MainThread.IsBackground = true;

                if (ProcessTwoButton.Text == "Cancel")
                {
                    this.CancelMainThread = true;
                    ProcessTwoButton.Text = "Process 2";
                }
                else
                {
                    this.CancelMainThread = false;
                    this.MainThread.Start();
                    ProcessTwoButton.Text = "Cancel";
                }
            }
        }

        private void ProcessThreeButton_Click(object sender, System.EventArgs e)
        {
            if (this.Hasloaded)
            {
                string accessedString = "Process 3";

                this.MainThread = new Thread(() => this.StartProcessing(accessedString));
                this.MainThread.IsBackground = true;

                if (ProcessThreeButton.Text == "Cancel")
                {
                    this.CancelMainThread = true;
                    ProcessThreeButton.Text = "Process 3";
                }
                else
                {
                    this.CancelMainThread = false;
                    this.MainThread.Start();
                    ProcessThreeButton.Text = "Cancel";
                }
            }
        }

        private void DirLoadButton_Click(object sender, System.EventArgs e)
        {
            this.DirString = DirTextBox.Text.ToString();
            this.HasDir = Directory.Exists(this.DirString);

            if (this.HasDir && !this.MainThread.IsAlive)
            {
                this.FileListLoader();
                ProcessQueueLabel.Text = "files in folder: "+this.Filelist.Count;

                if (this.Filelist.Count > 0)
                {
                    this.Hasloaded = true;
                }
            }

        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13 && !this.MainThread.IsAlive)
            {
                this.DirString = DirTextBox.Text.ToString();
                this.HasDir = Directory.Exists(this.DirString);

                if (this.HasDir)
                {
                    this.FileListLoader();
                    ProcessQueueLabel.Text = "files in folder: " + this.Filelist.Count;
                }

                if (this.Filelist.Count > 0)
                {
                    this.Hasloaded = true;
                }
            }
        }

        private void FileListLoader()
        {
            this.Filelist = Directory.EnumerateFiles(this.DirString, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToList();
        }

        public void InitDataset()
        {
            this.MainDataSet = new DataSet();
            this.MainTable = new DataTable();

            DataColumn rowid = new DataColumn("Row ID");
            DataColumn filename = new DataColumn("File Name");
            DataColumn accessButtonName = new DataColumn("Accessed By");

            this.MainTable.Columns.Add(rowid);
            this.MainTable.Columns.Add(filename);
            this.MainTable.Columns.Add(accessButtonName);

            this.MainDataSet.Tables.Add(this.MainTable);

            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ReadOnly = true;

            mainDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mainDataGridView.AutoResizeColumns();
            mainDataGridView.VirtualMode = true;

        }

    }


}
