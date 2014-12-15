#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-15 14:34:07
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

namespace SourcePro.Csharp.Lab.Forms
{
    /// <summary>
    /// <para>
    /// 提供了启动窗体所需的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Forms"/>
    /// </para>
    /// <para>
    /// Type : <see cref="StartupForm"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="StartupForm"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Forms"/>
    /// <remarks>
    /// Can not inherit from <see cref="StartupForm"/> !
    /// </remarks>
    partial class StartupForm
    {
        private int _seconds = 0;

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeVariables();
            this.InitializeForm();
        }
        #endregion

        #region InitializeStartupPicture
        private void InitializeStartupPicture()
        {
            using (Stream manifestResourceStream = typeof(StartupForm).Assembly.GetManifestResourceStream("SourcePro.Csharp.Lab.Resources.Startup.png"))
            {
                try
                {
                    this.StartupLargePictureLoader.Image = Image.FromStream(manifestResourceStream);
                }
                finally
                {
                    manifestResourceStream.Close();
                }
            }
        }
        #endregion

        #region RegisterStartupTimerEvent
        private void RegisterStartupTimerEvent()
        {
            this.StartupTimer.Tick += new EventHandler(HandleTimerTickEvent);
        }
        #endregion

        #region HandleTimerTickEvent
        private void HandleTimerTickEvent(object sender, EventArgs e)
        {
            if (this._seconds <= 5)
            {
                this._seconds++;
            }
            else
            {
                this.StartupTimer.Enabled = false;
                OperatingForm operatingForm = new OperatingForm();
                operatingForm.Show();
                this.Hide();
            }
        }
        #endregion

        #region InitializeControls
        private void InitializeControls()
        {
            this.InitializeStartupPicture();
            this.RegisterStartupTimerEvent();
        }
        #endregion

        #region InitializeForm
        private void InitializeForm()
        {
            this.InitializeControls();
        }
        #endregion

        #region InitializeVariables
        private void InitializeVariables()
        {
            this._seconds = 0;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */