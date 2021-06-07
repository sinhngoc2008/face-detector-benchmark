using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace FaceDetector.OpenCvSharp
{
    public partial class FaceDetecotor : Form
    {
        private bool hasFile;
        public string fileName;
        private OpenFileDialog openFileDialog;
        private OpenFileDialog loadOpenFileDialog;
        public Bitmap image;
        private List<Rect> faceList;
        private Rect[] faces;
        

        public FaceDetecotor()
        {
            InitializeComponent();
            GC.Collect(2, GCCollectionMode.Optimized);
            this.hasFile = false;
            this.fileName = string.Empty;
            detectButton.Visible = false;
            saveButton.Visible = false;
            this.faces = null;
            this.faceList = new List<Rect>();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            //openFIle Button
            using (this.openFileDialog = new OpenFileDialog())
            {
                this.openFileDialog.InitialDirectory = @"C:\users\";
                this.openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                this.openFileDialog.FilterIndex = 2;
                this.openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.fileName = openFileDialog.FileName;

                    //Read the images put in picturebox
                    this.image = new Bitmap(this.fileName);
                    fileNameTextBox.Text = this.fileName;
                    mainPictureBox.Image = (Image)image;
                    mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    detectButton.Visible = true;
                    //loadButton.Visible = false;
                }
            }

        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            if (!this.hasFile && !this.fileName.Equals(string.Empty))
            {
                if (this.faceList.Count >= 1)
                {
                    string faceInfo = string.Join(", ", this.faceList.ToArray());
                    MessageBox.Show("Image Height: " + this.image.Height.ToString() + "Image Width" + this.image.Width.ToString()+ " Face_list: "+faceInfo);
                }
                else {
                    MessageBox.Show("Image Height: " + this.image.Height.ToString() + "Image Width" + this.image.Width.ToString());
                }
                
            }
        }

        private void detectButton_Click(object sender, EventArgs e)
        {
            var src = new Mat(this.fileName, ImreadModes.Grayscale);
            var dst = new Mat(this.fileName, ImreadModes.Color);
            CascadeClassifier haarCascadeClassifier = new CascadeClassifier(@"C:\Users\user\Dataset\wider_face_yolo\benchmark\tester\C#\TraningProgramming\Xisom.FaceDetection\FaceDetector.OpenCvSharp\Resources\haarcascade_frontalface_default.xml");

            // optimizing the var later for optimal performance

            this.faces = haarCascadeClassifier.DetectMultiScale(src,1.1,5);
            
            if (this.faces.Length > 0)
            {
                this.faceList = new List<Rect>();
                for (int i = 0; i < faces.Length; i++)
                {
                    Cv2.Rectangle(dst, faces[i], Scalar.White, 3);
                    this.faceList.Add(faces[i]);
                }

                this.image = BitmapConverter.ToBitmap(dst);
                mainPictureBox.Image = (Image)image;
                mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                saveButton.Visible = true;
            }
            else 
            {
                MessageBox.Show("No Face Detected in file "+this.fileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName !=string.Empty)
            {
                using (StreamWriter wr = new StreamWriter(saveFileDialog1.FileName))
                {
                    // saving xml
                    ListedFaces listedFaces = new ListedFaces(this.fileName, this.faceList);
                    wr.Write(ListedFaces.SerializeObject(listedFaces));
                    wr.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // load button for loading xml onto the face and display in the picture button. 
            using (this.loadOpenFileDialog = new OpenFileDialog()) 
            {
                this.loadOpenFileDialog.InitialDirectory = @"C:\users\";
                this.loadOpenFileDialog.Filter = "XML files (*.xml)|*.xml";
                this.loadOpenFileDialog.FilterIndex = 2;
                this.loadOpenFileDialog.RestoreDirectory = true;

                if (loadOpenFileDialog.ShowDialog() == DialogResult.OK) {
                    
                    
                    
                    XmlSerializer reader = new XmlSerializer(typeof(ListedFaces));
                    StreamReader file = new StreamReader(this.loadOpenFileDialog.FileName);
                    ListedFaces listedFaces = (ListedFaces)reader.Deserialize(file);
                    
                    this.fileName = listedFaces.fileName;

                    try
                    {
                        var dst = new Mat(this.fileName, ImreadModes.Color);
                        this.faceList = listedFaces.faces;
                        for (int i = 0; i < listedFaces.faces.Count; i++)
                        {
                            Cv2.Rectangle(dst, listedFaces.faces[i], Scalar.White, 3);
                        }

                        this.image = BitmapConverter.ToBitmap(dst);
                        mainPictureBox.Image = (Image)image;
                        mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch {
                        MessageBox.Show("image File not found");
                    }

                }
            }
        }
    }
    
}