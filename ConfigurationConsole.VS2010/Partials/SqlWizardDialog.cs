#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-18 14:17:30
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
using System.Data.SqlClient;

namespace SourcePro.Csharp.Lab.Forms
{
    /// <summary>
    /// <para>
    /// 提供了构建SQL Server数据库连接串向导。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Forms"/>
    /// </para>
    /// <para>
    /// Type : <see cref="SqlWizardDialog"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Forms"/>
    partial class SqlWizardDialog
    {
        private SqlConnectionStringBuilder _selectedObject;
        private string _connectionString;

        #region ConnectionString
        public string ConnectionString
        {
            get { return _connectionString; }
            private set { _connectionString = value; }
        }
        #endregion

        #region RegisterControlsEvent
        private void RegisterControlsEvent()
        {
            this.OKMenuStripItem.Click += new EventHandler(HandleOKMenuStripItemClickEvent);
            this.CancelMenuStripItem.Click += new EventHandler(HandleCancelMenuStripItemClickEvent);
        }
        #endregion

        #region HandleCancelMenuStripItemClickEvent
        private void HandleCancelMenuStripItemClickEvent(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region HandleOKMenuStripItemClickEvent
        private void HandleOKMenuStripItemClickEvent(object sender, EventArgs e)
        {
            this.ConnectionString = this._selectedObject.ConnectionString;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        #region InitializeControls
        private void InitializeControls()
        {
            this._selectedObject = new SqlConnectionStringBuilder();
            this.SqlConnectionBuilderPropertyGrid.SelectedObject = this._selectedObject;
            this.RegisterControlsEvent();
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