#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-16 15:29:06
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
using System.Drawing;
using System.Windows.Forms;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions;
using Config = System.Configuration.Configuration;
using RSAProtection = System.Configuration.RsaProtectedConfigurationProvider;

namespace SourcePro.Csharp.Lab.Controls
{
    /// <summary>
    /// <para>
    /// 提供了编辑配置源的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Controls"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationSourceEditor"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Controls"/>
    partial class ConfigurationSourceEditor
    {
        private Config _baseConfigure;
        private ConfigurationSourceSection _sourceConfig;
        private RegexMatching _virtualDirMatching = new RegexMatching("^/[0-9a-zA-Z]+$");
        private bool _virtualDirectoryIsMatching = true;
        private Control _invalidControl;
        private int _flashesTimes = 0;
        private Font _removedFont = new Font("Arial", 9, FontStyle.Strikeout | FontStyle.Italic | FontStyle.Bold);

        #region BaseConfigure
        public Config BaseConfigure
        {
            get { return _baseConfigure; }
            set { _baseConfigure = value; }
        }
        #endregion

        #region RegisterControlsEvent
        private void RegisterControlsEvent()
        {
            this.CreateButton.Click += new EventHandler(HandleOkButtonClickEvent);
            this.BrowseButton.Click += new EventHandler(HandleBrowseButtonClickEvent);
            this.VirtualDirectory.TextChanged += new EventHandler(HandleVirtualDirectoryInputChangedEvent);
            this.FlashTimer.Tick += new EventHandler(HandleFlashTimerTickEvent);
            this.RemoveToolButton.Click += new EventHandler(HandleRemoveButtonClickEvent);
        }
        #endregion

        #region HandleRemoveButtonClickEvent
        private void HandleRemoveButtonClickEvent(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure you want to delete the selected items?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!object.ReferenceEquals(this.SourceList.SelectedItems, null) && this.SourceList.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in this.SourceList.SelectedItems)
                    {
                        item.Tag = new { IsRemoved = true };
                        item.Font = _removedFont;
                        item.ForeColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region HandleFlashTimerTickEvent
        private void HandleFlashTimerTickEvent(object sender, EventArgs e)
        {
            if (this._flashesTimes % 2 == 0)
                this._invalidControl.BackColor = Color.Yellow;
            else
                this._invalidControl.BackColor = Color.White;
            if (this._flashesTimes == 5)
            {
                this.FlashTimer.Enabled = false;
                this._flashesTimes = 0;
            }
            else this._flashesTimes++;
        }
        #endregion

        #region HandleVirtualDirectoryInputChangedEvent
        private void HandleVirtualDirectoryInputChangedEvent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.VirtualDirectory.Text) || _virtualDirMatching.IsMatch(this.VirtualDirectory.Text))
            {
                this._virtualDirectoryIsMatching = true;
                this.VirtualDirectory.ForeColor = Color.Black;
            }
            else
            {
                this._virtualDirectoryIsMatching = false;
                this.VirtualDirectory.ForeColor = Color.Red;
            }
        }
        #endregion

        #region HandleBrowseButtonClickEvent
        private void HandleBrowseButtonClickEvent(object sender, EventArgs e)
        {
            if (this.SourceFileSelectDialog.ShowDialog() == DialogResult.OK)
            {
                this.ConfigureSourceFileName.Text = this.SourceFileSelectDialog.FileName;
            }
        }
        #endregion

        #region MakeControlFlashes
        private void MakeControlFlashes(Control ctrl)
        {
            this._invalidControl = ctrl;
            this.FlashTimer.Enabled = true;
        }
        #endregion

        #region ValidateControlsValue
        private bool ValidateControlsValue()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(this.SectionOrGroupName.Text))
            {
                this.MakeControlFlashes(this.SectionOrGroupName);
                result = false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.ConfigureSourceFileName.Text) || this.ConfigureSourceFileName.Text == "(none)")
                {
                    this.MakeControlFlashes(this.ConfigureSourceFileName);
                    result = false;
                }
                else
                {
                    if (!this._virtualDirectoryIsMatching)
                    {
                        this.MakeControlFlashes(this.VirtualDirectory);
                        result = false;
                    }
                }
            }
            return result;
        }
        #endregion

        #region HandleOkButtonClickEvent
        private void HandleOkButtonClickEvent(object sender, EventArgs e)
        {
            if (this.ValidateControlsValue())
            {
                bool exists = false;
                foreach (ListViewItem item in this.SourceList.Items)
                {
                    if (item.Text.Equals(this.SectionOrGroupName.Text))
                    {
                        item.SubItems[1].Text = this.ConfigureSourceFileName.Text;
                        item.SubItems[2].Text = this.VirtualDirectory.Text;
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    ListViewItem item = new ListViewItem(this.SectionOrGroupName.Text);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.ConfigureSourceFileName.Text });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.VirtualDirectory.Text });
                    this.SourceList.Items.Add(item);
                }
            }
        }
        #endregion

        #region InitializeBaseSourceList
        private void InitializeBaseSourceList()
        {
            if (!object.ReferenceEquals(this.BaseConfigure, null))
            {
                this._sourceConfig = this.BaseConfigure.GetSection(ConfigurationSourceSection.SectionName) as ConfigurationSourceSection;
                if (!object.ReferenceEquals(_sourceConfig, null) && !object.ReferenceEquals(_sourceConfig.Sources, null) && _sourceConfig.Sources.Count > 0)
                {
                    foreach (ConfigurationSourceElement item in _sourceConfig.Sources)
                    {
                        ListViewItem ctrlItem = new ListViewItem(item.Name);
                        ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Path });
                        ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = item.AspNetCompatibilitySupportProperties != null ? item.AspNetCompatibilitySupportProperties.VirtualDirectory : string.Empty
                        });
                        this.SourceList.Items.Add(ctrlItem);
                    }
                }
            }
        }
        #endregion

        #region InitializeProtectionsList
        private void InitializeProtectionsList()
        {
            this.ProtectionSelector.Items.Add("(none)");
            this.ProtectionSelector.Items.Add(typeof(RSAProtection).Name);
            this.ProtectionSelector.Text = "(none)";
            if (!object.ReferenceEquals(this._sourceConfig, null) && this._sourceConfig.SectionInformation.IsProtected)
            {
                this.ProtectionSelector.Text = this._sourceConfig.SectionInformation.ProtectionProvider.Name;
            }
        }
        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            this.RegisterControlsEvent();
            this.InitializeBaseSourceList();
            this.InitializeProtectionsList();
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeControl();
        }
        #endregion

        #region ResetConfigurationSource
        internal void ResetConfigurationSource(string path = "")
        {
            bool isExists = true;
            if (object.ReferenceEquals(this._sourceConfig, null))
            {
                isExists = false;
                this._sourceConfig = new ConfigurationSourceSection() { Sources = new ConfigurationSourceElementCollection() };
            }
            else this._sourceConfig.Sources.Clear();
            foreach (ListViewItem item in this.SourceList.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    ConfigurationSourceElement element = new ConfigurationSourceElement() { Name = item.Text, Path = item.SubItems[1].Text };
                    if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
                    {
                        element.AspNetCompatibilitySupportProperties = new AspCompatiblePropertyElement() { VirtualDirectory = item.SubItems[2].Text };
                    }
                    else element.AspNetCompatibilitySupportProperties = null;
                    this._sourceConfig.Sources.Add(element);
                }
            }
            if (!isExists) this.BaseConfigure.Sections.Add(ConfigurationSourceSection.SectionName, this._sourceConfig);
            if (this.ProtectionSelector.Text != "(none)" && !this._sourceConfig.SectionInformation.IsProtected && !this._sourceConfig.ElementInformation.IsLocked)
            {
                this._sourceConfig.SectionInformation.ProtectSection(this.ProtectionSelector.Text);
                this._sourceConfig.SectionInformation.ForceSave = true;
            }
            else if (this.ProtectionSelector.Text == "(none)" && this._sourceConfig.SectionInformation.IsProtected)
            {
                this._sourceConfig.SectionInformation.UnprotectSection();
                this._sourceConfig.SectionInformation.ForceSave = true;
            }
            if (string.IsNullOrWhiteSpace(path))
                this.BaseConfigure.Save(System.Configuration.ConfigurationSaveMode.Full);
            else
                this.BaseConfigure.SaveAs(path, System.Configuration.ConfigurationSaveMode.Full);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */