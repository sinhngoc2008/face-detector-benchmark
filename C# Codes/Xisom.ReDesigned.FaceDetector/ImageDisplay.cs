using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xisom.ReDesigned.FaceDetector
{
    public partial class ImageDisplay : Form
    {
        private Image Image;
       
        public ImageDisplay(Image image)
        {
            InitializeComponent();
            this.Image = image;
            MainPictureBoxImageSet(this.Image);
        }

        public ImageDisplay()
        {
            InitializeComponent();
        }

        public void MainPictureBoxImageSet(Image image)
        {
            imageDisplayPictureBox.Image = image;
            imageDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ImageDisplayPictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
