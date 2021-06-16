
namespace HDF5Processor
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainFolderTextBox = new System.Windows.Forms.TextBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.18797F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.81203F));
            this.mainLayout.Controls.Add(this.mainFolderTextBox, 0, 0);
            this.mainLayout.Controls.Add(this.fileButton, 1, 0);
            this.mainLayout.Controls.Add(this.resultLabel, 0, 1);
            this.mainLayout.Location = new System.Drawing.Point(4, 2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.956213F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.04379F));
            this.mainLayout.Size = new System.Drawing.Size(776, 450);
            this.mainLayout.TabIndex = 0;
            // 
            // mainFolderTextBox
            // 
            this.mainFolderTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFolderTextBox.Location = new System.Drawing.Point(3, 3);
            this.mainFolderTextBox.Name = "mainFolderTextBox";
            this.mainFolderTextBox.Size = new System.Drawing.Size(577, 25);
            this.mainFolderTextBox.TabIndex = 0;
            // 
            // fileButton
            // 
            this.fileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileButton.Location = new System.Drawing.Point(586, 3);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(187, 25);
            this.fileButton.TabIndex = 1;
            this.fileButton.Text = "Choose File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(3, 233);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(577, 15);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Text = "label1";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "HDF5 Processor";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TextBox mainFolderTextBox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label resultLabel;
    }
}

