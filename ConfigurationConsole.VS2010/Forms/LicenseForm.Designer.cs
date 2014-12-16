namespace SourcePro.Csharp.Lab.Forms
{
    partial class LicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.LicenseText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LicenseText
            // 
            this.LicenseText.BackColor = System.Drawing.Color.White;
            this.LicenseText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LicenseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LicenseText.Location = new System.Drawing.Point(0, 0);
            this.LicenseText.Name = "LicenseText";
            this.LicenseText.ReadOnly = true;
            this.LicenseText.Size = new System.Drawing.Size(784, 412);
            this.LicenseText.TabIndex = 1;
            this.LicenseText.Text = resources.GetString("LicenseText.Text");
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 412);
            this.Controls.Add(this.LicenseText);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LicenseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apache License";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LicenseText;
    }
}