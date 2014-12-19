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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SourcePro.Csharp.Lab.Commons;
using SourcePro.Csharp.Lab.Controls;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using Config = System.Configuration.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Deployment;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO;

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
            this.SaveMenuStripItem.Click += new EventHandler(HandleSaveMenuStripItemClickEvent);
            this.SaveAsMenuStripItem.Click += new EventHandler(HandleSaveAsMenuStripItemClickEvent);
            this.OpenMenuStripItem.Click += new EventHandler(HandleOpenMenuStripItemClickEvent);
            this.DataAccessMenuStripItem.Click += new EventHandler(HandleInsertDataAccessMenuStripItemClickEvent);
            this.ExitMenuStripItem.Click += new EventHandler(HandleExitMenuStripItemClickEvent);
            this.GacInstallMenuStripItem.Click += new EventHandler(HandleGACInstallMenuStripItemClickEvent);
            this.EnvarMenuStripItem.Click += new EventHandler(HandleEnvironmentVariableMenuStripItemClickEvent);
        }
        #endregion

        #region HandleEnvironmentVariableMenuStripItemClickEvent
        private void HandleEnvironmentVariableMenuStripItemClickEvent(object sender, EventArgs e)
        {
            try
            {
                EnvironmentVariables.SetInstallationPathEnvironmentVariable(new ApplicationRunningDirectoryInfo(ApplicationOperatingMode.WindowsApplication).Path);
                MessageBox.Show("Set environment variable completed !", "Completed !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(string.Format("Unable to set environment variable \"{0}\" !", EnvironmentVariables.InstallationPathEnvironmentVariableName), "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region HandleGACInstallMenuStripItemClickEvent
        private void HandleGACInstallMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (OpenGACAssemblyDialog.ShowDialog() == DialogResult.OK && OpenGACAssemblyDialog.FileNames.Length > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (string item in this.OpenGACAssemblyDialog.FileNames)
                    {
                        GacInstallation.Install(item);
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Install Completed !", "Completed !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("We cannot copy the file into GAC !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region HandleExitMenuStripItemClickEvent
        private void HandleExitMenuStripItemClickEvent(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region HandleInsertDataAccessMenuStripItemClickEvent
        private void HandleInsertDataAccessMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (!this._dataAccessInserted)
            {
                this.SetMenuItemsEnabled(false, this.DataAccessMenuStripItem);
                this._dataAccessInserted = true;
                TabPage page = new TabPage("Database Access Configuration");
                page.Controls.Add(new DataAccessEditor() { Dock = DockStyle.Fill, BaseConfigure = this._baseConfigure });
                this.TabPagingContainer.TabPages.Add(page);
                page.Select();
            }
        }
        #endregion

        #region HandleOpenMenuStripItemClickEvent
        private void HandleOpenMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (this.OpenDialog.ShowDialog() == DialogResult.OK)
            {
                this._baseConfigure = ConfigurationContext.Create(this.OpenDialog.FileName).ConfigurationObject;
                this._baseConfigureFile = this._baseConfigure.FilePath;
                if (!object.ReferenceEquals(_baseConfigure.Sections[ConfigurationSourceSection.SectionName], null))
                {
                    this.SetMenuItemsEnabled(false, this.ConfigurationMenuStripItem);
                    this._configurationInserted = true;
                    TabPage page = new TabPage("Configuration Source");
                    page.Controls.Add(new ConfigurationSourceEditor() { Dock = DockStyle.Fill, BaseConfigure = this._baseConfigure });
                    this.TabPagingContainer.TabPages.Add(page);
                    page.Select();
                }
                if (!object.ReferenceEquals(_baseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null))
                {
                    this.SetMenuItemsEnabled(false, this.DataAccessMenuStripItem);
                    this._dataAccessInserted = true;
                    TabPage page = new TabPage("Database Access Configuration");
                    page.Controls.Add(new DataAccessEditor() { Dock = DockStyle.Fill, BaseConfigure = this._baseConfigure });
                    this.TabPagingContainer.TabPages.Add(page);
                    page.Select();
                }
                this.SetMenuItemsEnabled(true, this.OperateMenuStripItem, this.SaveAsMenuStripItem, this.SaveMenuStripItem);
                this.SetMenuItemsEnabled(false, this.NewMenuStripItem, this.OpenMenuStripItem);
            }
        }
        #endregion

        #region HandleSaveAsMenuStripItemClickEvent
        private void HandleSaveAsMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (this.SaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.TabPagingContainer.TabPages.Count > 0)
                {
                    foreach (TabPage item in this.TabPagingContainer.TabPages)
                    {
                        if (item.Controls[0].GetType().Equals(typeof(ConfigurationSourceEditor)))
                        {
                            (item.Controls[0] as ConfigurationSourceEditor).ResetConfigurationSource(this.SaveAsDialog.FileName);
                        }
                        if (item.Controls[0].GetType().Equals(typeof(DataAccessEditor)))
                        {
                            (item.Controls[0] as DataAccessEditor).ResetDatabaseConfiguration(this.SaveAsDialog.FileName);
                        }
                    }
                }
            }
        }
        #endregion

        #region HandleSaveMenuStripItemClickEvent
        private void HandleSaveMenuStripItemClickEvent(object sender, EventArgs e)
        {
            if (this.TabPagingContainer.TabPages.Count > 0)
            {
                foreach (TabPage item in this.TabPagingContainer.TabPages)
                {
                    if (item.Controls[0].GetType().Equals(typeof(ConfigurationSourceEditor)))
                    {
                        (item.Controls[0] as ConfigurationSourceEditor).ResetConfigurationSource();
                    }
                    if (item.Controls[0].GetType().Equals(typeof(DataAccessEditor)))
                    {
                        (item.Controls[0] as DataAccessEditor).ResetDatabaseConfiguration();
                    }
                }
            }
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
            this.SetMenuItemsEnabled(false, this.NewMenuStripItem, this.OpenMenuStripItem);
            this.SetMenuItemsEnabled(true, this.SaveMenuStripItem, this.OperateMenuStripItem, this.ConfigurationMenuStripItem, this.DataAccessMenuStripItem, this.SaveAsMenuStripItem);
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