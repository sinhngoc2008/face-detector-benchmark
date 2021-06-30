using OpenCvSharp;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Xisom.ReDesigned.FaceDetector
{

    public partial class MainForm : Form
    {
        #region variables

        private bool HasDir;
        private string DirString;
        private string[] ImageFilelist;
        private int CurrentRowID;
        private FolderBrowserDialog mainFolderBrowserDialog;
        private DataSet MainDataSet;
        private DataTable MainTable;
        private bool Hasprocessed;
        private FaceDetector FaceDetector;
        private Thread MainThread;
        private bool ThreadFlag;
        private Action MainAction;
        private CancellationTokenSource MainCancellationTokenSource;
        private CancellationToken MainCancellationToken;

        // process lock
        private readonly object ProcessLock = new object();
        private bool LockTaken;
        private bool IsInitialized; 


        #endregion variables
        public MainForm()
        {
            InitializeComponent();

            //double buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //initial Setup for the function call 
            this.Setup(false, string.Empty, 0);
            this.Hasprocessed = false;

            //initialization for the facedetector
            this.FaceDetector = new FaceDetector();

            //Datagridview virtual mode for memory saving
            mainDataGridView.VirtualMode = true;

            // dataset initlization
            InitDataset();

            // thread initialization

            this.ThreadFlag = false;
            
            // Task
            this.MainCancellationTokenSource = new CancellationTokenSource();
            this.MainCancellationToken = this.MainCancellationTokenSource.Token;

            // initlization of the locks
            this.LockTaken = false;
            this.IsInitialized = false;
        }

        /// <summary>
        /// mainPictureBox Image set with the given file URL 
        /// </summary>
        /// <param name="filename"></param>
        private void MainPictureBoxImageSet(string filename)
        {
            mainPictureBox.Image = (Image)new Bitmap(filename);
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        ///  mainPictureBox Image set with the given Image obj of the Image
        /// </summary>
        /// <param name="image"></param>
        private void MainPictureBoxImageSet(Image image)
        {
            mainPictureBox.Image = image;
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// function to load all images (*.png || *.jpg) in the selected dir URL
        /// </summary>
        /// <param name="dirString"></param>
        /// <returns> number of totoal viable images in the dir</returns>
        private int ImageDirLoading(string dirString)
        {
            if (this.HasDir)
            {
                this.ImageFilelist = Directory.EnumerateFiles(dirString, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToArray();

                if (this.ImageFilelist.Length > 0)
                {
                    this.IsInitialized = true;
                    return this.ImageFilelist.Length;
                }
                else
                    return -1;
            }
            else return -1;

        }
        /// <summary>
        /// fuction to set the DIR URL selected by user, both in the initialization and loading states
        /// </summary>
        /// <param name="hasDir"></param>
        /// <param name="dirString"></param>
        /// <param name="currentRowID"></param>
        private void Setup(bool hasDir, string dirString, int currentRowID)
        {
            this.HasDir = hasDir;
            this.DirString = dirString;
            this.CurrentRowID = currentRowID;
            mainProgressBar.Minimum = 0;
            dirTextBox.Text = this.DirString;
            int numOfImages = ImageDirLoading(this.DirString);


            dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;
            if (numOfImages > 0)
            {
                mainProgressBar.Maximum = numOfImages;
                this.CurrentRowID = 0;
                MainPictureBoxImageSet(this.ImageFilelist[currentRowID]);
            }
            mainDataGridView.Update();
            mainProgressBar.Value = this.CurrentRowID;
            this.IsInitialized = true;
        }


        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (e.KeyChar == (char)13 && this.IsInitialized)
                {
                    this.HasDir = Directory.Exists(dirTextBox.Text);
                    if (HasDir)
                    {
                        this.HasDir = true;
                        this.DirString = dirTextBox.Text.ToString();

                        // getting the images from the directory
                        int numOfImages = ImageDirLoading(this.DirString);

                        // setting the label
                        dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;

                        if (numOfImages > 0)
                        {
                            mainProgressBar.Maximum = numOfImages;
                            this.CurrentRowID = 0;
                            MainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                        }
                        this.IsInitialized = true;
                    }
                    else
                    {
                        MessageBox.Show("Not a Valid Directory");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }
            
        }

        private void DirButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock,ref this.LockTaken);
            try
            {
                if (!this.HasDir && Directory.Exists(dirTextBox.Text.ToString()))
                {
                    this.HasDir = true;
                    this.DirString = dirTextBox.Text.ToString();

                    // getting the images from the directory
                    int numOfImages = ImageDirLoading(this.DirString);

                    // setting the label
                    dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;

                    if (numOfImages > 0)
                    {
                        mainProgressBar.Maximum = numOfImages;
                        this.CurrentRowID = 0;
                        MainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                    }


                }
                else
                {
                    this.mainFolderBrowserDialog = new FolderBrowserDialog();
                    using (this.mainFolderBrowserDialog)
                    {
                        var result = this.mainFolderBrowserDialog.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(mainFolderBrowserDialog.SelectedPath))
                        {
                            this.DirString = mainFolderBrowserDialog.SelectedPath.ToString();
                            this.HasDir = true;
                            dirTextBox.Text = this.DirString;
                        }

                        // getting the images from the directory
                        int numOfImages = ImageDirLoading(this.DirString);

                        // setting the label
                        dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;

                        if (numOfImages > 0)
                        {
                            mainProgressBar.Maximum = numOfImages;
                            this.CurrentRowID = 0;
                            MainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }


        private void PrevButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if(this.CurrentRowID <= 0 || this.CurrentRowID >= this.ImageFilelist.Length - 1)
                {
                        this.CurrentRowID = this.ImageFilelist.Length - 1;
                    }
                    this.CurrentRowID--;
                    MainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                    mainProgressBar.Value = CurrentRowID;
                    this.Hasprocessed = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if (this.CurrentRowID >= this.ImageFilelist.Length - 1)
                    {
                        this.CurrentRowID = 0;
                    }
                    this.CurrentRowID++;
                    MainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                    mainProgressBar.Value = CurrentRowID;
                    this.Hasprocessed = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }
        /// <summary>
        /// initiallization of the Dataset obj for the main dataGridView
        /// </summary>
        public void InitDataset()
        {
            this.MainDataSet = new DataSet();
            this.MainTable = new DataTable();

            DataColumn rowid = new DataColumn("Row ID", typeof(int));
            DataColumn filename = new DataColumn("File Name");
            DataColumn numberofFaces = new DataColumn("Detected Face Number");
            DataColumn detectedfaces = new DataColumn("Detected Face(s)");

            this.MainTable.Columns.Add(rowid);
            this.MainTable.Columns.Add(filename);
            this.MainTable.Columns.Add(numberofFaces);
            this.MainTable.Columns.Add(detectedfaces);
            this.MainDataSet.Tables.Add(this.MainTable);

            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ReadOnly = true;

            mainDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mainDataGridView.AutoResizeColumns();

        }
        /// <summary>
        /// function updating the Dataset for both single and auto processing 
        /// </summary>
        /// <param name="rowData">ProcessedRowData obj </param>
        public void UpdateDataset(ProcessedRowData rowData)
        {
            DataRow dataRow = this.MainTable.NewRow();
            dataRow["Row ID"] = rowData.RowID.ToString();
            dataRow["File Name"] = rowData.FileName;
            dataRow["Detected Face Number"] = rowData.DetectFaceNumber.ToString();
            dataRow["Detected Face(s)"] = rowData.getSerializeRectforXML().ToString();

            this.MainTable.Rows.Add(dataRow);
            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ReadOnly = true;
        }



        private void DetectButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && !this.Hasprocessed && this.IsInitialized)
                {
                    this.CommonDetect();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }

        /// <summary>
        /// function for detection 
        /// </summary>
        private void CommonDetect()
        {

            int id = this.CurrentRowID;
            string filename = this.ImageFilelist[id];

            // getting the detected faces
            Rect[] faces = this.FaceDetector.GetDetectedFaces(filename);

            //making the row data
            ProcessedRowData data = new ProcessedRowData(id, filename, faces);

            //setting the images in picturebox
            MainPictureBoxImageSet(FaceDetector.GetFaceDetectedBitmapImage(filename));

            // adding the result in datagridview
            UpdateDataset(data);

            //updating UI
            this.Hasprocessed = true;
            mainProgressBar.Value = this.CurrentRowID;
            mainProgressBar.Update();
        }

        /// <summary>
        /// function for the detection of the data.
        /// </summary>
        /// <returns> bool for confrimation is the data was saved</returns>
        private bool SaveProgramState()
        {
            bool hasSaved = false;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "xml files (*.xml)|*.xml",
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    // making the savedata obj from the program and saving the serialized SaveData
                    SaveData saveData = new SaveData(this.HasDir, this.DirString, this.CurrentRowID, this.MainDataSet);

                    streamWriter.Write(saveData.ReturnSavedXML());
                    streamWriter.Close();
                    hasSaved = true;
                }

            }
            return hasSaved;
        }
        /// <summary>
        /// program loading fucntions
        /// </summary>
        /// <param name="saveData"></param>
        private void LoadProgramState(SaveData saveData)
        {
            this.MainDataSet = saveData.MainDataSet;
            this.MainTable = this.MainDataSet.Tables[0];
            this.Setup(saveData.HasDir, saveData.DirString, saveData.CurrentRowID);
            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.Refresh();
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if (SaveProgramState())
                    {
                        MessageBox.Show("Program Saved");

                    }
                    else
                    {
                        MessageBox.Show("Error Occoured");
                    }
                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }


        private void MainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (true) //TODO FIX THE CLICK FOR MAIN ROW
            {
                // getting the row id selected
                if (e.RowIndex >= 1)
                {
                    mainDataGridView.Rows[e.RowIndex].Selected = true;

                    if (string.IsNullOrWhiteSpace(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Please Click in the Cell Value Texts");
                    }
                    else
                    {
                        LoadingCellClickContent();
                    }
                }
            }


        }
        /// <summary>
        /// DatagridView click handling function
        /// </summary>
        private void LoadingCellClickContent()
        {

            //TODO fix form creation mode

            ProcessedRowData data = new ProcessedRowData
            {
                RowID = int.Parse(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString()),
                FileName = mainDataGridView.SelectedRows[0].Cells[1].Value.ToString()
            };
            data.Faces = data.setRectFromXML(mainDataGridView.SelectedRows[0].Cells[3].Value.ToString());
            data.DetectFaceNumber = int.Parse(mainDataGridView.SelectedRows[0].Cells[2].Value.ToString());
            MainPictureBoxImageSet(this.FaceDetector.MakeFaceDetectedImage(data.FileName, data.Faces));
            mainProgressBar.Value = data.RowID;

            if (Application.OpenForms.OfType<ImageDisplay>().Count() == 1)
            {
                Application.OpenForms.OfType<ImageDisplay>().First().Close();
            }

            ImageDisplay imageDisplayForm = new ImageDisplay();
            imageDisplayForm.MainPictureBoxImageSet(this.FaceDetector.MakeFaceDetectedImage(data.FileName, data.Faces));
            imageDisplayForm.Show();


        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                using (OpenFileDialog loadOpenFileDialog = new OpenFileDialog())
                {
                    loadOpenFileDialog.Filter = "XML files (*.xml)|*.xml";
                    loadOpenFileDialog.FilterIndex = 2;

                    if (loadOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        XmlSerializer reader = new XmlSerializer(typeof(SaveData));
                        StreamReader file = new StreamReader(loadOpenFileDialog.FileName);

                        try
                        {
                            SaveData saveData = (SaveData)reader.Deserialize(file);
                            LoadProgramState(saveData);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.ToString());
                        }
                        file.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }

        private void AutoDetectButton_Click(object sender, EventArgs e)
        {
            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if (!this.ThreadFlag)
                    {
                        processLabel.Text = "BackGround Processing";
                        mainProgressBar.Maximum = this.ImageFilelist.Length - 1;

                        // running the procces in background. 
                        autoProcessBackgroundWorker.RunWorkerAsync();
                        this.ThreadFlag = true;
                        autoDetectButton.Text = "Cancel";

                    }
                    else
                    {
                        processLabel.Text = "Process";
                        autoDetectButton.Text = "Auto Process";
                        // handling the cancellation for the process while running.
                        autoProcessBackgroundWorker.CancelAsync();
                        this.ThreadFlag = false;
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }

        private void AutoProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // autoprocessing main loop in the background work

            for (int i = 0; i < this.ImageFilelist.Length; i++)
            {
                this.CurrentRowID = i;
                string filename = this.ImageFilelist[this.CurrentRowID];
                Rect[] faces = this.FaceDetector.GetDetectedFaces(filename);
                ProcessedRowData data = new ProcessedRowData(this.CurrentRowID, filename, faces);
                autoProcessBackgroundWorker.ReportProgress(i, data);

                // adding thread waiting for CPU usage conservation.
                Thread.Sleep(200);

                if (autoProcessBackgroundWorker.CancellationPending)
                {
                    // handling cancel from button clicking
                    break;
                }

            }
        }

        private void AutoProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // updating UI from the background worker, sender ohject is from the AutoProcessBackgroundWorker_DoWork()
            mainProgressBar.Value = e.ProgressPercentage;
            ProcessedRowData rowData = (ProcessedRowData)e.UserState;
            this.UpdateDataset(rowData);
            mainProgressBar.Value = rowData.RowID;
            MainPictureBoxImageSet(this.FaceDetector.MakeFaceDetectedImage(rowData.FileName, rowData.Faces));

        }

        private void AutoProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            autoDetectButton.Text = "Auto Process";
            processLabel.Text = "Process";
        }

        // thread Button process
        private void ThreadProcessButton_Click(object sender, EventArgs e)
        {

            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if (!this.ThreadFlag)
                    {
                        threadProcessButton.Text = "Cancel";
                        this.MainThread = new Thread(StartThreadProcessing)
                        {
                            IsBackground = true
                        };

                        this.MainThread.Start();
                        this.ThreadFlag = true;
                        processLabel.Text = "Thread Processing";
                    }
                    else
                    {
                        threadProcessButton.Text = "Thread Process";
                        this.MainThread.Abort();
                        this.ThreadFlag = false;
                        processLabel.Text = "Process";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }
            }

        }

        /// <summary>
        /// Thread processing main loop fucntion
        /// </summary>
        private void StartThreadProcessing()
        {

            try
            {
                for (int i = 0; i < this.ImageFilelist.Length; i++)
                {
                    this.CurrentRowID = i;
                    string filename = this.ImageFilelist[this.CurrentRowID];
                    Rect[] faces = this.FaceDetector.GetDetectedFaces(filename);
                    ProcessedRowData data = new ProcessedRowData(this.CurrentRowID, filename, faces);

                    //invoking main delegate finction to update UI thread
                    this.Invoke(new UpDateDisplayImagesDelegate(UpDateDisplayImages), data);

                    // adding sleep to slow down for lesser cpu power load.
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                this.MainThread.Abort();
            }
        }


        /// <summary>
        /// delegate function to update UI from background thread 
        /// </summary>
        /// <param name="processedRowData"></param>
        private delegate void UpDateDisplayImagesDelegate(ProcessedRowData processedRowData);

        /// <summary>
        /// deligate calling function for update UI from background thread
        /// </summary>
        /// <param name="processedRowData"></param>
        private void UpDateDisplayImages(ProcessedRowData processedRowData)
        {
            mainProgressBar.Maximum = this.ImageFilelist.Length - 1;
            this.UpdateDataset(processedRowData);

            this.CurrentRowID = processedRowData.RowID;
            mainProgressBar.Value = processedRowData.RowID;
            MainPictureBoxImageSet(this.FaceDetector.MakeFaceDetectedImage(processedRowData.FileName, processedRowData.Faces));


            if (mainProgressBar.Value == mainProgressBar.Maximum)
            {
                threadProcessButton.Text = "Thread Process";
                processLabel.Text = "Process";
            }
        }

        private void TaskProcessButton_Click(object sender, EventArgs e)
        {
            
            this.MainAction = new Action(() =>
            {
                // task action will have the main loop, in the loop various invokes for updating the UI elements will be called


                for (int i = 0; i < this.ImageFilelist.Length; i++)
                {

                    if (this.MainCancellationToken.IsCancellationRequested)
                    {
                        this.MainCancellationTokenSource = new CancellationTokenSource();
                        this.MainCancellationToken = this.MainCancellationTokenSource.Token;
                        break;
                    }


                    // mainProgressBar
                    Action progressBarAction = new Action(() => 
                    {
                        this.CurrentRowID = i;
                        mainProgressBar.Value = i;
                    });

                    mainProgressBar.Invoke(progressBarAction);

                    //datagridView
                    this.CurrentRowID = i;
                    string filename = this.ImageFilelist[this.CurrentRowID];
                    Rect[] faces = this.FaceDetector.GetDetectedFaces(filename);
                    ProcessedRowData processedRowData = new ProcessedRowData(this.CurrentRowID, filename, faces);
                    
                    Action dataGridViewAction = new Action(() =>
                    {
                        this.UpdateDataset(processedRowData);
                    });
                    mainDataGridView.Invoke(dataGridViewAction);
                    //
                    Action pictureBoxSetAction = new Action(() =>
                    {
                        MainPictureBoxImageSet(this.FaceDetector.MakeFaceDetectedImage(processedRowData.FileName, processedRowData.Faces));
                    });
                    mainPictureBox.Invoke(pictureBoxSetAction);

                    //slowing down talk for less CPU load
                    Thread.Sleep(100);

                }

            });

            Monitor.Enter(this.ProcessLock, ref this.LockTaken);
            try
            {
                if (this.HasDir && this.IsInitialized)
                {
                    if (!this.ThreadFlag)
                    {
                        Task.Run(MainAction, MainCancellationToken);
                        this.ThreadFlag = true;
                        taskProcessbutton.Text = "Cancel";
                        processLabel.Text = "Task Processing";
                    }
                    else
                    {
                        taskProcessbutton.Text = "Task Process";
                        MainCancellationTokenSource.Cancel();
                        this.ThreadFlag = false;
                        processLabel.Text = "Process";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {
                if (this.LockTaken)
                {
                    Monitor.Exit(this.ProcessLock);
                    this.LockTaken = false;
                }

            }
        }


        private void Form1_ResizeEnd(Object sender, EventArgs e)
        {
            // resizing maindatagridview to hadle filling

            mainDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            mainDataGridView.AutoResizeColumns();

        }

        private void MainDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip.Show(mainDataGridView,new System.Drawing.Point(e.X,e.Y));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    CSVUtility.ToCSV(this.MainTable, saveFileDialog1.FileName.ToString());
                    MessageBox.Show("CSV Exported in " + saveFileDialog1.FileName.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
