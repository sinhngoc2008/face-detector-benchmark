using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XIsom.BigWatcher.Facefetection
{
    public partial class ImageDisplay : Form
    {
        private Image image;
        public ImageDisplay(Image image)
        {
            InitializeComponent();
            this.image = image;
            mainPictureBoxImageSet(this.image);
        }

        private void mainPictureBoxImageSet(Image image)
        {
            imageDisplayPictureBox.Image = image;
            imageDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void imageDisplayPictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
