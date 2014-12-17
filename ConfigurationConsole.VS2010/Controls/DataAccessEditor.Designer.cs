namespace SourcePro.Csharp.Lab.Controls
{
    partial class DataAccessEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataAccessEditor));
            this.CaptionPanel = new System.Windows.Forms.Panel();
            this.ProtectionProviderSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.CaptionLabel = new System.Windows.Forms.Label();
            this.TabPagingContainer = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DbProviderSplitterContainer = new System.Windows.Forms.SplitContainer();
            this.SaveDbProviderButton = new System.Windows.Forms.Button();
            this.SplitterLine01 = new System.Windows.Forms.Panel();
            this.DbProviderIdentifierInput = new System.Windows.Forms.TextBox();
            this.DescriptionLabel002 = new System.Windows.Forms.Label();
            this.BrowseDbProviderButton = new System.Windows.Forms.Button();
            this.DbProviderNameInput = new System.Windows.Forms.TextBox();
            this.DescriptionLabel01 = new System.Windows.Forms.Label();
            this.DbProviderListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DbProviderToolStrip = new System.Windows.Forms.ToolStrip();
            this.RemoveDbProviderButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.AssemblyOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.CaptionPanel.SuspendLayout();
            this.TabPagingContainer.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DbProviderSplitterContainer)).BeginInit();
            this.DbProviderSplitterContainer.Panel1.SuspendLayout();
            this.DbProviderSplitterContainer.Panel2.SuspendLayout();
            this.DbProviderSplitterContainer.SuspendLayout();
            this.DbProviderToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptionPanel
            // 
            this.CaptionPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionPanel.Controls.Add(this.ProtectionProviderSelectionComboBox);
            this.CaptionPanel.Controls.Add(this.CaptionLabel);
            this.CaptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionPanel.Location = new System.Drawing.Point(0, 0);
            this.CaptionPanel.Name = "CaptionPanel";
            this.CaptionPanel.Size = new System.Drawing.Size(978, 30);
            this.CaptionPanel.TabIndex = 0;
            // 
            // ProtectionProviderSelectionComboBox
            // 
            this.ProtectionProviderSelectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtectionProviderSelectionComboBox.BackColor = System.Drawing.Color.White;
            this.ProtectionProviderSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProtectionProviderSelectionComboBox.FormattingEnabled = true;
            this.ProtectionProviderSelectionComboBox.Items.AddRange(new object[] {
            "(none)",
            "RsaProtectedConfigurationProvider"});
            this.ProtectionProviderSelectionComboBox.Location = new System.Drawing.Point(753, 4);
            this.ProtectionProviderSelectionComboBox.Name = "ProtectionProviderSelectionComboBox";
            this.ProtectionProviderSelectionComboBox.Size = new System.Drawing.Size(220, 23);
            this.ProtectionProviderSelectionComboBox.TabIndex = 1;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = true;
            this.CaptionLabel.Location = new System.Drawing.Point(10, 8);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(178, 15);
            this.CaptionLabel.TabIndex = 0;
            this.CaptionLabel.Text = "Database Access Management";
            // 
            // TabPagingContainer
            // 
            this.TabPagingContainer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabPagingContainer.Controls.Add(this.tabPage3);
            this.TabPagingContainer.Controls.Add(this.tabPage4);
            this.TabPagingContainer.Controls.Add(this.tabPage5);
            this.TabPagingContainer.Controls.Add(this.tabPage6);
            this.TabPagingContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPagingContainer.Location = new System.Drawing.Point(0, 30);
            this.TabPagingContainer.Name = "TabPagingContainer";
            this.TabPagingContainer.SelectedIndex = 0;
            this.TabPagingContainer.Size = new System.Drawing.Size(978, 471);
            this.TabPagingContainer.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DbProviderSplitterContainer);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(970, 440);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Database Providers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DbProviderSplitterContainer
            // 
            this.DbProviderSplitterContainer.BackColor = System.Drawing.Color.White;
            this.DbProviderSplitterContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DbProviderSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DbProviderSplitterContainer.Location = new System.Drawing.Point(0, 0);
            this.DbProviderSplitterContainer.Name = "DbProviderSplitterContainer";
            // 
            // DbProviderSplitterContainer.Panel1
            // 
            this.DbProviderSplitterContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.SaveDbProviderButton);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.SplitterLine01);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.DbProviderIdentifierInput);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.DescriptionLabel002);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.BrowseDbProviderButton);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.DbProviderNameInput);
            this.DbProviderSplitterContainer.Panel1.Controls.Add(this.DescriptionLabel01);
            // 
            // DbProviderSplitterContainer.Panel2
            // 
            this.DbProviderSplitterContainer.Panel2.Controls.Add(this.DbProviderListView);
            this.DbProviderSplitterContainer.Panel2.Controls.Add(this.DbProviderToolStrip);
            this.DbProviderSplitterContainer.Size = new System.Drawing.Size(970, 440);
            this.DbProviderSplitterContainer.SplitterDistance = 220;
            this.DbProviderSplitterContainer.SplitterWidth = 2;
            this.DbProviderSplitterContainer.TabIndex = 0;
            // 
            // SaveDbProviderButton
            // 
            this.SaveDbProviderButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveDbProviderButton.FlatAppearance.BorderSize = 0;
            this.SaveDbProviderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDbProviderButton.Location = new System.Drawing.Point(10, 199);
            this.SaveDbProviderButton.Name = "SaveDbProviderButton";
            this.SaveDbProviderButton.Size = new System.Drawing.Size(50, 25);
            this.SaveDbProviderButton.TabIndex = 6;
            this.SaveDbProviderButton.Text = "OK";
            this.SaveDbProviderButton.UseVisualStyleBackColor = false;
            // 
            // SplitterLine01
            // 
            this.SplitterLine01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitterLine01.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SplitterLine01.Location = new System.Drawing.Point(10, 180);
            this.SplitterLine01.Name = "SplitterLine01";
            this.SplitterLine01.Size = new System.Drawing.Size(196, 2);
            this.SplitterLine01.TabIndex = 5;
            // 
            // DbProviderIdentifierInput
            // 
            this.DbProviderIdentifierInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DbProviderIdentifierInput.Location = new System.Drawing.Point(10, 127);
            this.DbProviderIdentifierInput.Name = "DbProviderIdentifierInput";
            this.DbProviderIdentifierInput.Size = new System.Drawing.Size(196, 21);
            this.DbProviderIdentifierInput.TabIndex = 4;
            // 
            // DescriptionLabel002
            // 
            this.DescriptionLabel002.AutoSize = true;
            this.DescriptionLabel002.Location = new System.Drawing.Point(7, 104);
            this.DescriptionLabel002.Name = "DescriptionLabel002";
            this.DescriptionLabel002.Size = new System.Drawing.Size(168, 15);
            this.DescriptionLabel002.TabIndex = 3;
            this.DescriptionLabel002.Text = "Database Provider\'s Identifier";
            // 
            // BrowseDbProviderButton
            // 
            this.BrowseDbProviderButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseDbProviderButton.FlatAppearance.BorderSize = 0;
            this.BrowseDbProviderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseDbProviderButton.Location = new System.Drawing.Point(10, 64);
            this.BrowseDbProviderButton.Name = "BrowseDbProviderButton";
            this.BrowseDbProviderButton.Size = new System.Drawing.Size(125, 25);
            this.BrowseDbProviderButton.TabIndex = 2;
            this.BrowseDbProviderButton.Text = "Browse Assembly";
            this.BrowseDbProviderButton.UseVisualStyleBackColor = false;
            // 
            // DbProviderNameInput
            // 
            this.DbProviderNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DbProviderNameInput.BackColor = System.Drawing.Color.White;
            this.DbProviderNameInput.Location = new System.Drawing.Point(10, 36);
            this.DbProviderNameInput.Name = "DbProviderNameInput";
            this.DbProviderNameInput.ReadOnly = true;
            this.DbProviderNameInput.Size = new System.Drawing.Size(196, 21);
            this.DbProviderNameInput.TabIndex = 1;
            // 
            // DescriptionLabel01
            // 
            this.DescriptionLabel01.AutoSize = true;
            this.DescriptionLabel01.Location = new System.Drawing.Point(7, 11);
            this.DescriptionLabel01.Name = "DescriptionLabel01";
            this.DescriptionLabel01.Size = new System.Drawing.Size(180, 15);
            this.DescriptionLabel01.TabIndex = 0;
            this.DescriptionLabel01.Text = "Database Provider\'s TypeName";
            // 
            // DbProviderListView
            // 
            this.DbProviderListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DbProviderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.DbProviderListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DbProviderListView.FullRowSelect = true;
            this.DbProviderListView.GridLines = true;
            this.DbProviderListView.Location = new System.Drawing.Point(0, 25);
            this.DbProviderListView.Name = "DbProviderListView";
            this.DbProviderListView.Size = new System.Drawing.Size(746, 413);
            this.DbProviderListView.TabIndex = 1;
            this.DbProviderListView.UseCompatibleStateImageBehavior = false;
            this.DbProviderListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Database Provider\'s Identifier";
            this.columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Database Provider\'s TypeName";
            this.columnHeader2.Width = 300;
            // 
            // DbProviderToolStrip
            // 
            this.DbProviderToolStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbProviderToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveDbProviderButton});
            this.DbProviderToolStrip.Location = new System.Drawing.Point(0, 0);
            this.DbProviderToolStrip.Name = "DbProviderToolStrip";
            this.DbProviderToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.DbProviderToolStrip.Size = new System.Drawing.Size(746, 25);
            this.DbProviderToolStrip.TabIndex = 0;
            this.DbProviderToolStrip.Text = "toolStrip1";
            // 
            // RemoveDbProviderButton
            // 
            this.RemoveDbProviderButton.ForeColor = System.Drawing.Color.Maroon;
            this.RemoveDbProviderButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveDbProviderButton.Image")));
            this.RemoveDbProviderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveDbProviderButton.Name = "RemoveDbProviderButton";
            this.RemoveDbProviderButton.Size = new System.Drawing.Size(139, 22);
            this.RemoveDbProviderButton.Text = "Remove Selected！";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(970, 440);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Property Protections";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(970, 440);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Database Connections";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(970, 440);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Default Options";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // AssemblyOpenDialog
            // 
            this.AssemblyOpenDialog.DefaultExt = "dll";
            this.AssemblyOpenDialog.FileName = "Assembly";
            this.AssemblyOpenDialog.Filter = ".Net Assembly|*.dll|.Net Assembly|*.exe|All Files|*.*";
            this.AssemblyOpenDialog.Multiselect = true;
            this.AssemblyOpenDialog.Title = "Select A .Net Assembly";
            // 
            // DataAccessEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TabPagingContainer);
            this.Controls.Add(this.CaptionPanel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataAccessEditor";
            this.Size = new System.Drawing.Size(978, 501);
            this.CaptionPanel.ResumeLayout(false);
            this.CaptionPanel.PerformLayout();
            this.TabPagingContainer.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.DbProviderSplitterContainer.Panel1.ResumeLayout(false);
            this.DbProviderSplitterContainer.Panel1.PerformLayout();
            this.DbProviderSplitterContainer.Panel2.ResumeLayout(false);
            this.DbProviderSplitterContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DbProviderSplitterContainer)).EndInit();
            this.DbProviderSplitterContainer.ResumeLayout(false);
            this.DbProviderToolStrip.ResumeLayout(false);
            this.DbProviderToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CaptionPanel;
        private System.Windows.Forms.Label CaptionLabel;
        private System.Windows.Forms.ComboBox ProtectionProviderSelectionComboBox;
        private System.Windows.Forms.TabControl TabPagingContainer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.SplitContainer DbProviderSplitterContainer;
        private System.Windows.Forms.Label DescriptionLabel01;
        private System.Windows.Forms.TextBox DbProviderNameInput;
        private System.Windows.Forms.Button BrowseDbProviderButton;
        private System.Windows.Forms.Label DescriptionLabel002;
        private System.Windows.Forms.TextBox DbProviderIdentifierInput;
        private System.Windows.Forms.Panel SplitterLine01;
        private System.Windows.Forms.Button SaveDbProviderButton;
        private System.Windows.Forms.ToolStrip DbProviderToolStrip;
        private System.Windows.Forms.ToolStripButton RemoveDbProviderButton;
        private System.Windows.Forms.ListView DbProviderListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.OpenFileDialog AssemblyOpenDialog;
    }
}
