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
using SourcePro.Csharp.Lab.Commons;
using Config = System.Configuration.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using SourcePro.Csharp.Lab.Controls;

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
        private Actions _action = Actions.None;
        private string _baseConfigureFile;
        private Config _baseConfigure;
        private bool _configurationInserted = false;
        private bool _dataAccessInserted = false;

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
            this.GithubMenuStripItem.Click += new EventHandler(HandleGithubMenuItemClickEvent);
            this.LicenseMenuStripItem.Click += new EventHandler(HandelLicenseMenuItemClickEvent);
            this.NewMenuStripItem.Click += new EventHandler(HandleCreateNewMenuStripItemClickEvent);
            this.ResetMenuStripItem.Click += new EventHandler(HandleResetMenuStripItemClickEvent);
            this.ConfigurationMenuStripItem.Click += new EventHandler(HandleInsertConfigurationSourceMenuStripItemClickEvent);
        }
        #endregion

        #region HandleInsertConfigurationSourceMenuStripItemClickEvent
        private void HandleInsertConfigurationSourceMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (!this._configurationInserted)
            {
                this.SetMenuItemsEnabled(false, this.ConfigurationMenuStripItem);
                this._configurationInserted = true;
                TabPage page = new TabPage("Configuration Source");
                page.Controls.Add(new ConfigurationSourceEditor() { Dock = DockStyle.Fill, BaseConfigure = this._baseConfigure });
                this.TabPagingContainer.TabPages.Add(page);
                page.Select();
            }
        }
        #endregion

        #region HandleResetMenuStripItemClickEvent
        private void HandleResetMenuStripItemClickEvent(object sender, EventArgs e)
        {
            this._action = Actions.None;
            this._baseConfigure = null;
            this._baseConfigureFile = null;
            this.SetMenuItemsEnabled(true, this.NewMenuStripItem, this.OpenMenuStripItem, this.SaveAsMenuStripItem, this.SaveMenuStripItem);
            this.SetMenuItemsEnabled(false, this.OperateMenuStripItem);
            this.TabPagingContainer.TabPages.Clear();
            this._configurationInserted = false;
            this._dataAccessInserted = false;
        }
        #endregion

        #region SetMenuItemsEnabled
        private void SetMenuItemsEnabled(bool enabled = true, params ToolStripMenuItem[] items)
        {
            foreach (var item in items) item.Enabled = enabled;
        }
        #endregion

        #region HandleCreateNewMenuStripItemClickEvent
        private void HandleCreateNewMenuStripItemClickEvent(object sender, EventArgs e)
        {
            this._action = Actions.Create;
            this._baseConfigure = ConfigurationContext.Default.ConfigurationObject;
            this._baseConfigureFile = this._baseConfigure.FilePath;
            this.SetMenuItemsEnabled(false, this.NewMenuStripItem, this.OpenMenuStripItem, this.SaveAsMenuStripItem);
            this.SetMenuItemsEnabled(true, this.SaveMenuStripItem, this.OperateMenuStripItem, this.ConfigurationMenuStripItem, this.DataAccessMenuStripItem);
        }
        #endregion

        #region HandelLicenseMenuItemClickEvent
        private void HandelLicenseMenuItemClickEvent(object sender, EventArgs e)
        {
            using (LicenseForm licenseFrm = new LicenseForm())
            {
                licenseFrm.ShowDialog();
            }
        }
        #endregion

        #region HandleGithubMenuItemClickEvent
        private void HandleGithubMenuItemClickEvent(object sender, EventArgs e)
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