namespace SourcePro.Csharp.Examples
{
    partial class ExampleForm
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
            this.CtrlSimplifiedChineseButton = new System.Windows.Forms.Button();
            this.CtrlEnglishButton = new System.Windows.Forms.Button();
            this.CtrlExitApplicationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CtrlSimplifiedChineseButton
            // 
            this.CtrlSimplifiedChineseButton.Location = new System.Drawing.Point(35, 45);
            this.CtrlSimplifiedChineseButton.Name = "CtrlSimplifiedChineseButton";
            this.CtrlSimplifiedChineseButton.Size = new System.Drawing.Size(414, 23);
            this.CtrlSimplifiedChineseButton.TabIndex = 0;
            this.CtrlSimplifiedChineseButton.Text = "button1";
            this.CtrlSimplifiedChineseButton.UseVisualStyleBackColor = true;
            this.CtrlSimplifiedChineseButton.Click += new System.EventHandler(this.CtrlSimplifiedChineseButton_Click);
            // 
            // CtrlEnglishButton
            // 
            this.CtrlEnglishButton.Location = new System.Drawing.Point(35, 74);
            this.CtrlEnglishButton.Name = "CtrlEnglishButton";
            this.CtrlEnglishButton.Size = new System.Drawing.Size(414, 23);
            this.CtrlEnglishButton.TabIndex = 0;
            this.CtrlEnglishButton.Text = "button1";
            this.CtrlEnglishButton.UseVisualStyleBackColor = true;
            this.CtrlEnglishButton.Click += new System.EventHandler(this.CtrlEnglishButton_Click);
            // 
            // CtrlExitApplicationButton
            // 
            this.CtrlExitApplicationButton.Location = new System.Drawing.Point(35, 103);
            this.CtrlExitApplicationButton.Name = "CtrlExitApplicationButton";
            this.CtrlExitApplicationButton.Size = new System.Drawing.Size(414, 23);
            this.CtrlExitApplicationButton.TabIndex = 0;
            this.CtrlExitApplicationButton.Text = "button1";
            this.CtrlExitApplicationButton.UseVisualStyleBackColor = true;
            this.CtrlExitApplicationButton.Click += new System.EventHandler(this.CtrlExitApplicationButton_Click);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.CtrlExitApplicationButton);
            this.Controls.Add(this.CtrlEnglishButton);
            this.Controls.Add(this.CtrlSimplifiedChineseButton);
            this.Name = "ExampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExampleForm";
            this.Load += new System.EventHandler(this.ExampleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CtrlSimplifiedChineseButton;
        private System.Windows.Forms.Button CtrlEnglishButton;
        private System.Windows.Forms.Button CtrlExitApplicationButton;
    }
}