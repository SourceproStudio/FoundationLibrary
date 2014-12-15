namespace SourcePro.Csharp.Lab.Forms
{
    partial class StartupForm
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
            this.StartupLargePictureLoader = new System.Windows.Forms.PictureBox();
            this.StartupTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StartupLargePictureLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // StartupLargePictureLoader
            // 
            this.StartupLargePictureLoader.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.StartupLargePictureLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartupLargePictureLoader.Location = new System.Drawing.Point(0, 0);
            this.StartupLargePictureLoader.Name = "StartupLargePictureLoader";
            this.StartupLargePictureLoader.Size = new System.Drawing.Size(500, 300);
            this.StartupLargePictureLoader.TabIndex = 0;
            this.StartupLargePictureLoader.TabStop = false;
            // 
            // StartupTimer
            // 
            this.StartupTimer.Enabled = true;
            this.StartupTimer.Interval = 1000;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.StartupLargePictureLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.StartupLargePictureLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox StartupLargePictureLoader;
        private System.Windows.Forms.Timer StartupTimer;
    }
}