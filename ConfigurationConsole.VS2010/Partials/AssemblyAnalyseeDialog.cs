#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-17 15:20:03
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
using System.ComponentModel;
using System.Windows.Forms;
using SourcePro.Csharp.Lab.Commons;
using System.Collections.Generic;
using System.Drawing;

namespace SourcePro.Csharp.Lab.Forms
{
    /// <summary>
    /// <para>
    /// Description
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Forms"/>
    /// </para>
    /// <para>
    /// Type : <see cref="AssemblyAnalyseeDialog"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Forms"/>
    partial class AssemblyAnalyseeDialog
    {
        private string[] _files;
        private GenerateReflectionInfoErrorHandler _errorCallback;
        private GenerateReflectionInfoCompletedHandler _completedCallback;

        #region Files
        public string[] Files
        {
            get { return _files; }
            set { _files = value; }
        }
        #endregion

        #region InitializeControls
        private void InitializeControls()
        {
            this.StatusListView.StateImageList = this.StatusImageList;
            this.RegisterControlsEvent();
            this.BackWorker.RunWorkerAsync(this);
            this.ProgressControlPanel.Show();
        }
        #endregion

        #region RegisterControlsEvent
        private void RegisterControlsEvent()
        {
            this.BackWorker.DoWork += new DoWorkEventHandler(DoBackgroundJobs);
            this._errorCallback = new GenerateReflectionInfoErrorHandler(this.UpgradeErrorStatus);
            this._completedCallback = new GenerateReflectionInfoCompletedHandler(this.AppendType);
        }
        #endregion

        #region DoBackgroundJobs
        private void DoBackgroundJobs(object sender, DoWorkEventArgs e)
        {
            foreach (string item in this.Files)
            {
                try
                {
                    DynamicAssemblyDomain domain = new DynamicAssemblyDomain(item);
                    IList<string> types = domain.GetTypes();
                    foreach (string typeItem in types)
                        this._completedCallback(typeItem);
                }
                catch
                {
                    this.UpgradeErrorStatus(item);
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

        #region UpgradeErrorStatus
        private void UpgradeErrorStatus(string fileName)
        {
            if (this.StatusListView.InvokeRequired)
            {
                this.StatusListView.Invoke(this._errorCallback, fileName);
            }
            else
            {
                ListViewItem statusItem = new ListViewItem() { ImageIndex = 0, ForeColor = Color.Red };
                statusItem.SubItems.Add("Error");
                statusItem.SubItems.Add(fileName);
                this.StatusListView.Items.Add(statusItem);
            }
        }
        #endregion

        #region AppendType
        private void AppendType(string typeName)
        {
            if (this.TypeListBox.InvokeRequired)
                this.TypeListBox.Invoke(this._completedCallback, typeName);
            else
                this.TypeListBox.Items.Add(typeName);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */