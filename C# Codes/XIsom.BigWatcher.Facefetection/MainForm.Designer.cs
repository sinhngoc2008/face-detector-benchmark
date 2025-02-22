
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
            this.components = new System.ComponentModel.Container();
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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.autoDetectButton = new System.Windows.Forms.Button();
            this.autoProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.threadProcessButton = new System.Windows.Forms.Button();
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.mainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dirTextBox
            // 
            this.dirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dirTextBox.Location = new System.Drawing.Point(16, 9);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.Size = new System.Drawing.Size(624, 25);
            this.dirTextBox.TabIndex = 0;
            // 
            // dirButton
            // 
            this.dirButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dirButton.Location = new System.Drawing.Point(647, 9);
            this.dirButton.Name = "dirButton";
            this.dirButton.Size = new System.Drawing.Size(98, 25);
            this.dirButton.TabIndex = 1;
            this.dirButton.Text = "Browse";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainPictureBox.Location = new System.Drawing.Point(17, 44);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(623, 392);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            // 
            // dirImgCountLabel
            // 
            this.dirImgCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dirImgCountLabel.AutoSize = true;
            this.dirImgCountLabel.Location = new System.Drawing.Point(647, 44);
            this.dirImgCountLabel.Name = "dirImgCountLabel";
            this.dirImgCountLabel.Size = new System.Drawing.Size(98, 20);
            this.dirImgCountLabel.TabIndex = 3;
            this.dirImgCountLabel.Text = "Total Images";
            this.dirImgCountLabel.UseCompatibleTextRendering = true;
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.prevButton.Location = new System.Drawing.Point(645, 74);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(41, 24);
            this.prevButton.TabIndex = 4;
            this.prevButton.Text = "<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nextButton.Location = new System.Drawing.Point(692, 74);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(41, 24);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainProgressBar.Location = new System.Drawing.Point(17, 449);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(623, 16);
            this.mainProgressBar.TabIndex = 6;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowDrop = true;
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToResizeColumns = false;
            this.mainDataGridView.AllowUserToResizeRows = false;
            this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDataGridView.ColumnHeadersHeight = 29;
            this.mainDataGridView.Location = new System.Drawing.Point(751, 9);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 27;
            this.mainDataGridView.Size = new System.Drawing.Size(425, 455);
            this.mainDataGridView.TabIndex = 7;
            this.mainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellClick);
            // 
            // detectButton
            // 
            this.detectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detectButton.Location = new System.Drawing.Point(647, 120);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(86, 38);
            this.detectButton.TabIndex = 8;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(649, 433);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(84, 33);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loadButton.Location = new System.Drawing.Point(650, 382);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(82, 35);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // autoDetectButton
            // 
            this.autoDetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoDetectButton.Location = new System.Drawing.Point(647, 175);
            this.autoDetectButton.Name = "autoDetectButton";
            this.autoDetectButton.Size = new System.Drawing.Size(86, 46);
            this.autoDetectButton.TabIndex = 11;
            this.autoDetectButton.Text = "Auto Detect";
            this.autoDetectButton.UseVisualStyleBackColor = true;
            this.autoDetectButton.Click += new System.EventHandler(this.autoDetectButton_Click);
            // 
            // autoProcessBackgroundWorker
            // 
            this.autoProcessBackgroundWorker.WorkerReportsProgress = true;
            this.autoProcessBackgroundWorker.WorkerSupportsCancellation = true;
            this.autoProcessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.autoProcessBackgroundWorker_DoWork);
            this.autoProcessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.autoProcessBackgroundWorker_ProgressChanged);
            this.autoProcessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.autoProcessBackgroundWorker_RunWorkerCompleted);
            // 
            // threadProcessButton
            // 
            this.threadProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.threadProcessButton.Location = new System.Drawing.Point(647, 239);
            this.threadProcessButton.Name = "threadProcessButton";
            this.threadProcessButton.Size = new System.Drawing.Size(86, 50);
            this.threadProcessButton.TabIndex = 12;
            this.threadProcessButton.Text = "Thread Process";
            this.threadProcessButton.UseVisualStyleBackColor = true;
            this.threadProcessButton.Click += new System.EventHandler(this.threadProcessButton_Click);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.oKToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(110, 52);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuItem1.Text = "Save";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // oKToolStripMenuItem
            // 
            this.oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            this.oKToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.oKToolStripMenuItem.Text = "OK";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 524);
            this.ContextMenuStrip = this.mainContextMenuStrip;
            this.Controls.Add(this.threadProcessButton);
            this.Controls.Add(this.autoDetectButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
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
            this.mainContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button autoDetectButton;
        private System.ComponentModel.BackgroundWorker autoProcessBackgroundWorker;
        private System.Windows.Forms.Button threadProcessButton;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oKToolStripMenuItem;
    }
}

