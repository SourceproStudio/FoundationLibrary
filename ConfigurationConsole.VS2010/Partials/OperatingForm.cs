#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-15 15:58:47
 * Common Language Runtime : 4.0.30319.18444
 * Minimum .Net Framework Version : 4.0
 * 
 * SourcePro Studio 2014
 * Project Url : https://github.com/SourceproStudio/CodeTemplates
 * Home Page Url : https://github.com/SourceproStudio
 * E-mail Address : MasterDuner@yeah.net or Yucai.Wang-Public@outlook.com
 * QQ : 180261899
 */

#endregion

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SourcePro.Csharp.Lab.Forms
{
    /// <summary>
    /// <para>
    /// 提供了配置操作的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Forms"/>
    /// </para>
    /// <para>
    /// Type : <see cref="OperatingForm"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Forms"/>
    partial class OperatingForm
    {
        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeForm();
        }
        #endregion

        #region InitializeFormIcon
        private void InitializeFormIcon()
        {
            using (Stream manifestResourceStream = typeof(OperatingForm).Assembly.GetManifestResourceStream("SourcePro.Csharp.Lab.Resources.Icon.ico"))
            {
                try
                {
                    this.Icon = new Icon(manifestResourceStream);
                }
                finally
                {
                    manifestResourceStream.Close();
                }
            }
        }
        #endregion

        #region ResizeForm
        private void ResizeForm()
        {
            this.Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Width * 0.9), (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.9));
        }
        #endregion

        #region RegisterFormEvents
        private void RegisterFormEvents()
        {
            this.FormClosed += new FormClosedEventHandler(HandleFormClosedEvent);
            this.GithubMenuStripItem.Click += new EventHandler(HandleGithubMenuItemClick);
        }
        #endregion

        #region HandleGithubMenuItemClick
        private void HandleGithubMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start("iexplore.exe", @"https://github.com/SourceproStudio/FoundationLibrary/releases");
            }
            catch
            {
                MessageBox.Show("Unable to open Microsoft Internet Explorer !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region HandleFormClosedEvent
        private void HandleFormClosedEvent(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region InitializeForm
        private void InitializeForm()
        {
            this.InitializeFormIcon();
            this.ResizeForm();
            this.RegisterFormEvents();
            this.InitializeControls();
        }
        #endregion

        #region InitializeControls
        private void InitializeControls()
        {
            this.InitializeCopyrightLabel();
        }
        #endregion

        #region InitializeCopyrightLabel
        private void InitializeCopyrightLabel()
        {
            int year = DateTime.Now.Year;
            this.CopyrightToolStripItem.Text = string.Format("Copyright © {0}{1}{2} Wang Yucai.", 2014, year > 2014 ? "-" : string.Empty, year > 2014 ? year.ToString() : string.Empty);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */