
namespace Xisom.ReDesigned.FaceDetector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.maintableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.pictureButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.dirButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loadButton = new System.Windows.Forms.Button();
            this.detectButton = new System.Windows.Forms.Button();
            this.autoDetectButton = new System.Windows.Forms.Button();
            this.threadProcessButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.dirImgCountLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.taskProcessbutton = new System.Windows.Forms.Button();
            this.processLabel = new System.Windows.Forms.Label();
            this.autoProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maintableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.pictureButtonTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.buttonTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.mainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // maintableLayoutPanel
            // 
            this.maintableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maintableLayoutPanel.ColumnCount = 2;
            this.maintableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.maintableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.maintableLayoutPanel.Controls.Add(this.mainDataGridView, 1, 0);
            this.maintableLayoutPanel.Controls.Add(this.pictureButtonTableLayoutPanel, 0, 0);
            this.maintableLayoutPanel.Location = new System.Drawing.Point(2, 6);
            this.maintableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maintableLayoutPanel.Name = "maintableLayoutPanel";
            this.maintableLayoutPanel.RowCount = 1;
            this.maintableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.maintableLayoutPanel.Size = new System.Drawing.Size(1130, 656);
            this.maintableLayoutPanel.TabIndex = 0;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainDataGridView.Location = new System.Drawing.Point(681, 2);
            this.mainDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 27;
            this.mainDataGridView.Size = new System.Drawing.Size(446, 652);
            this.mainDataGridView.TabIndex = 0;
            this.mainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellClick);
            // 
            // pictureButtonTableLayoutPanel
            // 
            this.pictureButtonTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureButtonTableLayoutPanel.ColumnCount = 2;
            this.pictureButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pictureButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pictureButtonTableLayoutPanel.Controls.Add(this.mainProgressBar, 0, 2);
            this.pictureButtonTableLayoutPanel.Controls.Add(this.dirTextBox, 0, 0);
            this.pictureButtonTableLayoutPanel.Controls.Add(this.dirButton, 1, 0);
            this.pictureButtonTableLayoutPanel.Controls.Add(this.mainPictureBox, 0, 1);
            this.pictureButtonTableLayoutPanel.Controls.Add(this.buttonTableLayoutPanel, 1, 1);
            this.pictureButtonTableLayoutPanel.Controls.Add(this.processLabel, 1, 2);
            this.pictureButtonTableLayoutPanel.Location = new System.Drawing.Point(3, 2);
            this.pictureButtonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureButtonTableLayoutPanel.Name = "pictureButtonTableLayoutPanel";
            this.pictureButtonTableLayoutPanel.RowCount = 3;
            this.pictureButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.027885F));
            this.pictureButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.96191F));
            this.pictureButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.010202F));
            this.pictureButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pictureButtonTableLayoutPanel.Size = new System.Drawing.Size(672, 652);
            this.pictureButtonTableLayoutPanel.TabIndex = 1;
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainProgressBar.Location = new System.Drawing.Point(3, 620);
            this.mainProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(531, 19);
            this.mainProgressBar.TabIndex = 0;
            // 
            // dirTextBox
            // 
            this.dirTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirTextBox.Location = new System.Drawing.Point(3, 2);
            this.dirTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.Size = new System.Drawing.Size(531, 25);
            this.dirTextBox.TabIndex = 1;
            // 
            // dirButton
            // 
            this.dirButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirButton.Location = new System.Drawing.Point(540, 2);
            this.dirButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dirButton.Name = "dirButton";
            this.dirButton.Size = new System.Drawing.Size(129, 41);
            this.dirButton.TabIndex = 2;
            this.dirButton.Text = "Browse";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.Location = new System.Drawing.Point(3, 47);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(531, 569);
            this.mainPictureBox.TabIndex = 3;
            this.mainPictureBox.TabStop = false;
            // 
            // buttonTableLayoutPanel
            // 
            this.buttonTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTableLayoutPanel.ColumnCount = 1;
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayoutPanel.Controls.Add(this.loadButton, 0, 9);
            this.buttonTableLayoutPanel.Controls.Add(this.detectButton, 0, 1);
            this.buttonTableLayoutPanel.Controls.Add(this.autoDetectButton, 0, 2);
            this.buttonTableLayoutPanel.Controls.Add(this.threadProcessButton, 0, 4);
            this.buttonTableLayoutPanel.Controls.Add(this.saveButton, 0, 8);
            this.buttonTableLayoutPanel.Controls.Add(this.dirImgCountLabel, 0, 0);
            this.buttonTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 6);
            this.buttonTableLayoutPanel.Controls.Add(this.taskProcessbutton, 0, 5);
            this.buttonTableLayoutPanel.Location = new System.Drawing.Point(540, 47);
            this.buttonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            this.buttonTableLayoutPanel.RowCount = 10;
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.buttonTableLayoutPanel.Size = new System.Drawing.Size(129, 569);
            this.buttonTableLayoutPanel.TabIndex = 4;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(3, 506);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(123, 61);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // detectButton
            // 
            this.detectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detectButton.Location = new System.Drawing.Point(3, 58);
            this.detectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(123, 52);
            this.detectButton.TabIndex = 1;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // autoDetectButton
            // 
            this.autoDetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoDetectButton.Location = new System.Drawing.Point(3, 114);
            this.autoDetectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoDetectButton.Name = "autoDetectButton";
            this.autoDetectButton.Size = new System.Drawing.Size(123, 52);
            this.autoDetectButton.TabIndex = 2;
            this.autoDetectButton.Text = "Auto Detect";
            this.autoDetectButton.UseVisualStyleBackColor = true;
            this.autoDetectButton.Click += new System.EventHandler(this.autoDetectButton_Click);
            // 
            // threadProcessButton
            // 
            this.threadProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.threadProcessButton.Location = new System.Drawing.Point(3, 226);
            this.threadProcessButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.threadProcessButton.Name = "threadProcessButton";
            this.threadProcessButton.Size = new System.Drawing.Size(123, 52);
            this.threadProcessButton.TabIndex = 4;
            this.threadProcessButton.Text = "Thread Process";
            this.threadProcessButton.UseVisualStyleBackColor = true;
            this.threadProcessButton.Click += new System.EventHandler(this.threadProcessButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(3, 450);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 52);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dirImgCountLabel
            // 
            this.dirImgCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirImgCountLabel.AutoSize = true;
            this.dirImgCountLabel.Location = new System.Drawing.Point(3, 0);
            this.dirImgCountLabel.Name = "dirImgCountLabel";
            this.dirImgCountLabel.Size = new System.Drawing.Size(123, 56);
            this.dirImgCountLabel.TabIndex = 5;
            this.dirImgCountLabel.Text = "TOTAL IMG";
            this.dirImgCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.prevButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 338);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(123, 52);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevButton.Location = new System.Drawing.Point(3, 2);
            this.prevButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(55, 48);
            this.prevButton.TabIndex = 0;
            this.prevButton.Text = "<<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(64, 2);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(56, 48);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = ">>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // taskProcessbutton
            // 
            this.taskProcessbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskProcessbutton.Location = new System.Drawing.Point(3, 284);
            this.taskProcessbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.taskProcessbutton.Name = "taskProcessbutton";
            this.taskProcessbutton.Size = new System.Drawing.Size(123, 48);
            this.taskProcessbutton.TabIndex = 7;
            this.taskProcessbutton.Text = "Task Process";
            this.taskProcessbutton.UseVisualStyleBackColor = true;
            this.taskProcessbutton.Click += new System.EventHandler(this.threadCancelButton_Click);
            // 
            // processLabel
            // 
            this.processLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processLabel.AutoSize = true;
            this.processLabel.Location = new System.Drawing.Point(540, 618);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(129, 34);
            this.processLabel.TabIndex = 5;
            this.processLabel.Text = "Process";
            this.processLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autoProcessBackgroundWorker
            // 
            this.autoProcessBackgroundWorker.WorkerReportsProgress = true;
            this.autoProcessBackgroundWorker.WorkerSupportsCancellation = true;
            this.autoProcessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.autoProcessBackgroundWorker_DoWork);
            this.autoProcessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.autoProcessBackgroundWorker_ProgressChanged);
            this.autoProcessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.autoProcessBackgroundWorker_RunWorkerCompleted);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(103, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 24);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1136, 664);
            this.ContextMenuStrip = this.mainContextMenuStrip;
            this.Controls.Add(this.maintableLayoutPanel);
            this.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Xisom Facedetector";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.maintableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.pictureButtonTableLayoutPanel.ResumeLayout(false);
            this.pictureButtonTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.buttonTableLayoutPanel.ResumeLayout(false);
            this.buttonTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel maintableLayoutPanel;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.TableLayoutPanel pictureButtonTableLayoutPanel;
        private System.Windows.Forms.ProgressBar mainProgressBar;
        private System.Windows.Forms.TextBox dirTextBox;
        private System.Windows.Forms.Button dirButton;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button detectButton;
        private System.Windows.Forms.Button autoDetectButton;
        private System.Windows.Forms.Button threadProcessButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label dirImgCountLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button taskProcessbutton;
        private System.ComponentModel.BackgroundWorker autoProcessBackgroundWorker;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label processLabel;
    }
}

