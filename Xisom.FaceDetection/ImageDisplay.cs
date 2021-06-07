using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Xisom.FaceDetection
{
    public partial class ImageDisplay : Form
    {
        private string filename;
        private ListedFaces listedFaces;
        private Bitmap image;
        public ImageDisplay()
        {
            InitializeComponent();
        }

        public ImageDisplay(string filename,ListedFaces listedFaces)
        {
            InitializeComponent();
            this.listedFaces = listedFaces;
            this.filename = filename;

            var dst = new Mat(this.filename, ImreadModes.Color);

            for (int i = 0; i < listedFaces.faces.Count; i++)
            {
                Cv2.Rectangle(dst, listedFaces.faces[i], Scalar.White, 3);
            }

            this.image = BitmapConverter.ToBitmap(dst);
            displayPictureBox.Image = (Image)image;
            displayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileNameLabel.Text = this.filename;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileNameLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
