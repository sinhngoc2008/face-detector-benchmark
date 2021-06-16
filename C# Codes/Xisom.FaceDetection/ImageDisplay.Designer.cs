
namespace Xisom.FaceDetection
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
            this.displayPictureBox = new System.Windows.Forms.PictureBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPictureBox
            // 
            this.displayPictureBox.Location = new System.Drawing.Point(8, 0);
            this.displayPictureBox.Name = "displayPictureBox";
            this.displayPictureBox.Size = new System.Drawing.Size(780, 418);
            this.displayPictureBox.TabIndex = 0;
            this.displayPictureBox.TabStop = false;
            this.displayPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 440);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(113, 15);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "Image FIle Name";
            this.fileNameLabel.Click += new System.EventHandler(this.fileNameLabel_Click);
            // 
            // ImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.displayPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageDisplay";
            this.Text = "Image Display";
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox displayPictureBox;
        private System.Windows.Forms.Label fileNameLabel;
    }
}