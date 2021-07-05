
namespace ThreadWorker
{
    partial class LayoutDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutDesign));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DirTextBox = new System.Windows.Forms.TextBox();
            this.DirLoadButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ProcessOneButton = new System.Windows.Forms.Button();
            this.ProcessTwoButton = new System.Windows.Forms.Button();
            this.ProcessThreeButton = new System.Windows.Forms.Button();
            this.ProcessQueueLabel = new System.Windows.Forms.Label();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Controls.Add(this.DirTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DirLoadButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mainDataGridView, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DirTextBox
            // 
            this.DirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirTextBox.Location = new System.Drawing.Point(3, 3);
            this.DirTextBox.Name = "DirTextBox";
            this.DirTextBox.Size = new System.Drawing.Size(712, 25);
            this.DirTextBox.TabIndex = 0;
            this.DirTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // DirLoadButton
            // 
            this.DirLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirLoadButton.Location = new System.Drawing.Point(721, 3);
            this.DirLoadButton.Name = "DirLoadButton";
            this.DirLoadButton.Size = new System.Drawing.Size(93, 28);
            this.DirLoadButton.TabIndex = 1;
            this.DirLoadButton.Text = "Load";
            this.DirLoadButton.UseVisualStyleBackColor = true;
            this.DirLoadButton.Click += new System.EventHandler(this.DirLoadButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ProcessOneButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ProcessTwoButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ProcessThreeButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ProcessQueueLabel, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(721, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(93, 452);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // ProcessOneButton
            // 
            this.ProcessOneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessOneButton.Location = new System.Drawing.Point(3, 3);
            this.ProcessOneButton.Name = "ProcessOneButton";
            this.ProcessOneButton.Size = new System.Drawing.Size(87, 39);
            this.ProcessOneButton.TabIndex = 0;
            this.ProcessOneButton.Text = "Process 1";
            this.ProcessOneButton.UseVisualStyleBackColor = true;
            this.ProcessOneButton.Click += new System.EventHandler(this.ProcessOneButton_Click);
            // 
            // ProcessTwoButton
            // 
            this.ProcessTwoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessTwoButton.AutoEllipsis = true;
            this.ProcessTwoButton.Location = new System.Drawing.Point(3, 48);
            this.ProcessTwoButton.Name = "ProcessTwoButton";
            this.ProcessTwoButton.Size = new System.Drawing.Size(87, 39);
            this.ProcessTwoButton.TabIndex = 1;
            this.ProcessTwoButton.Text = "Process 2";
            this.ProcessTwoButton.UseVisualStyleBackColor = true;
            this.ProcessTwoButton.Click += new System.EventHandler(this.ProcessTwoButton_Click);
            // 
            // ProcessThreeButton
            // 
            this.ProcessThreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessThreeButton.Location = new System.Drawing.Point(3, 93);
            this.ProcessThreeButton.Name = "ProcessThreeButton";
            this.ProcessThreeButton.Size = new System.Drawing.Size(87, 39);
            this.ProcessThreeButton.TabIndex = 2;
            this.ProcessThreeButton.Text = "Process 3";
            this.ProcessThreeButton.UseVisualStyleBackColor = true;
            this.ProcessThreeButton.Click += new System.EventHandler(this.ProcessThreeButton_Click);
            // 
            // ProcessQueueLabel
            // 
            this.ProcessQueueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessQueueLabel.AutoSize = true;
            this.ProcessQueueLabel.Location = new System.Drawing.Point(3, 135);
            this.ProcessQueueLabel.Name = "ProcessQueueLabel";
            this.ProcessQueueLabel.Size = new System.Drawing.Size(87, 317);
            this.ProcessQueueLabel.TabIndex = 3;
            this.ProcessQueueLabel.Text = "Process Queue";
            this.ProcessQueueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(3, 37);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 27;
            this.mainDataGridView.Size = new System.Drawing.Size(712, 452);
            this.mainDataGridView.TabIndex = 4;
            // 
            // LayoutDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 495);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LayoutDesign";
            this.Text = "Thread Processing";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox DirTextBox;
        private System.Windows.Forms.Button DirLoadButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ProcessOneButton;
        private System.Windows.Forms.Button ProcessTwoButton;
        private System.Windows.Forms.Button ProcessThreeButton;
        private System.Windows.Forms.Label ProcessQueueLabel;
        private System.Windows.Forms.DataGridView mainDataGridView;
    }
}