using System;
using System.Drawing;
using System.Windows.Forms;

namespace XIsom.BigWatcher.Facefetection
{
    /// <summary>
    /// Image display class UI for clicking the DataGridViewCell click
    /// </summary>
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
