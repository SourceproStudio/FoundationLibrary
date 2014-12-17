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