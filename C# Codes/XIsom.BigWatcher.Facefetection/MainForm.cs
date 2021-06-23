using OpenCvSharp;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XIsom.BigWatcher.Facefetection
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
        private bool IsAutoprocessingStarted;
        private Thread MainThread;

        #endregion variables
        public MainForm()
        {
            InitializeComponent();

            //double buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //initial setup for the function call 
            this.setup(false,string.Empty,0);
            this.Hasprocessed = false;
            
            //initialization for the facedetector
            this.FaceDetector = new FaceDetector();

            //Autoprocessing Started flag set, buttons removing, Datagridview virtual mode for memory saving
            ShowHideButtons(false);
            mainDataGridView.VirtualMode = true;
            this.IsAutoprocessingStarted = false;
            
            // dataset initlization
            initDataset();

            //thread init
            this.MainThread = new Thread(StartThreadProcessing);
            this.MainThread.IsBackground = true;
        }

        /// <summary>
        /// an unified fuction to cluster all the prev, next, detect button visible, remove conditions
        /// </summary>
        /// <param name="value"> bool value for all buttons visibility </param>
        private void ShowHideButtons(bool value) {
            
            // the common buttons in the program to handle save/load/delete visibility
            
            prevButton.Visible = value;
            nextButton.Visible = value;
            detectButton.Visible = value;
            saveButton.Visible = value;
            autoDetectButton.Visible = value;
            threadProcessButton.Visible = value;
        }
        /// <summary>
        /// mainPictureBox Image set with the given file URL 
        /// </summary>
        /// <param name="filename"></param>
        private void mainPictureBoxImageSet(string filename) {
            mainPictureBox.Image = (Image) new Bitmap(filename);
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        ///  mainPictureBox Image set with the given Image obj of the Image
        /// </summary>
        /// <param name="image"></param>
        private void mainPictureBoxImageSet(Image image)
        {
            mainPictureBox.Image = image;
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// function to load all images (*.png || *.jpg) in the selected dir URL
        /// </summary>
        /// <param name="dirString"></param>
        /// <returns> number of totoal viable images in the dir</returns>
        private int imageDirLoading(string dirString){
            if (this.HasDir)
            {
                this.ImageFilelist = Directory.EnumerateFiles(dirString, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToArray();

                if (this.ImageFilelist.Length > 0)
                {
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
        private void setup(bool hasDir, string dirString, int currentRowID)
        {
            this.HasDir = hasDir;
            this.DirString = dirString;
            this.CurrentRowID = currentRowID;
            mainProgressBar.Minimum = 0;
            dirTextBox.Text = this.DirString;
            int numOfImages = imageDirLoading(this.DirString);


            dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;
            if (numOfImages > 0)
            {
                mainProgressBar.Maximum = numOfImages;
                this.CurrentRowID = 0;
                ShowHideButtons(true);
                mainPictureBoxImageSet(this.ImageFilelist[currentRowID]);
            }
            mainDataGridView.Update();
            mainProgressBar.Value = this.CurrentRowID;
        }

        private void dirButton_Click(object sender, EventArgs e)
        {
            // making the textbox checking
            if (!this.HasDir && (dirTextBox.Text.ToString() == String.Empty))
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
                }
            }
            else
            {
                if (Directory.Exists(dirTextBox.Text.ToString()))
                {
                    this.DirString = dirTextBox.Text.ToString();
                    this.HasDir = true;
                }
                else
                {
                    MessageBox.Show("Invalid Directory Path");
                    dirTextBox.Text = String.Empty;
                }

            }

            if (this.HasDir) 
            {
                // getting the images from the directory
                int numOfImages = imageDirLoading(this.DirString);

                // setting the label
                dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;

                if (numOfImages > 0)
                {
                    mainProgressBar.Maximum = numOfImages;
                    this.CurrentRowID = 0;
                    ShowHideButtons(true);
                    mainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
                }
            }
        }


        private void prevButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentRowID <= 0 || this.CurrentRowID >= this.ImageFilelist.Length - 1) {
                this.CurrentRowID = this.ImageFilelist.Length - 1;
            }
            this.CurrentRowID--;
            mainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
            mainProgressBar.Value = CurrentRowID;
            this.Hasprocessed = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentRowID >= this.ImageFilelist.Length - 1)
            {
                this.CurrentRowID = 0;
            }
            this.CurrentRowID++;
            mainPictureBoxImageSet(this.ImageFilelist[CurrentRowID]);
            mainProgressBar.Value = CurrentRowID;
            this.Hasprocessed = false;
        }
        /// <summary>
        /// initiallization of the Dataset obj for the main dataGridView
        /// </summary>
        public void initDataset()
        {
            this.MainDataSet = new DataSet();
            this.MainTable = new DataTable();

            DataColumn rowid = new DataColumn("Row ID");
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
            mainDataGridView.Refresh();
        }
        /// <summary>
        /// function updating the Dataset for both single and auto processing 
        /// </summary>
        /// <param name="rowData">ProcessedRowData obj </param>
        public void updateDataset(ProcessedRowData rowData)
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
            mainDataGridView.Update();
            mainDataGridView.Refresh();
        }



        private void detectButton_Click(object sender, EventArgs e)
        {
            if (this.HasDir && !this.Hasprocessed)
            {

                ShowHideButtons(false);
                this.commonDetect();
                ShowHideButtons(true);
            }
        }

        /// <summary>
        /// function for detection 
        /// </summary>
        private void commonDetect()
        {
            
            loadButton.Visible = false;
            int id = this.CurrentRowID;
            string filename = this.ImageFilelist[id];
            
            // getting the detected faces
            Rect[] faces = this.FaceDetector.getDetectedFaces(filename);
            
            //making the row data
            ProcessedRowData data = new ProcessedRowData(id, filename, faces);
            
            //setting the images in picturebox
            mainPictureBoxImageSet(FaceDetector.getFaceDetectedBitmapImage(filename));
            
            // adding the result in datagridview
            updateDataset(data);

            //updating UI
            this.Hasprocessed = true;
            loadButton.Visible = true;
            mainProgressBar.Value = this.CurrentRowID;
            mainProgressBar.Update();
        }

        /// <summary>
        /// function for the detection of the data.
        /// </summary>
        /// <returns> bool for confrimation is the data was saved</returns>
        private bool saveProgramState() 
        {
            bool hasSaved = false;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;

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
        private void loadProgramState(SaveData saveData)
        {
            loadButton.Visible = false;
            this.MainDataSet = saveData.MainDataSet;
            this.MainTable = this.MainDataSet.Tables[0];
            this.setup(saveData.HasDir, saveData.DirString, saveData.CurrentRowID);
            mainDataGridView.DataSource = this.MainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.Refresh();
            loadButton.Visible = true;
           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.HasDir)
            {
                ShowHideButtons(false);
                if (saveProgramState())
                {
                    MessageBox.Show("Program Saved");
                   
                }
                else
                {
                    MessageBox.Show("Error Occoured");
                }
                ShowHideButtons(true);
            }
        }


        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                ShowHideButtons(false);
                mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                
                // getting the row id selected
                mainDataGridView.Rows[e.RowIndex].Selected = true;

            if (string.IsNullOrWhiteSpace(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString()))
            {
                MessageBox.Show("Please Click in the Cell Value Texts");
            }
            else 
            {
                loadingCellClickContent();
            }
                
        }
        /// <summary>
        /// DatagridView click handling function
        /// </summary>
        private void loadingCellClickContent() 
        {
            ProcessedRowData data = new ProcessedRowData();
            data.RowID = int.Parse(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            data.FileName = mainDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            data.Faces = data.setRectFromXML(mainDataGridView.SelectedRows[0].Cells[3].Value.ToString());
            data.DetectFaceNumber = int.Parse(mainDataGridView.SelectedRows[0].Cells[2].Value.ToString());
            mainPictureBoxImageSet(this.FaceDetector.makeFaceDetectedImage(data.FileName, data.Faces));
            ShowHideButtons(true);
            mainDataGridView.Refresh();
            mainProgressBar.Value = data.RowID;
            ImageDisplay imageDisplayForm = new ImageDisplay(this.FaceDetector.makeFaceDetectedImage(data.FileName, data.Faces));
            imageDisplayForm.Show();
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            ShowHideButtons(false);

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
                        loadProgramState(saveData);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.ToString());
                    }
                    file.Close();
                }

            }
     
        }

        private void autoDetectButton_Click(object sender, EventArgs e)
        {
            loadButton.Visible = false;
           
            if (!this.IsAutoprocessingStarted)
            {
                ShowHideButtons(false);
                mainProgressBar.Maximum = this.ImageFilelist.Length - 1;
                
                // running the procces in background. 
                autoProcessBackgroundWorker.RunWorkerAsync();
                this.IsAutoprocessingStarted = true;
                autoDetectButton.Text = "Cancel";
                autoDetectButton.Visible = true;
            }
            else
            {
                autoDetectButton.Visible = false;
                autoDetectButton.Text = "Auto Process";
                autoDetectButton.Visible = true;

                // handling the cancellation for the process while running.
                autoProcessBackgroundWorker.CancelAsync();
                while (autoProcessBackgroundWorker.IsBusy)
                    Application.DoEvents();
                this.IsAutoprocessingStarted = false;
            }
        }

        private void autoProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // autoprocessing main loop in the background wokre
           
            for (int i = 0; i < this.ImageFilelist.Length; i++) 
            {
                this.CurrentRowID = i;
                string filename = this.ImageFilelist[this.CurrentRowID];
                Rect[] faces = this.FaceDetector.getDetectedFaces(filename);
                ProcessedRowData data = new ProcessedRowData(this.CurrentRowID, filename, faces);
                autoProcessBackgroundWorker.ReportProgress(i,data);
                
                // adding thread waiting for CPU usage conservation.
                Thread.Sleep(300);

                if (autoProcessBackgroundWorker.CancellationPending)
                {
                    // handling cancel from button clicking
                    break;
                }

            }
        }

        private void autoProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // updating UI from the background worker, sender ohject is from the autoProcessBackgroundWorker_DoWork()
            mainProgressBar.Value = e.ProgressPercentage;
            ProcessedRowData rowData = (ProcessedRowData) e.UserState;
            this.updateDataset(rowData);
            mainProgressBar.Value = rowData.RowID;
            mainPictureBoxImageSet(this.FaceDetector.makeFaceDetectedImage(rowData.FileName, rowData.Faces));
            mainDataGridView.Update();
            mainProgressBar.Update();
        }

        private void autoProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // showing the Messagebox UI for process complition. also show if cancelled.
            MessageBox.Show("Process Finished");
            loadButton.Visible = true;
            autoDetectButton.Text = "Auto Process";
            autoDetectButton.Visible = true;
            ShowHideButtons(true);
        }

        // thread Button process
        private void threadProcessButton_Click(object sender, EventArgs e)
        {
            ShowHideButtons(false);
            loadButton.Visible = false;
            this.MainThread.Start();
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
                    Rect[] faces = this.FaceDetector.getDetectedFaces(filename);
                    ProcessedRowData data = new ProcessedRowData(this.CurrentRowID, filename, faces);
                    
                    //invoking main delegate finction to update UI thread
                    this.Invoke(new UpDateDisplayImagesDelegate(UpDateDisplayImages), data);
                    
                    // adding sleep to slow down for lesser cpu power load.
                    Thread.Sleep(10);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                this.MainThread.Abort();
                return;
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
            this.updateDataset(processedRowData);
            mainDataGridView.Update();
            mainProgressBar.Update();
            this.CurrentRowID = processedRowData.RowID;
            mainProgressBar.Value = processedRowData.RowID;
            mainPictureBoxImageSet(this.FaceDetector.makeFaceDetectedImage(processedRowData.FileName, processedRowData.Faces));
            
            mainDataGridView.Refresh();
            mainProgressBar.Update();
            
            if (mainProgressBar.Value == mainProgressBar.Maximum)
            {
                autoDetectButton.Visible = true;
                ShowHideButtons(true);
                loadButton.Visible = true;
                threadProcessButton.Visible = true;
            }
        }

    
    }
}
