using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        public MainForm()
        {
            InitializeComponent();
            GC.Collect(2, GCCollectionMode.Optimized);
            this.hasDir = false;
            this.dirString = string.Empty;
            this.mainFolderBrowserDialog = new FolderBrowserDialog();
            this.imageFilelist = null;
            this.currentRowID = 0;
            this.mainProgressBar.Minimum = 0;
            this.hasprocessed = false;
            imageDirBrowsingButtonLoading(false);
            initDataset();
        }

        private void imageDirBrowsingButtonLoading(bool value) {
            prevButton.Visible = value;
            nextButton.Visible = value;
            detectButton.Visible = value;
        
        }

        private void mainPictureBoxImageSet(string filename) {
            mainPictureBox.Image = (Image) new Bitmap(filename);
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void mainPictureBoxImageSet(Image image)
        {
            mainPictureBox.Image = image;
            mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
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

        private void dirButton_Click(object sender, EventArgs e)
        {
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
            //MessageBox.Show(numOfImages);
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
            mainDataGridView.AutoSize = false;
            mainDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            mainDataGridView.DataSource = this.mainDataSet.Tables[0];
        }

        public void updateDataset(ProcessedRowData rowData)
        {
            DataRow dataRow = this.maintable.NewRow();
            dataRow["Row ID"] = rowData.rowID.ToString();
            dataRow["File Name"] = rowData.fileName;
            dataRow["Detected Face Number"] = rowData.detectFaceNumber.ToString();
            dataRow["Detected Face(s)"] = rowData.faces.ToList();

            this.maintable.Rows.Add(dataRow);
            mainDataGridView.DataSource = this.mainDataSet.Tables[0];
        }



        private void detectButton_Click(object sender, EventArgs e)
        {
            if (this.hasDir && !this.hasprocessed)
            {
                int id = this.currentRowID;
                string filename = this.imageFilelist[id];
                ProcessedRowData data = new ProcessedRowData(id,filename);
                mainPictureBoxImageSet(data.getImage());
                updateDataset(data);
                this.hasprocessed = true;
            }
        }
    }
}
