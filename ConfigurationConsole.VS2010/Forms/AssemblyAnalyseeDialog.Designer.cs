namespace SourcePro.Csharp.Lab.Forms
{
    partial class AssemblyAnalyseeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyAnalyseeDialog));
            this.ProgressControlPanel = new System.Windows.Forms.Panel();
            this.ProgressTextLabel = new System.Windows.Forms.Label();
            this.ProgressPictureBox = new System.Windows.Forms.PictureBox();
            this.BackWorker = new System.ComponentModel.BackgroundWorker();
            this.TypesPanel = new System.Windows.Forms.Panel();
            this.TypeListBox = new System.Windows.Forms.ListBox();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.StatusListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressPictureBox)).BeginInit();
            this.TypesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressControlPanel
            // 
            this.ProgressControlPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ProgressControlPanel.Controls.Add(this.ProgressTextLabel);
            this.ProgressControlPanel.Controls.Add(this.ProgressPictureBox);
            this.ProgressControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgressControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ProgressControlPanel.Name = "ProgressControlPanel";
            this.ProgressControlPanel.Size = new System.Drawing.Size(594, 30);
            this.ProgressControlPanel.TabIndex = 0;
            // 
            // ProgressTextLabel
            // 
            this.ProgressTextLabel.AutoSize = true;
            this.ProgressTextLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressTextLabel.ForeColor = System.Drawing.Color.Gray;
            this.ProgressTextLabel.Location = new System.Drawing.Point(25, 8);
            this.ProgressTextLabel.Name = "ProgressTextLabel";
            this.ProgressTextLabel.Size = new System.Drawing.Size(286, 15);
            this.ProgressTextLabel.TabIndex = 1;
            this.ProgressTextLabel.Text = "Generating reflection information. Hold on please.";
            // 
            // ProgressPictureBox
            // 
            this.ProgressPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ProgressPictureBox.Image")));
            this.ProgressPictureBox.Location = new System.Drawing.Point(5, 7);
            this.ProgressPictureBox.Name = "ProgressPictureBox";
            this.ProgressPictureBox.Size = new System.Drawing.Size(16, 16);
            this.ProgressPictureBox.TabIndex = 0;
            this.ProgressPictureBox.TabStop = false;
            // 
            // TypesPanel
            // 
            this.TypesPanel.Controls.Add(this.TypeListBox);
            this.TypesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TypesPanel.Location = new System.Drawing.Point(0, 30);
            this.TypesPanel.Name = "TypesPanel";
            this.TypesPanel.Size = new System.Drawing.Size(594, 200);
            this.TypesPanel.TabIndex = 1;
            // 
            // TypeListBox
            // 
            this.TypeListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeListBox.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TypeListBox.FormattingEnabled = true;
            this.TypeListBox.ItemHeight = 15;
            this.TypeListBox.Location = new System.Drawing.Point(0, 0);
            this.TypeListBox.Name = "TypeListBox";
            this.TypeListBox.Size = new System.Drawing.Size(594, 200);
            this.TypeListBox.Sorted = true;
            this.TypeListBox.TabIndex = 0;
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "20141217032449855_easyicon_net_16.png");
            this.StatusImageList.Images.SetKeyName(1, "20141217032616550_easyicon_net_16.png");
            // 
            // StatusListView
            // 
            this.StatusListView.BackColor = System.Drawing.Color.White;
            this.StatusListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.StatusListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusListView.FullRowSelect = true;
            this.StatusListView.GridLines = true;
            this.StatusListView.LargeImageList = this.StatusImageList;
            this.StatusListView.Location = new System.Drawing.Point(0, 230);
            this.StatusListView.Name = "StatusListView";
            this.StatusListView.Size = new System.Drawing.Size(594, 142);
            this.StatusListView.SmallImageList = this.StatusImageList;
            this.StatusListView.StateImageList = this.StatusImageList;
            this.StatusListView.TabIndex = 2;
            this.StatusListView.UseCompatibleStateImageBehavior = false;
            this.StatusListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File\'s Name";
            this.columnHeader3.Width = 300;
            // 
            // AssemblyAnalyseeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 372);
            this.Controls.Add(this.StatusListView);
            this.Controls.Add(this.TypesPanel);
            this.Controls.Add(this.ProgressControlPanel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssemblyAnalyseeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analysee .Net Assemblies";
            this.TopMost = true;
            this.ProgressControlPanel.ResumeLayout(false);
            this.ProgressControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressPictureBox)).EndInit();
            this.TypesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProgressControlPanel;
        private System.Windows.Forms.Label ProgressTextLabel;
        private System.Windows.Forms.PictureBox ProgressPictureBox;
        private System.ComponentModel.BackgroundWorker BackWorker;
        private System.Windows.Forms.Panel TypesPanel;
        private System.Windows.Forms.ImageList StatusImageList;
        private System.Windows.Forms.ListView StatusListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListBox TypeListBox;

    }
}