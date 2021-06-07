
namespace XIsom.BigWatcher.Facefetection
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.dirButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.dirImgCountLabel = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.detectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dirTextBox
            // 
            this.dirTextBox.Location = new System.Drawing.Point(16, 9);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.Size = new System.Drawing.Size(624, 25);
            this.dirTextBox.TabIndex = 0;
            // 
            // dirButton
            // 
            this.dirButton.Location = new System.Drawing.Point(647, 6);
            this.dirButton.Name = "dirButton";
            this.dirButton.Size = new System.Drawing.Size(176, 32);
            this.dirButton.TabIndex = 1;
            this.dirButton.Text = "Browse";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(17, 44);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(702, 399);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // dirImgCountLabel
            // 
            this.dirImgCountLabel.AutoSize = true;
            this.dirImgCountLabel.Location = new System.Drawing.Point(725, 44);
            this.dirImgCountLabel.Name = "dirImgCountLabel";
            this.dirImgCountLabel.Size = new System.Drawing.Size(98, 20);
            this.dirImgCountLabel.TabIndex = 3;
            this.dirImgCountLabel.Text = "Total Images";
            this.dirImgCountLabel.UseCompatibleTextRendering = true;
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(729, 75);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(41, 31);
            this.prevButton.TabIndex = 4;
            this.prevButton.Text = "<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(776, 75);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(41, 31);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Location = new System.Drawing.Point(17, 449);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(702, 23);
            this.mainProgressBar.TabIndex = 6;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowDrop = true;
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToResizeColumns = false;
            this.mainDataGridView.AllowUserToResizeRows = false;
            this.mainDataGridView.ColumnHeadersHeight = 29;
            this.mainDataGridView.Location = new System.Drawing.Point(833, 9);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 27;
            this.mainDataGridView.Size = new System.Drawing.Size(396, 462);
            this.mainDataGridView.TabIndex = 7;

            // 
            // detectButton
            // 
            this.detectButton.Location = new System.Drawing.Point(731, 127);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(85, 45);
            this.detectButton.TabIndex = 8;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 476);
            this.Controls.Add(this.detectButton);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.mainProgressBar);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.dirImgCountLabel);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.dirButton);
            this.Controls.Add(this.dirTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Face Detector";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dirTextBox;
        private System.Windows.Forms.Button dirButton;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Label dirImgCountLabel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ProgressBar mainProgressBar;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Button detectButton;
    }
}

