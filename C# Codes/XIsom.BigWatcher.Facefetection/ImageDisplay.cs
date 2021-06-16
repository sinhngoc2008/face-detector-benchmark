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
    /// <summary>
    /// Image display class UI for clicking the DataGridViewCell click
    /// </summary>
    public partial class ImageDisplay : Form
    {
        private Image Image;
        public ImageDisplay(Image image)
        {
            InitializeComponent();
            this.Image = image;
            mainPictureBoxImageSet(this.Image);
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
