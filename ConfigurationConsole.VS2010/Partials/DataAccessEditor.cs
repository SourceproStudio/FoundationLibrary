#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-17 14:27:13
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
using Config = System.Configuration.Configuration;
using System.Windows.Forms;
using SourcePro.Csharp.Lab.Forms;
using System.Drawing;
using SourcePro.Csharp.Practices.FoundationLibrary.Data;

namespace SourcePro.Csharp.Lab.Controls
{
    /// <summary>
    /// <para>
    /// 提供了配置数据库访问组件的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Controls"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DataAccessEditor"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Controls"/>
    partial class DataAccessEditor
    {
        private Config _baseConfigure;
        private Control _requiredFlashingControl;
        private int _ticks = 0;

        #region BaseConfigure
        public Config BaseConfigure
        {
            get { return _baseConfigure; }
            set { _baseConfigure = value; }
        }
        #endregion

        #region InitalizeProtectionsComboBox
        private void InitalizeProtectionsComboBox()
        {
            this.ProtectionProviderSelectionComboBox.Text = "(none)";
        }
        #endregion

        #region InitializeControls
        private void InitializeControls()
        {
            this.InitalizeProtectionsComboBox();
            this.RegisterControlsEvent();
        }
        #endregion

        #region RegisterControlsEvent
        private void RegisterControlsEvent()
        {
            this.BrowseDbProviderButton.Click += new EventHandler(HandleBrowseDbProviderTypesButtonClickEvent);
            this.SaveDbProviderButton.Click += new EventHandler(HandleSaveDbProviderButtonClickEvent);
            this.FlashingTimer.Tick += new EventHandler(HandleFlashingTimeTickEvent);
            this.RemoveDbProviderButton.Click += new EventHandler(HandleRemoveDbProvidersButtonClickEvent);

            this.BrowseDbProtectionButton.Click += new EventHandler(HandleBrowseDbProtectedProviderTypesButtonClickEvent);
            this.SaveDbProtectionButton.Click += new EventHandler(HandleSaveProtectedProviderButtonClickEvent);
            this.RemoveDbProtectionButton.Click += new EventHandler(HandleProtectedProvidersButtonClickEvent);

            this.BuildSQLConnectionStringButton.MouseHover += new EventHandler(HandleSqlConnectionBuilderWizardButtonMouseHoverEvent);
            this.BuildSQLConnectionStringButton.Click += new EventHandler(HandleSqlConnectionBuilderWizardButtonClickEvent);
            this.DbConnectionStringProtectionComboBox.DropDown += new EventHandler(HandleAllDbProtectedProviderDropDownEvent);
            this.CommandTimeoutProtectionComboBox.DropDown += new EventHandler(HandleAllDbProtectedProviderDropDownEvent);
            this.DefaultSchemaNameProtectionComboBox.DropDown += new EventHandler(HandleAllDbProtectedProviderDropDownEvent);
            this.DbProviderComboBox.DropDown += new EventHandler(HandleDbProviderDropDownEvent);
            this.DbProviderProtectionComboBox.DropDown += new EventHandler(HandleAllDbProtectedProviderDropDownEvent);
            this.SaveDbConnectionButton.Click += new EventHandler(HandleSaveDbConnectionButtonClickEvent);
            this.RemoveDbConnectionButton.Click += new EventHandler(HandleRemoveDbConnectionButtonClickEvent);
        }
        #endregion

        #region HandleRemoveDbConnectionButtonClickEvent
        private void HandleRemoveDbConnectionButtonClickEvent(object sender, EventArgs e)
        {
            if (!object.ReferenceEquals(this.DbConnectionListView.SelectedItems, null))
            {
                foreach (ListViewItem item in this.DbConnectionListView.SelectedItems)
                {
                    item.Font = new Font("Arial", 9, FontStyle.Italic | FontStyle.Strikeout | FontStyle.Bold);
                    item.ForeColor = Color.Red;
                    item.Tag = new { IsRemoved = true };
                }
            }
        }
        #endregion

        #region Protected
        private string Protected(string protectionName, string value, out bool protectedSuccessful)
        {
            protectedSuccessful = true;
            string typeName = string.Empty;
            foreach (ListViewItem item in this.DbProtectionListView.Items)
            {
                if (item.Text == protectionName)
                {
                    try
                    {
                        Type type = Type.GetType(item.SubItems[1].Text);
                        value = (Activator.CreateInstance(type) as IDatabasePropertyProtection).Protect(value);
                    }
                    catch
                    {
                        protectedSuccessful = false;
                    }
                    break;
                }
            }
            return value;
        }
        #endregion

        #region GetDbConnectionString
        private string GetDbConnectionString(out string protectionName)
        {
            protectionName = this.DbConnectionStringProtectionComboBox.Text;
            if (!string.IsNullOrWhiteSpace(protectionName) && protectionName != "(none protection)")
            {
                bool success = true;
                string connectionString = this.Protected(protectionName, this.DbConnectionStringInput.Text, out success);
                if (!success) protectionName = string.Empty;
                return success ? connectionString : this.DbConnectionStringInput.Text;
            }
            else
            {
                protectionName = string.Empty;
                return this.DbConnectionStringInput.Text;
            }
        }
        #endregion

        #region GetCommandTimeoutString
        private string GetCommandTimeoutString(out string protectionName)
        {
            protectionName = this.CommandTimeoutProtectionComboBox.Text;
            if (!string.IsNullOrWhiteSpace(protectionName) && protectionName != "(none protection)")
            {
                bool success = true;
                string cmdTimeoutStr = this.Protected(protectionName, this.CommandTimeoutNumUpDown.Value.ToString(), out success);
                if (!success) protectionName = string.Empty;
                return success ? cmdTimeoutStr : this.CommandTimeoutNumUpDown.Value.ToString();
            }
            else
            {
                protectionName = string.Empty;
                return this.CommandTimeoutNumUpDown.Value.ToString();
            }
        }
        #endregion

        #region GetDefaultSchemaName
        private string GetDefaultSchemaName(out string protectionName)
        {
            protectionName = this.DefaultSchemaNameProtectionComboBox.Text;
            if (!string.IsNullOrWhiteSpace(protectionName) && protectionName != "(none protection)")
            {
                bool success = true;
                string schemaName = this.Protected(protectionName, this.DefaultSchemaNameInput.Text, out success);
                if (!success) protectionName = string.Empty;
                return success ? schemaName : this.DefaultSchemaNameInput.Text;
            }
            else
            {
                protectionName = string.Empty;
                return this.DefaultSchemaNameInput.Text;
            }
        }
        #endregion

        #region GetProviderName
        private string GetProviderName(out string protectionName)
        {
            protectionName = this.DbProviderProtectionComboBox.Text;
            if (!string.IsNullOrWhiteSpace(this.DbProviderComboBox.Text) && this.DbProviderComboBox.Text != "(none database privider)")
            {
                if (!string.IsNullOrWhiteSpace(protectionName) && protectionName != "(none protection)")
                {
                    bool success = true;
                    string providerName = this.Protected(protectionName, this.DbProviderComboBox.Text, out success);
                    if (!success) protectionName = string.Empty;
                    return success ? providerName : this.DbProviderComboBox.Text;
                }
                else
                {
                    protectionName = string.Empty;
                    return this.DbProviderComboBox.Text;
                }
            }
            else
            {
                protectionName = string.Empty;
                return string.Empty;
            }
        }
        #endregion

        #region HandleSaveDbConnectionButtonClickEvent
        private void HandleSaveDbConnectionButtonClickEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DbConnectionIdentifierInput.Text))
            {
                if (!string.IsNullOrWhiteSpace(this.DbConnectionStringInput.Text))
                {
                    string connectionStringProtected = string.Empty;
                    string commandTimeoutProtected = string.Empty;
                    string schemaNameProtected = string.Empty;
                    string providerNameProtected = string.Empty;
                    bool isExist = false;
                    foreach (ListViewItem item in this.DbConnectionListView.Items)
                    {
                        if (item.Text == this.DbConnectionIdentifierInput.Text)
                        {
                            isExist = true;
                            item.SubItems[1].Text = this.GetDbConnectionString(out connectionStringProtected);
                            item.SubItems[2].Text = connectionStringProtected;
                            item.SubItems[3].Text = this.GetCommandTimeoutString(out commandTimeoutProtected);
                            item.SubItems[4].Text = commandTimeoutProtected;
                            item.SubItems[5].Text = this.GetDefaultSchemaName(out schemaNameProtected);
                            item.SubItems[6].Text = schemaNameProtected;
                            item.SubItems[7].Text = this.GetProviderName(out providerNameProtected);
                            item.SubItems[8].Text = providerNameProtected;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        ListViewItem item = new ListViewItem(this.DbConnectionIdentifierInput.Text);
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.GetDbConnectionString(out connectionStringProtected) });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = connectionStringProtected });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.GetCommandTimeoutString(out commandTimeoutProtected) });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = commandTimeoutProtected });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.GetDefaultSchemaName(out schemaNameProtected) });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = schemaNameProtected });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.GetProviderName(out providerNameProtected) });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = providerNameProtected });
                        this.DbConnectionListView.Items.Add(item);
                    }
                }
                else this.Flashing(this.DbConnectionStringInput);
            }
            else this.Flashing(this.DbConnectionIdentifierInput);
        }
        #endregion

        #region HandleDbProviderDropDownEvent
        private void HandleDbProviderDropDownEvent(object sender, EventArgs e)
        {
            this.DbProviderComboBox.Items.Clear();
            this.DbProviderComboBox.Items.Add("(none database privider)");
            foreach (ListViewItem item in this.DbProviderListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    this.DbProviderComboBox.Items.Add(item.Text);
                }
            }
        }
        #endregion

        #region HandleAllDbProtectedProviderDropDownEvent
        private void HandleAllDbProtectedProviderDropDownEvent(object sender, EventArgs e)
        {
            ComboBox sourceCtrl = sender as ComboBox;
            sourceCtrl.Items.Clear();
            sourceCtrl.Items.Add("(none protection)");
            foreach (ListViewItem item in this.DbProtectionListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    sourceCtrl.Items.Add(item.Text);
                }
            }
        }
        #endregion

        #region HandleSqlConnectionBuilderWizardButtonClickEvent
        private void HandleSqlConnectionBuilderWizardButtonClickEvent(object sender, EventArgs e)
        {
            using (SqlWizardDialog dialog = new SqlWizardDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    this.DbConnectionStringInput.Text = dialog.ConnectionString;
            }
        }
        #endregion

        #region HandleSqlConnectionBuilderWizardButtonMouseHoverEvent
        private void HandleSqlConnectionBuilderWizardButtonMouseHoverEvent(object sender, EventArgs e)
        {
            this.ButtonTooltip.Show("You can use the wizard to create SQL Server database connection strings.",
                this.BuildSQLConnectionStringButton);
        }
        #endregion

        #region HandleProtectedProvidersButtonClickEvent
        private void HandleProtectedProvidersButtonClickEvent(object sender, EventArgs e)
        {
            if (!object.ReferenceEquals(this.DbProtectionListView.SelectedItems, null) && this.DbProtectionListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.DbProtectionListView.SelectedItems)
                {
                    item.Font = new Font("Arial", 9, FontStyle.Italic | FontStyle.Strikeout | FontStyle.Bold);
                    item.ForeColor = Color.Red;
                    item.Tag = new { IsRemoved = true };
                }
            }
        }
        #endregion

        #region HandleSaveProtectedProviderButtonClickEvent
        private void HandleSaveProtectedProviderButtonClickEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DbProtectionNameInput.Text))
            {
                if (!string.IsNullOrWhiteSpace(this.DbProtectionIdentifierInput.Text))
                {
                    bool isExist = false;
                    foreach (ListViewItem item in this.DbProtectionListView.Items)
                    {
                        if (item.Text.Equals(this.DbProtectionIdentifierInput.Text))
                        {
                            item.SubItems[1].Text = this.DbProtectionNameInput.Text;
                            isExist = true; break;
                        }
                    }
                    if (!isExist)
                    {
                        ListViewItem item = new ListViewItem(this.DbProtectionIdentifierInput.Text);
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.DbProtectionNameInput.Text });
                        this.DbProtectionListView.Items.Add(item);
                    }
                }
                else this.Flashing(this.DbProtectionIdentifierInput);
            }
            else this.Flashing(this.DbProtectionNameInput);
        }
        #endregion

        #region HandleBrowseDbProtectedProviderTypesButtonClickEvent
        private void HandleBrowseDbProtectedProviderTypesButtonClickEvent(object sender, EventArgs e)
        {
            if (this.AssemblyOpenDialog.ShowDialog() == DialogResult.OK)
            {
                using (AssemblyAnalyseeDialog dialog = new AssemblyAnalyseeDialog() { Files = this.AssemblyOpenDialog.FileNames })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.DbProtectionIdentifierInput.Text = dialog.SelectedProviderName;
                        this.DbProtectionNameInput.Text = dialog.SelectedType;
                    }
                }
            }
        }
        #endregion

        #region HandleRemoveDbProvidersButtonClickEvent
        private void HandleRemoveDbProvidersButtonClickEvent(object sender, EventArgs e)
        {
            if (!object.ReferenceEquals(this.DbProviderListView.SelectedItems, null) && this.DbProviderListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.DbProviderListView.SelectedItems)
                {
                    item.Font = new Font("Arial", 9, FontStyle.Italic | FontStyle.Strikeout | FontStyle.Bold);
                    item.ForeColor = Color.Red;
                    item.Tag = new { IsRemoved = true };
                }
            }
        }
        #endregion

        #region HandleFlashingTimeTickEvent
        private void HandleFlashingTimeTickEvent(object sender, EventArgs e)
        {
            if (!object.ReferenceEquals(this._requiredFlashingControl, null))
            {
                if (this._ticks % 2 == 0)
                {
                    this._requiredFlashingControl.BackColor = Color.Yellow;
                    this._requiredFlashingControl.ForeColor = Color.Maroon;
                    this._ticks++;
                }
                else
                {
                    this._requiredFlashingControl.BackColor = Color.White;
                    this._requiredFlashingControl.ForeColor = Color.Black;
                    this._ticks++;
                }
                if (this._ticks >= 6)
                {
                    this._ticks = 0;
                    this.FlashingTimer.Enabled = false;
                }
            }
        }
        #endregion

        #region Flashing
        private void Flashing(Control ctrl)
        {
            this._requiredFlashingControl = ctrl;
            this.FlashingTimer.Enabled = true;
        }
        #endregion

        #region HandleSaveDbProviderButtonClickEvent
        private void HandleSaveDbProviderButtonClickEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DbProviderNameInput.Text))
            {
                if (!string.IsNullOrWhiteSpace(this.DbProviderIdentifierInput.Text))
                {
                    bool isExists = false;
                    foreach (ListViewItem item in this.DbProviderListView.Items)
                    {
                        if (item.Text.Equals(this.DbProviderIdentifierInput.Text))
                        {
                            item.SubItems[1].Text = this.DbProviderNameInput.Text;
                            isExists = true; break;
                        }
                    }
                    if (!isExists)
                    {
                        ListViewItem item = new ListViewItem(this.DbProviderIdentifierInput.Text);
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = this.DbProviderNameInput.Text });
                        this.DbProviderListView.Items.Add(item);
                    }
                }
                else this.Flashing(this.DbProviderIdentifierInput);
            }
            else this.Flashing(this.DbProviderNameInput);
        }
        #endregion

        #region HandleBrowseDbProviderTypesButtonClickEvent
        private void HandleBrowseDbProviderTypesButtonClickEvent(object sender, EventArgs e)
        {
            if (this.AssemblyOpenDialog.ShowDialog() == DialogResult.OK)
            {
                using (AssemblyAnalyseeDialog dialog = new AssemblyAnalyseeDialog() { Files = this.AssemblyOpenDialog.FileNames })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.DbProviderNameInput.Text = dialog.SelectedType;
                        this.DbProviderIdentifierInput.Text = dialog.SelectedProviderName;
                    }
                }
            }
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeControls();
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */