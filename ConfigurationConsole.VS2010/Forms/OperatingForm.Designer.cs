namespace SourcePro.Csharp.Lab.Forms
{
    partial class OperatingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatingForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperateMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAccessMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LicenseMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GithubMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GacInstallMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnvarMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CopyrightToolStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenuStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainMenuStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuStripItem,
            this.OperateMenuStripItem,
            this.SettingMenuStripItem,
            this.HelpMenuStripItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileMenuStripItem
            // 
            this.FileMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuStripItem,
            this.OpenMenuStripItem,
            this.toolStripSeparator1,
            this.SaveMenuStripItem,
            this.SaveAsMenuStripItem,
            this.toolStripSeparator2,
            this.ExitMenuStripItem});
            this.FileMenuStripItem.Name = "FileMenuStripItem";
            this.FileMenuStripItem.Size = new System.Drawing.Size(39, 20);
            this.FileMenuStripItem.Text = "&File";
            // 
            // NewMenuStripItem
            // 
            this.NewMenuStripItem.Name = "NewMenuStripItem";
            this.NewMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuStripItem.Size = new System.Drawing.Size(189, 22);
            this.NewMenuStripItem.Text = "&New";
            // 
            // OpenMenuStripItem
            // 
            this.OpenMenuStripItem.Name = "OpenMenuStripItem";
            this.OpenMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuStripItem.Size = new System.Drawing.Size(189, 22);
            this.OpenMenuStripItem.Text = "&Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // SaveMenuStripItem
            // 
            this.SaveMenuStripItem.Name = "SaveMenuStripItem";
            this.SaveMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuStripItem.Size = new System.Drawing.Size(189, 22);
            this.SaveMenuStripItem.Text = "&Save";
            // 
            // SaveAsMenuStripItem
            // 
            this.SaveAsMenuStripItem.Name = "SaveAsMenuStripItem";
            this.SaveAsMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsMenuStripItem.Size = new System.Drawing.Size(189, 22);
            this.SaveAsMenuStripItem.Text = "Save &As";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // ExitMenuStripItem
            // 
            this.ExitMenuStripItem.Name = "ExitMenuStripItem";
            this.ExitMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuStripItem.Size = new System.Drawing.Size(189, 22);
            this.ExitMenuStripItem.Text = "E&xit";
            // 
            // HelpMenuStripItem
            // 
            this.HelpMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LicenseMenuStripItem,
            this.GithubMenuStripItem,
            this.toolStripSeparator3,
            this.AboutMenuStripItem});
            this.HelpMenuStripItem.Name = "HelpMenuStripItem";
            this.HelpMenuStripItem.Size = new System.Drawing.Size(45, 20);
            this.HelpMenuStripItem.Text = "&Help";
            // 
            // OperateMenuStripItem
            // 
            this.OperateMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationMenuStripItem,
            this.DataAccessMenuStripItem});
            this.OperateMenuStripItem.Name = "OperateMenuStripItem";
            this.OperateMenuStripItem.Size = new System.Drawing.Size(63, 20);
            this.OperateMenuStripItem.Text = "&Operate";
            // 
            // ConfigurationMenuStripItem
            // 
            this.ConfigurationMenuStripItem.Name = "ConfigurationMenuStripItem";
            this.ConfigurationMenuStripItem.Size = new System.Drawing.Size(152, 22);
            this.ConfigurationMenuStripItem.Text = "&Configuration";
            // 
            // DataAccessMenuStripItem
            // 
            this.DataAccessMenuStripItem.Name = "DataAccessMenuStripItem";
            this.DataAccessMenuStripItem.Size = new System.Drawing.Size(152, 22);
            this.DataAccessMenuStripItem.Text = "&Data Access";
            // 
            // LicenseMenuStripItem
            // 
            this.LicenseMenuStripItem.Name = "LicenseMenuStripItem";
            this.LicenseMenuStripItem.Size = new System.Drawing.Size(181, 22);
            this.LicenseMenuStripItem.Text = "&License";
            // 
            // GithubMenuStripItem
            // 
            this.GithubMenuStripItem.Image = ((System.Drawing.Image)(resources.GetObject("GithubMenuStripItem.Image")));
            this.GithubMenuStripItem.Name = "GithubMenuStripItem";
            this.GithubMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.GithubMenuStripItem.Size = new System.Drawing.Size(181, 22);
            this.GithubMenuStripItem.Text = "&Github";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // AboutMenuStripItem
            // 
            this.AboutMenuStripItem.Name = "AboutMenuStripItem";
            this.AboutMenuStripItem.Size = new System.Drawing.Size(181, 22);
            this.AboutMenuStripItem.Text = "&About me";
            // 
            // SettingMenuStripItem
            // 
            this.SettingMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GacInstallMenuStripItem,
            this.EnvarMenuStripItem});
            this.SettingMenuStripItem.Name = "SettingMenuStripItem";
            this.SettingMenuStripItem.Size = new System.Drawing.Size(57, 20);
            this.SettingMenuStripItem.Text = "&Setting";
            // 
            // GacInstallMenuStripItem
            // 
            this.GacInstallMenuStripItem.Name = "GacInstallMenuStripItem";
            this.GacInstallMenuStripItem.Size = new System.Drawing.Size(190, 22);
            this.GacInstallMenuStripItem.Text = "GAC &Install";
            // 
            // EnvarMenuStripItem
            // 
            this.EnvarMenuStripItem.Name = "EnvarMenuStripItem";
            this.EnvarMenuStripItem.Size = new System.Drawing.Size(190, 22);
            this.EnvarMenuStripItem.Text = "&Environment Variable";
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainStatusStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyrightToolStripItem});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 340);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // CopyrightToolStripItem
            // 
            this.CopyrightToolStripItem.ForeColor = System.Drawing.Color.DarkGray;
            this.CopyrightToolStripItem.Name = "CopyrightToolStripItem";
            this.CopyrightToolStripItem.Size = new System.Drawing.Size(0, 17);
            // 
            // OperatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OperatingForm";
            this.Text = "C# FoundationLibrary Configuration Console";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem NewMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem OperateMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem DataAccessMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem LicenseMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem GithubMenuStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem GacInstallMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem EnvarMenuStripItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CopyrightToolStripItem;
    }
}