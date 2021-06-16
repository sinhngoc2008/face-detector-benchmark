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
        private bool hasDir;
        private string dirString;
        private string[] imageFilelist;
        private int currentRowID;
        private FolderBrowserDialog mainFolderBrowserDialog;
        private DataSet mainDataSet;
        private DataTable maintable;
        private bool hasprocessed;
        private FaceDetector faceDetector;
        private bool isAutoprocessingStarted;
        public MainForm()
        {
            InitializeComponent();
            GC.Collect(2, GCCollectionMode.Optimized);

            this.setup(false,string.Empty,0);
            this.hasprocessed = false;
            this.faceDetector = new FaceDetector();
            imageDirBrowsingButtonLoading(false);
            mainDataGridView.VirtualMode = true;
            this.isAutoprocessingStarted = false;
            initDataset();



        }

        /// <summary>
        /// an unified fuction to cluster all the prev, next, detect button visible, remove conditions
        /// </summary>
        /// <param name="value"> bool value for all buttons visibility </param>
        private void imageDirBrowsingButtonLoading(bool value) {
            
            // the common buttons in the program to handle save/load/delete visibility
            
            prevButton.Visible = value;
            nextButton.Visible = value;
            detectButton.Visible = value;
            saveButton.Visible = value;
            autoDetectButton.Visible = value;
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
        ///  mainPictureBox Image set with the given Image obj of the image
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
        /// <returns></returns>
        private int imageDirLoading(string dirString){
            if (this.hasDir)
            {
                this.imageFilelist = Directory.EnumerateFiles(dirString, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToArray();

                if (this.imageFilelist.Length > 0)
                {
                    return this.imageFilelist.Length;
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
            this.hasDir = hasDir;
            this.dirString = dirString;
            this.currentRowID = currentRowID;
            mainProgressBar.Minimum = 0;
            dirTextBox.Text = this.dirString;
            int numOfImages = imageDirLoading(this.dirString);


            dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;
            if (numOfImages > 0)
            {
                mainProgressBar.Maximum = numOfImages;
                this.currentRowID = 0;
                imageDirBrowsingButtonLoading(true);
                mainPictureBoxImageSet(this.imageFilelist[currentRowID]);
            }
            mainDataGridView.Update();
            mainProgressBar.Value = this.currentRowID;
        }

        private void dirButton_Click(object sender, EventArgs e)
        {
            this.mainFolderBrowserDialog = new FolderBrowserDialog();
            using (this.mainFolderBrowserDialog) 
            {
                 var result = this.mainFolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(mainFolderBrowserDialog.SelectedPath))
                {
                    this.dirString = mainFolderBrowserDialog.SelectedPath.ToString();
                    this.hasDir = true;
                    dirTextBox.Text = this.dirString;
                }
            }
            int numOfImages = imageDirLoading(this.dirString);
           
            dirImgCountLabel.Text = "IMG COUNT: " + numOfImages;
            if (numOfImages > 0) {
                mainProgressBar.Maximum = numOfImages;
                this.currentRowID = 0;
                imageDirBrowsingButtonLoading(true);
                mainPictureBoxImageSet(this.imageFilelist[currentRowID]);
            }
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            if (this.hasDir && (this.imageFilelist.Length > 0))
            { 
               // implimented later for click based info showing. 

            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (this.currentRowID <= 0 || this.currentRowID >= this.imageFilelist.Length - 1) {
                this.currentRowID = this.imageFilelist.Length - 1;
            }
            this.currentRowID--;
            mainPictureBoxImageSet(this.imageFilelist[currentRowID]);
            mainProgressBar.Value = currentRowID;
            this.hasprocessed = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (this.currentRowID >= this.imageFilelist.Length - 1)
            {
                this.currentRowID = 0;
            }
            this.currentRowID++;
            mainPictureBoxImageSet(this.imageFilelist[currentRowID]);
            mainProgressBar.Value = currentRowID;
            this.hasprocessed = false;
        }
        /// <summary>
        /// initiallization of the Dataset obj for the main dataGridView
        /// </summary>
        public void initDataset()
        {
            this.mainDataSet = new DataSet();
            this.maintable = new DataTable();

            DataColumn rowid = new DataColumn("Row ID");
            DataColumn filename = new DataColumn("File Name");
            DataColumn numberofFaces = new DataColumn("Detected Face Number");
            DataColumn detectedfaces = new DataColumn("Detected Face(s)");

            this.maintable.Columns.Add(rowid);
            this.maintable.Columns.Add(filename);
            this.maintable.Columns.Add(numberofFaces);
            this.maintable.Columns.Add(detectedfaces);
            this.mainDataSet.Tables.Add(this.maintable);
            
            mainDataGridView.DataSource = this.mainDataSet.Tables[0];
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
            DataRow dataRow = this.maintable.NewRow();
            dataRow["Row ID"] = rowData.RowID.ToString();
            dataRow["File Name"] = rowData.FileName;
            dataRow["Detected Face Number"] = rowData.DetectFaceNumber.ToString();
            dataRow["Detected Face(s)"] = rowData.getSerializeRectforXML().ToString();

            this.maintable.Rows.Add(dataRow);
            mainDataGridView.DataSource = this.mainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ReadOnly = true;
            mainDataGridView.Update();
            mainDataGridView.Refresh();
        }



        private void detectButton_Click(object sender, EventArgs e)
        {
            if (this.hasDir && !this.hasprocessed)
            {

                imageDirBrowsingButtonLoading(false);
                this.commonDetect();
                imageDirBrowsingButtonLoading(true);
            }
        }

        /// <summary>
        /// function for detection 
        /// </summary>
        private void commonDetect()
        {
            
            loadButton.Visible = false;
            int id = this.currentRowID;
            string filename = this.imageFilelist[id];
            Rect[] faces = this.faceDetector.getDetectedFaces(filename);
            ProcessedRowData data = new ProcessedRowData(id, filename, faces);
            mainPictureBoxImageSet(faceDetector.getFaceDetectedBitmapImage(filename));
            updateDataset(data);
            this.hasprocessed = true;
            loadButton.Visible = true;
            mainProgressBar.Value = this.currentRowID;
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

                    SaveData saveData = new SaveData(this.hasDir, this.dirString, this.currentRowID, this.mainDataSet);

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
            this.mainDataSet = saveData.MainDataSet;
            this.maintable = this.mainDataSet.Tables[0];
            this.setup(saveData.HasDir, saveData.DirString, saveData.CurrentRowID);
            mainDataGridView.DataSource = this.mainDataSet.Tables[0];
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.Refresh();
            loadButton.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.hasDir)
            {
                imageDirBrowsingButtonLoading(false);
                if (saveProgramState())
                {
                    MessageBox.Show("Program Saved");
                   
                }
                else
                {
                    MessageBox.Show("Error Occoured");
                }
                imageDirBrowsingButtonLoading(true);
            }
        }


        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                imageDirBrowsingButtonLoading(false);

                mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            mainPictureBoxImageSet(this.faceDetector.makeFaceDetectedImage(data.FileName, data.Faces));
            imageDirBrowsingButtonLoading(true);
            mainDataGridView.Refresh();
            mainProgressBar.Value = data.RowID;
            ImageDisplay imageDisplayForm = new ImageDisplay(this.faceDetector.makeFaceDetectedImage(data.FileName, data.Faces));
            imageDisplayForm.Show();
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            imageDirBrowsingButtonLoading(false);

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
           
            if (!this.isAutoprocessingStarted)
            {
                imageDirBrowsingButtonLoading(false);
                mainProgressBar.Maximum = this.imageFilelist.Length - 1;
                autoProcessBackgroundWorker.RunWorkerAsync();
                this.isAutoprocessingStarted = true;
                autoDetectButton.Text = "Cancel";
                autoDetectButton.Visible = true;
            }
            else
            {
                autoDetectButton.Visible = false;
                autoDetectButton.Text = "Auto Process";
                autoDetectButton.Visible = true;
                autoProcessBackgroundWorker.CancelAsync();
                
                while (autoProcessBackgroundWorker.IsBusy)
                    Application.DoEvents();
                this.isAutoprocessingStarted = false;
            }
        }

        private void autoProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
           
            for (int i = 0; i < this.imageFilelist.Length; i++) 
            {
                this.currentRowID = i;
                string filename = this.imageFilelist[this.currentRowID];
                Rect[] faces = this.faceDetector.getDetectedFaces(filename);
                ProcessedRowData data = new ProcessedRowData(this.currentRowID, filename, faces);
                autoProcessBackgroundWorker.ReportProgress(i,data);
                Thread.Sleep(100);

                if (autoProcessBackgroundWorker.CancellationPending)
                {
                    break;
                }

            }
        }

        private void autoProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mainProgressBar.Value = e.ProgressPercentage;
            ProcessedRowData rowData = (ProcessedRowData) e.UserState;
            this.updateDataset(rowData);
            mainDataGridView.Update();
            mainProgressBar.Update();
        }

        private void autoProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Process Finished");
            loadButton.Visible = true;
            autoDetectButton.Text = "Auto Process";
            autoDetectButton.Visible = true;
            imageDirBrowsingButtonLoading(true);
        }

    }
}
