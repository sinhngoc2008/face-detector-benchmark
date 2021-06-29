
namespace Xisom.ReDesigned.FaceDetector
{
    partial class ImageDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDisplay));
            this.imageDisplayPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageDisplayPictureBox
            // 
            this.imageDisplayPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageDisplayPictureBox.Location = new System.Drawing.Point(4, 3);
            this.imageDisplayPictureBox.Name = "imageDisplayPictureBox";
            this.imageDisplayPictureBox.Size = new System.Drawing.Size(794, 446);
            this.imageDisplayPictureBox.TabIndex = 0;
            this.imageDisplayPictureBox.TabStop = false;
            this.imageDisplayPictureBox.Click += new System.EventHandler(this.ImageDisplayPictureBox_Click);
            // 
            // ImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imageDisplayPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageDisplay";
            this.Text = "Image Display";
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplayPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageDisplayPictureBox;
    }
}