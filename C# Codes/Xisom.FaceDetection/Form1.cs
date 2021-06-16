using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using System.Collections.Generic;
using OpenCvSharp.Extensions;
using System.Xml.Serialization;
using System.Data;
using System.Threading;

namespace Xisom.FaceDetection
{
    public partial class FaceDetector : Form
    {
        public bool selectFolderFlag;
        public bool hasFileList;
        public string[] fileList;
        public int imageID;
        public string dirString;
        public Bitmap image;
        private readonly CommonOpenFileDialog dialog = new CommonOpenFileDialog();
        private bool hasProcessed;
        private bool processButtonFlag;
        private ListedFaces processedListedface;
        private OpenFileDialog loadOpenFileDialog;
        private string fileName;
        public DataSet gridDataset;
        public DataTable gridDataTable;

        //autoplay button variable

        private bool autoPlayButtonActive;
        private bool pressPauseButton;
        private int autoProcessIdx;

        public FaceDetector()
        {
            InitializeComponent();
            GC.Collect(2, GCCollectionMode.Optimized);
            dialog.InitialDirectory = @"C:\\Users";
            dialog.IsFolderPicker = true;
            this.selectFolderFlag = false;
            this.hasFileList = false;
            this.hasProcessed = false;
            processButton.Visible = false;
            saveButton.Visible = false;
            this.processButtonFlag = false;
            this.fileName = string.Empty;
            autoProcess.Visible = false;
            pauseButton.Visible = false;
            pauseButton.Visible = false;
            this.autoPlayButtonActive = false;
            this.pressPauseButton = false ;
            this.autoProcessIdx = 0;
        }

        private void FaceDetector_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !this.selectFolderFlag)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
                this.selectFolderFlag = true;
            }


            if (this.selectFolderFlag)
            {
                textBox1.Text = dialog.FileName.ToString();
                this.dirString = dialog.FileName.ToString() + @"\\";

                this.fileList = Directory.GetFiles(dirString, "*.jpg", SearchOption.AllDirectories);
                label2.Text = @"Total Image in the Dir. is " + this.fileList.Length;
                this.selectFolderFlag = false;

                this.imageID = 0;
                label3.Text = "Image Count: " + this.imageID;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = this.fileList.Length;
                progressBar1.Value = imageID;
                this.image = new Bitmap(this.fileList[imageID]);
                pictureBox1.Image = (Image)image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                processButton.Visible = true;
                this.processButtonFlag = true;
                button7.Visible = true;

                this.gridDataset = new DataSet();
                this.gridDataTable = new DataTable();

                DataColumn imageNUmber = new DataColumn("ID");
                DataColumn gridImageName = new DataColumn("File Information");
                DataColumn gridFace = new DataColumn("Face(s)");

                this.gridDataTable.Columns.Add(imageNUmber);
                this.gridDataTable.Columns.Add(gridImageName);
                this.gridDataTable.Columns.Add(gridFace);

                this.gridDataset.Tables.Add(this.gridDataTable);

                dataGridView1.DataSource = this.gridDataset.Tables[0];

                autoProcess.Visible = true;
                pauseButton.Visible = true;

            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //button1.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Prev button
            if (imageID <= 0 || imageID >= this.fileList.Length) { imageID = this.fileList.Length; }
            imageID--;
            label3.Text = "Image Count: " + this.imageID;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = this.fileList.Length;
            progressBar1.Value = imageID;
            this.image = new Bitmap(this.fileList[imageID]);
            pictureBox1.Image = (Image)image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.processButtonFlag = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Next button
            if (imageID >= this.fileList.Length - 1) { imageID = 0; }
            imageID++;
            label3.Text = "Image Count: " + this.imageID;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = this.fileList.Length;
            progressBar1.Value = imageID;
            
            
            
            this.image = new Bitmap(this.fileList[imageID]);
            pictureBox1.Image = (Image)image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.processButtonFlag = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //image process start (process Button)

            if (this.processButtonFlag)
            {
               
                CascadeClassifier haarCascadeClassifier = new CascadeClassifier(@"C:\Users\user\Dataset\wider_face_yolo\benchmark\tester\C#\TraningProgramming\Xisom.FaceDetection\FaceDetector.OpenCvSharp\Resources\haarcascade_frontalface_default.xml");
                // adding all filelist to to the datagridview
                List<Rect> faceList = new List<Rect>();
                var src = new Mat(this.fileList[this.imageID], ImreadModes.Grayscale);
                var dst = new Mat(this.fileList[this.imageID], ImreadModes.Color);
                Rect[] faces = haarCascadeClassifier.DetectMultiScale(src, 1.1, 5);

                 if (faces.Length > 0)
                 {
                      for(int i=0;i<faces.Length;i++)
                       {
                            faceList.Add(faces[i]);
                            Cv2.Rectangle(dst, faces[i], Scalar.White, 3);
                    }
                 }

                this.image = BitmapConverter.ToBitmap(dst);
                pictureBox1.Image = (Image)image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.processedListedface = new ListedFaces(faceList);

                //datagridview add and parse to dataset;

                DataRow dataRow = this.gridDataTable.NewRow();
                dataRow["ID"] = this.imageID.ToString();
                dataRow["File Information"] = this.fileList[this.imageID].ToString();
                dataRow["Face(s)"] = (this.processedListedface.SerializeObject());

                this.gridDataTable.Rows.Add(dataRow);

                dataGridView1.AutoSize = true;
                dataGridView1.DataSource = this.gridDataset.Tables[0];

                this.processButtonFlag = false;
              if (!this.hasProcessed)
               {
                  this.hasProcessed = true;
               }
                saveButton.Visible = true;
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // showing the data as a new form
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                this.fileName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.imageID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                this.image = new Bitmap(this.fileList[imageID]);
                var dst = new Mat(this.fileList[this.imageID], ImreadModes.Color);

                XmlSerializer reader = new XmlSerializer(typeof(ListedFaces));
                string faceData = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                ListedFaces listedFaces = (ListedFaces) reader.Deserialize(new StringReader(faceData));
                
                try
                {
                    this.processedListedface = listedFaces;
                    for (int i = 0; i < listedFaces.faces.Count; i++)
                    {
                        Cv2.Rectangle(dst, listedFaces.faces[i], Scalar.White, 3);
                    }

                    this.image = BitmapConverter.ToBitmap(dst);
                    pictureBox1.Image = (Image)image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    MessageBox.Show("image File not found");
                }
                progressBar1.Value = this.imageID;
                label3.Text = "Image Count " + this.imageID;

                Form imagedisplay = new ImageDisplay(this.fileName,listedFaces);
                imagedisplay.Show();

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current Images: " + progressBar1.Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //picture box info
            if (!this.image.Equals(null))
            {
                string info = "Height : " + this.image.Height + ", Width: " + this.image.Width;
                MessageBox.Show(info);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //save button

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                using (StreamWriter wr = new StreamWriter(saveFileDialog1.FileName))
                {
                    SaveStateData saveStateData = new SaveStateData(this.selectFolderFlag,this.dirString,this.gridDataset,progressBar1.Value);
                    
                    wr.Write(saveStateData.SerializeObject()); 
                    wr.Close();
                }

            }

        }   



        private void button7_Click(object sender, EventArgs e)
        {
            //load Button
            using (this.loadOpenFileDialog = new OpenFileDialog())
            {
                this.loadOpenFileDialog.Filter = "XML files (*.xml)|*.xml";
                this.loadOpenFileDialog.FilterIndex = 2;

                if (loadOpenFileDialog.ShowDialog() == DialogResult.OK)
                {

                    XmlSerializer reader = new XmlSerializer(typeof(SaveStateData));
                    StreamReader file = new StreamReader(this.loadOpenFileDialog.FileName);

                    try
                    {
                        SaveStateData saveStateData = (SaveStateData)reader.Deserialize(file);
                        this.selectFolderFlag = saveStateData.hasFolder;
                        textBox1.Text = saveStateData.folderDir.ToString();
                        this.dirString = saveStateData.folderDir.ToString();
                        this.fileList = Directory.GetFiles(dirString, "*.jpg", SearchOption.AllDirectories);
                        label2.Text = @"Total Image in the Dir. is " + this.fileList.Length;
                        this.selectFolderFlag = false;

                        this.imageID = saveStateData.progressCount;
                        label3.Text = "Image Count: " + this.imageID;
                        progressBar1.Value = imageID;
                        this.image = new Bitmap(this.fileList[imageID]);
                        pictureBox1.Image = (Image)image;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        processButton.Visible = true;
                        this.processButtonFlag = true;
                        this.gridDataset = saveStateData.dataset;
                        this.gridDataTable = this.gridDataset.Tables[0];
                        dataGridView1.AutoSize = true;
                        dataGridView1.DataSource = this.gridDataset.Tables[0];
                        
                    }
                    catch {
                        MessageBox.Show("File is corrupted..");
                    }
                    file.Close();
                }
            }



        }

        private void autoProcess_Click(object sender, EventArgs e)
        {
            autoProcess.Visible = false;
            pauseButton.Visible = true;
            this.autoPlayButtonActive = true;
            this.pressPauseButton = false; ;
            processButton.Visible = false;
            saveButton.Visible = false;


            for (int k = 0; k < this.fileList.Length; k++) {
                this.imageID = k;
                if (this.pressPauseButton) {
                    this.autoPlayButtonActive = false;
                    this.autoProcessIdx = k;
                    break;
                }
                if (this.autoProcessIdx !=0) { k = autoProcessIdx; }
                CascadeClassifier haarCascadeClassifier = new CascadeClassifier(@"C:\Users\user\Dataset\wider_face_yolo\benchmark\tester\C#\TraningProgramming\Xisom.FaceDetection\FaceDetector.OpenCvSharp\Resources\haarcascade_frontalface_default.xml");
                // adding all filelist to to the datagridview
                List<Rect> faceList = new List<Rect>();
                var src = new Mat(this.fileList[this.imageID], ImreadModes.Grayscale);
                var dst = new Mat(this.fileList[this.imageID], ImreadModes.Color);
                Rect[] faces = haarCascadeClassifier.DetectMultiScale(src, 1.1, 5);

                if (faces.Length > 0)
                {
                    for (int i = 0; i < faces.Length; i++)
                    {
                        faceList.Add(faces[i]);
                        Cv2.Rectangle(dst, faces[i], Scalar.White, 3);
                    }
                }

                this.image = BitmapConverter.ToBitmap(dst);
                pictureBox1.Image = (Image)image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.processedListedface = new ListedFaces(faceList);
                progressBar1.Value = this.imageID;
                //datagridview add and parse to dataset;

                DataRow dataRow = this.gridDataTable.NewRow();
                dataRow["ID"] = this.imageID.ToString();
                dataRow["File Information"] = this.fileList[this.imageID].ToString();
                dataRow["Face(s)"] = (this.processedListedface.SerializeObject());
                this.gridDataTable.Rows.Add(dataRow);
                label3.Text = "Image Count: " + this.imageID;
                Thread.Sleep(300);
                if (this.autoPlayButtonActive) { 
                 //impliment todo??
                }
            }

           

            dataGridView1.DataSource = this.gridDataset.Tables[0];

            this.processButtonFlag = true;
            saveButton.Visible = true;
            autoProcess.Visible = true;
            this.pressPauseButton = false;
            processButton.Visible = true;
        }


        

        private void pauseButton_Click(object sender, EventArgs e)
        {
            
            autoProcess.Visible = true;
            this.pressPauseButton = true;
            processButton.Visible = true;


        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }
    }
}
