namespace SourcePro.Csharp.Lab.Forms
{
    partial class SqlWizardDialog
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.OperateMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OKMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SqlConnectionBuilderPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainMenuStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OperateMenuStripItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenuStrip.Size = new System.Drawing.Size(494, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // OperateMenuStripItem
            // 
            this.OperateMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OKMenuStripItem,
            this.CancelMenuStripItem});
            this.OperateMenuStripItem.Name = "OperateMenuStripItem";
            this.OperateMenuStripItem.Size = new System.Drawing.Size(63, 20);
            this.OperateMenuStripItem.Text = "&Operate";
            // 
            // OKMenuStripItem
            // 
            this.OKMenuStripItem.Name = "OKMenuStripItem";
            this.OKMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OKMenuStripItem.Size = new System.Drawing.Size(175, 22);
            this.OKMenuStripItem.Text = "OK";
            // 
            // CancelMenuStripItem
            // 
            this.CancelMenuStripItem.Name = "CancelMenuStripItem";
            this.CancelMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.CancelMenuStripItem.Size = new System.Drawing.Size(175, 22);
            this.CancelMenuStripItem.Text = "&Cancel";
            // 
            // SqlConnectionBuilderPropertyGrid
            // 
            this.SqlConnectionBuilderPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SqlConnectionBuilderPropertyGrid.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqlConnectionBuilderPropertyGrid.Location = new System.Drawing.Point(0, 24);
            this.SqlConnectionBuilderPropertyGrid.Name = "SqlConnectionBuilderPropertyGrid";
            this.SqlConnectionBuilderPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.SqlConnectionBuilderPropertyGrid.Size = new System.Drawing.Size(494, 348);
            this.SqlConnectionBuilderPropertyGrid.TabIndex = 1;
            // 
            // SqlWizardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 372);
            this.Controls.Add(this.SqlConnectionBuilderPropertyGrid);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SqlWizardDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Microsoft SQL Server ConnectionString Wizard";
            this.TopMost = true;
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OperateMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem OKMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem CancelMenuStripItem;
        private System.Windows.Forms.PropertyGrid SqlConnectionBuilderPropertyGrid;
    }
}