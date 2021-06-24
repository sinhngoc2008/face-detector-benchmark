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
        public bool DoIExist;
        public ImageDisplay(Image image)
        {
            InitializeComponent();
            this.Image = image;
            this.DoIExist = true;
            mainPictureBoxImageSet(this.Image);
        }

        private void mainPictureBoxImageSet(Image image)
        {
            imageDisplayPictureBox.Image = image;
            imageDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void imageDisplayPictureBox_Click(object sender, EventArgs e)
        {
            this.DoIExist = false;
            this.Close();
        }
    }
}
