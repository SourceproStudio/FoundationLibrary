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
using System.Drawing;
using System.Windows.Forms;
using SourcePro.Csharp.Lab.Forms;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Data;
using Config = System.Configuration.Configuration;

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
            this.InitializeControlsValues();
        }
        #endregion

        #region InitializeProtectedProviderListView
        private void InitializeProtectedProviderListView(DatabasePropertyProtectionSection configure)
        {
            if (!object.ReferenceEquals(configure, null) && !object.ReferenceEquals(configure.Protections, null))
            {
                foreach (DatabasePropertyProtectionElement item in configure.Protections)
                {
                    ListViewItem ctrlItem = new ListViewItem(item.Name);
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Type });
                    this.DbProtectionListView.Items.Add(ctrlItem);
                }
            }
        }
        #endregion

        #region InitializeDbProviderListView
        private void InitializeDbProviderListView(DatabaseAccessProviderSection configure)
        {
            if (!object.ReferenceEquals(configure, null) && !object.ReferenceEquals(configure.Providers, null))
            {
                foreach (DatabaseAccessProviderElement item in configure.Providers)
                {
                    ListViewItem ctrlItem = new ListViewItem(item.Name);
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Type });
                    this.DbProviderListView.Items.Add(ctrlItem);
                }
            }
        }
        #endregion

        #region InitializeDbConnectionListView
        private void InitializeDbConnectionListView(DatabaseConnectionSection configure)
        {
            if (!object.ReferenceEquals(configure, null) && !object.ReferenceEquals(configure.Connections, null))
            {
                foreach (DatabaseConnectionElement item in configure.Connections)
                {
                    ListViewItem ctrlItem = new ListViewItem(item.Name);
                    #region Connection String Property
                    string connectionString = item.ConnectionString;
                    string connectionStringProtected = string.Empty;
                    if (!object.ReferenceEquals(item.Protections, null) && !object.ReferenceEquals(item.Protections["connectionString"], null))
                    {
                        IsProtectedDatabasePropertyElement element = item.Protections["connectionString"];
                        connectionString = element.ProtectedValue;
                        connectionStringProtected = element.ProtectionName;
                    }
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = connectionString });
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = connectionStringProtected });
                    #endregion
                    #region Command Timeout Property
                    string commandTimeout = item.CommandTimeoutSeconds.ToString();
                    string commandTimeoutProtected = string.Empty;
                    if (!object.ReferenceEquals(item.Protections, null) && !object.ReferenceEquals(item.Protections["commandTimeoutSeconds"], null))
                    {
                        IsProtectedDatabasePropertyElement element = item.Protections["commandTimeoutSeconds"];
                        commandTimeout = element.ProtectedValue;
                        commandTimeoutProtected = element.ProtectionName;
                    }
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = commandTimeout });
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = commandTimeoutProtected });
                    #endregion
                    #region Default Schema Name Property
                    string schemaName = item.DefaultSechema;
                    string schemaNameProtected = string.Empty;
                    if (!object.ReferenceEquals(item.Protections, null) && !object.ReferenceEquals(item.Protections["defaultSechema"], null))
                    {
                        IsProtectedDatabasePropertyElement element = item.Protections["defaultSechema"];
                        schemaName = element.ProtectedValue;
                        schemaNameProtected = element.ProtectionName;
                    }
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = schemaName });
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = schemaNameProtected });
                    #endregion
                    #region Provider's Name
                    string providerName = item.Provider;
                    string providerNameProtected = string.Empty;
                    if (!object.ReferenceEquals(item.Protections, null) && !object.ReferenceEquals(item.Protections["provider"], null))
                    {
                        IsProtectedDatabasePropertyElement element = item.Protections["provider"];
                        providerName = element.ProtectedValue;
                        providerNameProtected = element.ProtectionName;
                    }
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = providerName });
                    ctrlItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = providerNameProtected });
                    #endregion
                    this.DbConnectionListView.Items.Add(ctrlItem);
                }
            }
        }
        #endregion

        #region InitializeDefaultOptionsControls
        private void InitializeDefaultOptionsControls(ListView dataSource,ComboBox target)
        {
            target.Items.Clear();
            target.Items.Add("(none)");
            foreach (ListViewItem item in dataSource.Items)
                target.Items.Add(item.Text);
        }
        #endregion

        #region InitializeDbDefaultOptions
        private void InitializeDbDefaultOptions(DefaultDatabaseOptionsSection configure)
        {
            if (!object.ReferenceEquals(configure, null))
            {
                this.InitializeDefaultOptionsControls(this.DbConnectionListView, this.DefaultDbConnectionComboBox);
                this.InitializeDefaultOptionsControls(this.DbProtectionListView, this.DefaultProtectionComboBox);
                this.InitializeDefaultOptionsControls(this.DbProviderListView, this.DefaultDbProviderComboBox);
                this.DefaultDbConnectionComboBox.Text = configure.DefaultDatabaseConnection;
                this.DefaultDbProviderComboBox.Text = configure.DefaultDatabaseProvider;
                this.DefaultProtectionComboBox.Text = configure.DefaultDatabaseProtection;
            }
        }
        #endregion

        #region InitializeControlsValues
        private void InitializeControlsValues()
        {
            DatabaseSectionGroup dbConfigure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName] as DatabaseSectionGroup;
            if (!object.ReferenceEquals(dbConfigure, null))
            {
                this.InitializeProtectedProviderListView(dbConfigure.DbProtection);
                this.InitializeDbProviderListView(dbConfigure.DbProvider);
                this.InitializeDbConnectionListView(dbConfigure.DbConnection);
                this.InitializeDbDefaultOptions(dbConfigure.DbDefaultOptions);
            }
        }
        #endregion

        #region RegisterControlsEvent
        private void RegisterControlsEvent()
        {
            this.FlashingTimer.Tick += new EventHandler(HandleFlashingTimeTickEvent);

            this.BrowseDbProviderButton.Click += new EventHandler(HandleBrowseDbProviderTypesButtonClickEvent);
            this.SaveDbProviderButton.Click += new EventHandler(HandleSaveDbProviderButtonClickEvent);
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

            this.DefaultDbProviderComboBox.DropDown += new EventHandler(HandleDefaultProviderDropDownEvent);
            this.DefaultProtectionComboBox.DropDown += new EventHandler(HandleDefaultProtectionDropDownEvent);
            this.DefaultDbConnectionComboBox.DropDown += new EventHandler(HandleDefaultConnectionDropDownEvent);
        }
        #endregion

        #region HandleDefaultConnectionDropDownEvent
        private void HandleDefaultConnectionDropDownEvent(object sender, EventArgs e)
        {
            this.DefaultDbConnectionComboBox.Items.Clear();
            this.DefaultDbConnectionComboBox.Items.Add("(none)");
            foreach (ListViewItem item in this.DbConnectionListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                    this.DefaultDbConnectionComboBox.Items.Add(item.Text);
            }
        }
        #endregion

        #region HandleDefaultProtectionDropDownEvent
        private void HandleDefaultProtectionDropDownEvent(object sender, EventArgs e)
        {
            this.DefaultProtectionComboBox.Items.Clear();
            this.DefaultProtectionComboBox.Items.Add("(none)");
            foreach (ListViewItem item in this.DbProtectionListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                    this.DefaultProtectionComboBox.Items.Add(item.Text);
            }
        }
        #endregion

        #region HandleDefaultProviderDropDownEvent
        private void HandleDefaultProviderDropDownEvent(object sender, EventArgs e)
        {
            this.DefaultDbProviderComboBox.Items.Clear();
            this.DefaultDbProviderComboBox.Items.Add("(none)");
            foreach (ListViewItem item in this.DbProviderListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                    this.DefaultDbProviderComboBox.Items.Add(item.Text);
            }
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

        #region ResetDatabaseProviderConfigure
        private DatabaseAccessProviderSection ResetDatabaseProviderConfigure(out bool isEmpty)
        {
            isEmpty = object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null)
                || object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabaseAccessProviderSection.SectionName], null);
            DatabaseAccessProviderSection configure = null;
            if (isEmpty)
            {
                configure = new DatabaseAccessProviderSection();
                configure.Providers = new DatabaseAccessProviderElementCollection();
            }
            else
            {
                configure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabaseAccessProviderSection.SectionName] as DatabaseAccessProviderSection;
                if (!object.ReferenceEquals(configure.Providers, null)) configure.Providers.Clear();
                else configure.Providers = new DatabaseAccessProviderElementCollection();
            }
            foreach (ListViewItem item in this.DbProviderListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    configure.Providers.Add(new DatabaseAccessProviderElement() { Name = item.Text, Type = item.SubItems[1].Text });
                }
            }
            this.ProtectedConfigure(configure);
            return configure;
        }
        #endregion

        #region ResetDatabaseProtectionConfigure
        private DatabasePropertyProtectionSection ResetDatabaseProtectionConfigure(out bool isEmpty)
        {
            isEmpty = object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null)
                || object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabasePropertyProtectionSection.SectionName], null);
            DatabasePropertyProtectionSection configure = null;
            if (isEmpty)
            {
                configure = new DatabasePropertyProtectionSection() { Protections = new DatabasePropertyProtectionElementCollection() };
            }
            else
            {
                configure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabasePropertyProtectionSection.SectionName] as DatabasePropertyProtectionSection;
                if (!object.ReferenceEquals(configure.Protections, null)) configure.Protections.Clear();
                else configure.Protections = new DatabasePropertyProtectionElementCollection();
            }
            foreach (ListViewItem item in this.DbProtectionListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    configure.Protections.Add(new DatabasePropertyProtectionElement() { Name = item.Text, Type = item.SubItems[1].Text });
                }
            }
            this.ProtectedConfigure(configure);
            return configure;
        }
        #endregion

        #region ResetDatabaseConnectionConfigure
        private DatabaseConnectionSection ResetDatabaseConnectionConfigure(out bool isEmpty)
        {
            isEmpty = object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null)
                || object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabaseConnectionSection.SectionName], null);
            DatabaseConnectionSection configure = null;
            if (isEmpty)
            {
                configure = new DatabaseConnectionSection() { Connections = new DatabaseConnectionElementCollection() };
            }
            else
            {
                configure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DatabaseConnectionSection.SectionName] as DatabaseConnectionSection;
                if (!object.ReferenceEquals(configure.Connections, null)) configure.Connections.Clear();
                else configure.Connections = new DatabaseConnectionElementCollection();
            }
            foreach (ListViewItem item in this.DbConnectionListView.Items)
            {
                if (object.ReferenceEquals(item.Tag, null))
                {
                    DatabaseConnectionElement element = new DatabaseConnectionElement()
                    {
                        Name = item.Text,
                        ConnectionString = string.IsNullOrWhiteSpace(item.SubItems[2].Text) ? item.SubItems[1].Text : string.Empty,
                        CommandTimeoutSeconds = string.IsNullOrWhiteSpace(item.SubItems[4].Text) ? int.Parse(item.SubItems[3].Text) : 0,
                        DefaultSechema = string.IsNullOrWhiteSpace(item.SubItems[6].Text) ? item.SubItems[5].Text : string.Empty,
                        Provider = string.IsNullOrWhiteSpace(item.SubItems[8].Text) ? item.SubItems[7].Text : string.Empty,
                        Protections = new IsProtectedDatabasePropertyElementCollection()
                    };
                    if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
                        element.Protections.Add(new IsProtectedDatabasePropertyElement() { PropertyName = "connectionString", ProtectedValue = item.SubItems[1].Text, ProtectionName = item.SubItems[2].Text });
                    if (!string.IsNullOrWhiteSpace(item.SubItems[4].Text))
                        element.Protections.Add(new IsProtectedDatabasePropertyElement() { PropertyName = "commandTimeoutSeconds", ProtectedValue = item.SubItems[3].Text, ProtectionName = item.SubItems[4].Text });
                    if (!string.IsNullOrWhiteSpace(item.SubItems[6].Text))
                        element.Protections.Add(new IsProtectedDatabasePropertyElement() { PropertyName = "defaultSechema", ProtectedValue = item.SubItems[5].Text, ProtectionName = item.SubItems[6].Text });
                    if (!string.IsNullOrWhiteSpace(item.SubItems[8].Text))
                        element.Protections.Add(new IsProtectedDatabasePropertyElement() { PropertyName = "provider", ProtectedValue = item.SubItems[7].Text, ProtectionName = item.SubItems[8].Text });
                    configure.Connections.Add(element);
                }
            }
            this.ProtectedConfigure(configure);
            return configure;
        }
        #endregion

        #region ResetDatabaseDefaultConfigure
        private DefaultDatabaseOptionsSection ResetDatabaseDefaultConfigure(out bool isEmpty)
        {
            isEmpty = object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null)
                || object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DefaultDatabaseOptionsSection.SectionName], null);
            DefaultDatabaseOptionsSection configure = null;
            if (isEmpty)
            {
                configure = new DefaultDatabaseOptionsSection();
            }
            else configure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName].Sections[DefaultDatabaseOptionsSection.SectionName] as DefaultDatabaseOptionsSection;
            configure.DefaultDatabaseConnection = string.IsNullOrWhiteSpace(this.DefaultDbConnectionComboBox.Text) || this.DefaultDbConnectionComboBox.Text.Equals("(none)")
                ? string.Empty : this.DefaultDbConnectionComboBox.Text;
            configure.DefaultDatabaseProtection = string.IsNullOrWhiteSpace(this.DefaultProtectionComboBox.Text) || this.DefaultProtectionComboBox.Text.Equals("(none)")
                ? string.Empty : this.DefaultProtectionComboBox.Text;
            configure.DefaultDatabaseProvider = string.IsNullOrWhiteSpace(this.DefaultDbProviderComboBox.Text) || this.DefaultDbProviderComboBox.Text.Equals("(none)")
                ? string.Empty : this.DefaultDbProviderComboBox.Text;
            this.ProtectedConfigure(configure);
            return configure;
        }
        #endregion

        #region ProtectedConfigure
        private void ProtectedConfigure(System.Configuration.ConfigurationSection configure)
        {
            string protectedProviderName = string.IsNullOrWhiteSpace(this.ProtectionProviderSelectionComboBox.Text) || this.ProtectionProviderSelectionComboBox.Text.Equals("(none)")
                ? string.Empty : this.ProtectionProviderSelectionComboBox.Text;
            if (string.IsNullOrWhiteSpace(protectedProviderName))
            {
                if (configure.SectionInformation.IsProtected)
                {
                    configure.SectionInformation.UnprotectSection();
                    configure.SectionInformation.ForceSave = true;
                }
            }
            else
            {
                if (!configure.SectionInformation.IsProtected)
                {
                    configure.SectionInformation.ProtectSection(protectedProviderName);
                    configure.SectionInformation.ForceSave = true;
                }
            }
        }
        #endregion

        #region ResetDatabaseConfigure
        private DatabaseSectionGroup ResetDatabaseConfigure(out bool isEmpty)
        {
            isEmpty = object.ReferenceEquals(this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName], null);
            DatabaseSectionGroup configure = null;
            bool dbConnectionIsEmpty = false;
            DatabaseConnectionSection dbConnectionConfigure = this.ResetDatabaseConnectionConfigure(out dbConnectionIsEmpty);
            bool dbProviderIsEmpty = false;
            DatabaseAccessProviderSection dbProviderConfigure = this.ResetDatabaseProviderConfigure(out dbProviderIsEmpty);
            bool dbProtectionIsEmpty = false;
            DatabasePropertyProtectionSection dbProtectionConfigure = this.ResetDatabaseProtectionConfigure(out dbProtectionIsEmpty);
            bool dbDefaultIsEmpty = false;
            DefaultDatabaseOptionsSection dbDefaultConfigure = this.ResetDatabaseDefaultConfigure(out dbDefaultIsEmpty);
            if (isEmpty)
            {
                configure = new DatabaseSectionGroup();
                this.BaseConfigure.SectionGroups.Add(DatabaseSectionGroup.GroupName, configure);
            }
            else
            {
                configure = this.BaseConfigure.SectionGroups[DatabaseSectionGroup.GroupName] as DatabaseSectionGroup;
            }
            if (dbConnectionIsEmpty)
                configure.Add(DatabaseConnectionSection.SectionName, dbConnectionConfigure);
            if (dbProviderIsEmpty)
                configure.Add(DatabaseAccessProviderSection.SectionName, dbProviderConfigure);
            if (dbProtectionIsEmpty)
                configure.Add(DatabasePropertyProtectionSection.SectionName, dbProtectionConfigure);
            if (dbDefaultIsEmpty)
                configure.Add(DefaultDatabaseOptionsSection.SectionName, dbDefaultConfigure);
            return configure;
        }
        #endregion

        #region ResetDatabaseConfiguration
        public void ResetDatabaseConfiguration(string path = "")
        {
            bool dbConfigureIsEmpty = false;
            //DatabaseSectionGroup configure = this.ResetDatabaseConfigure(out dbConfigureIsEmpty);
            //if (dbConfigureIsEmpty) this.BaseConfigure.SectionGroups.Add(DatabaseSectionGroup.GroupName, configure);
            this.ResetDatabaseConfigure(out dbConfigureIsEmpty);
            if (string.IsNullOrWhiteSpace(path))
            {
                this.BaseConfigure.Save(System.Configuration.ConfigurationSaveMode.Full);
            }
            else this.BaseConfigure.SaveAs(path, System.Configuration.ConfigurationSaveMode.Full);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */