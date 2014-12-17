namespace SourcePro.Csharp.Lab.Controls
{
    partial class ConfigurationSourceEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationSourceEditor));
            this.ControlCaptionPanel = new System.Windows.Forms.Panel();
            this.ProtectionSelector = new System.Windows.Forms.ComboBox();
            this.ControlCaptionLabel = new System.Windows.Forms.Label();
            this.MainSplitterContainer = new System.Windows.Forms.SplitContainer();
            this.VirtualDirectory = new System.Windows.Forms.TextBox();
            this.DescriptionLabel03 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SplitterLine = new System.Windows.Forms.Panel();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ConfigureSourceFileName = new System.Windows.Forms.TextBox();
            this.SectionOrGroupName = new System.Windows.Forms.ComboBox();
            this.DescriptionLabel02 = new System.Windows.Forms.Label();
            this.DescriptionLabel01 = new System.Windows.Forms.Label();
            this.SourceList = new System.Windows.Forms.ListView();
            this.SectionNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VirtualDirectoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinorToolStrip = new System.Windows.Forms.ToolStrip();
            this.RemoveToolButton = new System.Windows.Forms.ToolStripButton();
            this.SourceFileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.FlashTimer = new System.Windows.Forms.Timer(this.components);
            this.ControlCaptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitterContainer)).BeginInit();
            this.MainSplitterContainer.Panel1.SuspendLayout();
            this.MainSplitterContainer.Panel2.SuspendLayout();
            this.MainSplitterContainer.SuspendLayout();
            this.MinorToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlCaptionPanel
            // 
            this.ControlCaptionPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ControlCaptionPanel.Controls.Add(this.ProtectionSelector);
            this.ControlCaptionPanel.Controls.Add(this.ControlCaptionLabel);
            this.ControlCaptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlCaptionPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlCaptionPanel.Name = "ControlCaptionPanel";
            this.ControlCaptionPanel.Size = new System.Drawing.Size(781, 30);
            this.ControlCaptionPanel.TabIndex = 0;
            // 
            // ProtectionSelector
            // 
            this.ProtectionSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtectionSelector.BackColor = System.Drawing.Color.White;
            this.ProtectionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProtectionSelector.FormattingEnabled = true;
            this.ProtectionSelector.Location = new System.Drawing.Point(526, 3);
            this.ProtectionSelector.Name = "ProtectionSelector";
            this.ProtectionSelector.Size = new System.Drawing.Size(250, 23);
            this.ProtectionSelector.TabIndex = 1;
            // 
            // ControlCaptionLabel
            // 
            this.ControlCaptionLabel.AutoSize = true;
            this.ControlCaptionLabel.Location = new System.Drawing.Point(10, 8);
            this.ControlCaptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlCaptionLabel.Name = "ControlCaptionLabel";
            this.ControlCaptionLabel.Size = new System.Drawing.Size(198, 15);
            this.ControlCaptionLabel.TabIndex = 0;
            this.ControlCaptionLabel.Text = "Configuration Source Management";
            // 
            // MainSplitterContainer
            // 
            this.MainSplitterContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitterContainer.Location = new System.Drawing.Point(0, 30);
            this.MainSplitterContainer.Name = "MainSplitterContainer";
            // 
            // MainSplitterContainer.Panel1
            // 
            this.MainSplitterContainer.Panel1.Controls.Add(this.VirtualDirectory);
            this.MainSplitterContainer.Panel1.Controls.Add(this.DescriptionLabel03);
            this.MainSplitterContainer.Panel1.Controls.Add(this.CreateButton);
            this.MainSplitterContainer.Panel1.Controls.Add(this.SplitterLine);
            this.MainSplitterContainer.Panel1.Controls.Add(this.BrowseButton);
            this.MainSplitterContainer.Panel1.Controls.Add(this.ConfigureSourceFileName);
            this.MainSplitterContainer.Panel1.Controls.Add(this.SectionOrGroupName);
            this.MainSplitterContainer.Panel1.Controls.Add(this.DescriptionLabel02);
            this.MainSplitterContainer.Panel1.Controls.Add(this.DescriptionLabel01);
            // 
            // MainSplitterContainer.Panel2
            // 
            this.MainSplitterContainer.Panel2.Controls.Add(this.SourceList);
            this.MainSplitterContainer.Panel2.Controls.Add(this.MinorToolStrip);
            this.MainSplitterContainer.Size = new System.Drawing.Size(781, 403);
            this.MainSplitterContainer.SplitterDistance = 230;
            this.MainSplitterContainer.SplitterWidth = 2;
            this.MainSplitterContainer.TabIndex = 1;
            // 
            // VirtualDirectory
            // 
            this.VirtualDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualDirectory.Location = new System.Drawing.Point(16, 217);
            this.VirtualDirectory.Name = "VirtualDirectory";
            this.VirtualDirectory.Size = new System.Drawing.Size(198, 21);
            this.VirtualDirectory.TabIndex = 8;
            // 
            // DescriptionLabel03
            // 
            this.DescriptionLabel03.AutoSize = true;
            this.DescriptionLabel03.Location = new System.Drawing.Point(16, 186);
            this.DescriptionLabel03.Name = "DescriptionLabel03";
            this.DescriptionLabel03.Size = new System.Drawing.Size(246, 15);
            this.DescriptionLabel03.TabIndex = 7;
            this.DescriptionLabel03.Text = "ASP.NET Compatibility (Set Virtual Directory)";
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Location = new System.Drawing.Point(16, 296);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 25);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "OK";
            this.CreateButton.UseVisualStyleBackColor = false;
            // 
            // SplitterLine
            // 
            this.SplitterLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitterLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SplitterLine.Location = new System.Drawing.Point(16, 278);
            this.SplitterLine.Name = "SplitterLine";
            this.SplitterLine.Size = new System.Drawing.Size(198, 2);
            this.SplitterLine.TabIndex = 5;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Location = new System.Drawing.Point(16, 139);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 25);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            // 
            // ConfigureSourceFileName
            // 
            this.ConfigureSourceFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigureSourceFileName.BackColor = System.Drawing.Color.White;
            this.ConfigureSourceFileName.ForeColor = System.Drawing.Color.Gray;
            this.ConfigureSourceFileName.Location = new System.Drawing.Point(16, 111);
            this.ConfigureSourceFileName.Name = "ConfigureSourceFileName";
            this.ConfigureSourceFileName.ReadOnly = true;
            this.ConfigureSourceFileName.Size = new System.Drawing.Size(198, 21);
            this.ConfigureSourceFileName.TabIndex = 3;
            this.ConfigureSourceFileName.Text = "(none)";
            // 
            // SectionOrGroupName
            // 
            this.SectionOrGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionOrGroupName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SectionOrGroupName.FormattingEnabled = true;
            this.SectionOrGroupName.Items.AddRange(new object[] {
            "sourcepro.data"});
            this.SectionOrGroupName.Location = new System.Drawing.Point(16, 41);
            this.SectionOrGroupName.Name = "SectionOrGroupName";
            this.SectionOrGroupName.Size = new System.Drawing.Size(198, 23);
            this.SectionOrGroupName.TabIndex = 2;
            // 
            // DescriptionLabel02
            // 
            this.DescriptionLabel02.AutoSize = true;
            this.DescriptionLabel02.Location = new System.Drawing.Point(13, 83);
            this.DescriptionLabel02.Name = "DescriptionLabel02";
            this.DescriptionLabel02.Size = new System.Drawing.Size(146, 15);
            this.DescriptionLabel02.TabIndex = 1;
            this.DescriptionLabel02.Text = "Configuration Source File";
            // 
            // DescriptionLabel01
            // 
            this.DescriptionLabel01.AutoSize = true;
            this.DescriptionLabel01.Location = new System.Drawing.Point(13, 13);
            this.DescriptionLabel01.Name = "DescriptionLabel01";
            this.DescriptionLabel01.Size = new System.Drawing.Size(204, 15);
            this.DescriptionLabel01.TabIndex = 1;
            this.DescriptionLabel01.Text = "Configuration Section(Group) Name";
            // 
            // SourceList
            // 
            this.SourceList.BackColor = System.Drawing.Color.White;
            this.SourceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SectionNameColumn,
            this.SourceColumn,
            this.VirtualDirectoryColumn});
            this.SourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceList.FullRowSelect = true;
            this.SourceList.GridLines = true;
            this.SourceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SourceList.Location = new System.Drawing.Point(0, 25);
            this.SourceList.Name = "SourceList";
            this.SourceList.Size = new System.Drawing.Size(547, 376);
            this.SourceList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.SourceList.TabIndex = 1;
            this.SourceList.UseCompatibleStateImageBehavior = false;
            this.SourceList.View = System.Windows.Forms.View.Details;
            // 
            // SectionNameColumn
            // 
            this.SectionNameColumn.Text = "Configuration Section(Group) Name";
            this.SectionNameColumn.Width = 220;
            // 
            // SourceColumn
            // 
            this.SourceColumn.Text = "Configuration Source File";
            this.SourceColumn.Width = 300;
            // 
            // VirtualDirectoryColumn
            // 
            this.VirtualDirectoryColumn.Text = "ASP.NET Compatibility";
            this.VirtualDirectoryColumn.Width = 150;
            // 
            // MinorToolStrip
            // 
            this.MinorToolStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MinorToolStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveToolButton});
            this.MinorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MinorToolStrip.Name = "MinorToolStrip";
            this.MinorToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MinorToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MinorToolStrip.Size = new System.Drawing.Size(547, 25);
            this.MinorToolStrip.TabIndex = 0;
            this.MinorToolStrip.Text = "toolStrip1";
            // 
            // RemoveToolButton
            // 
            this.RemoveToolButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveToolButton.ForeColor = System.Drawing.Color.Maroon;
            this.RemoveToolButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveToolButton.Image")));
            this.RemoveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveToolButton.Name = "RemoveToolButton";
            this.RemoveToolButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RemoveToolButton.Size = new System.Drawing.Size(139, 22);
            this.RemoveToolButton.Text = "Remove Selected！";
            // 
            // SourceFileSelectDialog
            // 
            this.SourceFileSelectDialog.DefaultExt = "config";
            this.SourceFileSelectDialog.FileName = "Source.config";
            this.SourceFileSelectDialog.Filter = ".Net Configuration|*.config";
            this.SourceFileSelectDialog.RestoreDirectory = true;
            this.SourceFileSelectDialog.SupportMultiDottedExtensions = true;
            this.SourceFileSelectDialog.Title = "Select A Configuration Source File";
            // 
            // FlashTimer
            // 
            this.FlashTimer.Interval = 300;
            // 
            // ConfigurationSourceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MainSplitterContainer);
            this.Controls.Add(this.ControlCaptionPanel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigurationSourceEditor";
            this.Size = new System.Drawing.Size(781, 433);
            this.ControlCaptionPanel.ResumeLayout(false);
            this.ControlCaptionPanel.PerformLayout();
            this.MainSplitterContainer.Panel1.ResumeLayout(false);
            this.MainSplitterContainer.Panel1.PerformLayout();
            this.MainSplitterContainer.Panel2.ResumeLayout(false);
            this.MainSplitterContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitterContainer)).EndInit();
            this.MainSplitterContainer.ResumeLayout(false);
            this.MinorToolStrip.ResumeLayout(false);
            this.MinorToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlCaptionPanel;
        private System.Windows.Forms.Label ControlCaptionLabel;
        private System.Windows.Forms.SplitContainer MainSplitterContainer;
        private System.Windows.Forms.Label DescriptionLabel01;
        private System.Windows.Forms.ComboBox SectionOrGroupName;
        private System.Windows.Forms.Label DescriptionLabel02;
        private System.Windows.Forms.TextBox ConfigureSourceFileName;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Panel SplitterLine;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.OpenFileDialog SourceFileSelectDialog;
        private System.Windows.Forms.ToolStrip MinorToolStrip;
        private System.Windows.Forms.ToolStripButton RemoveToolButton;
        private System.Windows.Forms.ComboBox ProtectionSelector;
        private System.Windows.Forms.ListView SourceList;
        private System.Windows.Forms.ColumnHeader SectionNameColumn;
        private System.Windows.Forms.ColumnHeader SourceColumn;
        private System.Windows.Forms.Label DescriptionLabel03;
        private System.Windows.Forms.TextBox VirtualDirectory;
        private System.Windows.Forms.ColumnHeader VirtualDirectoryColumn;
        private System.Windows.Forms.Timer FlashTimer;
    }
}
