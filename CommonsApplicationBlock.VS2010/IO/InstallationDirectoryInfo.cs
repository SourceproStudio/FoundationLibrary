#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 10:28:56
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
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO
{
    /// <summary>
    /// <para>
    /// 提供了访问基础库安装目录信息的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InstallationDirectoryInfo"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// <seealso cref="InstallationPathNotExistsReasons"/>
    /// <seealso cref="System.IO"/>
    /// <seealso cref="DirectoryInfo"/>
    /// <seealso cref="FileInfo"/>
    /// <seealso cref="EnvironmentVariables"/>
    public class InstallationDirectoryInfo
    {
        private bool _exists = false;
        private InstallationPathNotExistsReasons _notFoundReason = InstallationPathNotExistsReasons.None;
        private string _path;
        private IList<DirectoryInfo> _subDirectories;
        private IList<FileInfo> _files;
        private DirectoryInfo _installation;

        #region Exists
        /// <summary>
        /// 安装目录是否存在。
        /// </summary>
        /// <value>获取安装目录是否存在。</value>
        public virtual bool Exists
        {
            get { return _exists; }
            protected set { _exists = value; }
        }
        #endregion

        #region NotFoundReason
        /// <summary>
        /// 导致未发现安装目录的原因。
        /// </summary>
        /// <value>获取导致未发现安装目录的原因。</value>
        public virtual InstallationPathNotExistsReasons NotFoundReason
        {
            get { return _notFoundReason; }
            protected set { _notFoundReason = value; }
        }
        #endregion

        #region Path
        /// <summary>
        /// 完整的基础库安装路径。
        /// </summary>
        /// <value>获取完整的基础库安装路径。</value>
        public virtual string Path
        {
            get { return _path; }
            protected set { _path = value; }
        }
        #endregion

        #region SubDirectories
        /// <summary>
        /// 安装目录下所有子目录。
        /// </summary>
        /// <value>获取安装目录下所有子目录。</value>
        public virtual IList<DirectoryInfo> SubDirectories
        {
            get { return _subDirectories; }
            protected set { _subDirectories = value; }
        }
        #endregion

        #region Files
        /// <summary>
        /// 安装目录下所有文件。
        /// </summary>
        /// <value>获取安装目录下所有文件。</value>
        public virtual IList<FileInfo> Files
        {
            get { return _files; }
            protected set { _files = value; }
        }
        #endregion

        #region Installation
        /// <summary>
        /// 安装目录信息。
        /// </summary>
        /// <value>设置或获取安装目录信息。</value>
        protected virtual DirectoryInfo Installation
        {
            get { return _installation; }
            set { _installation = value; }
        }
        #endregion

        #region InstallationDirectoryInfo Constructors

        /// <summary>
        /// 用于初始化一个<see cref="InstallationDirectoryInfo" />对象实例。
        /// </summary>
        public InstallationDirectoryInfo()
        {
            try
            {
                if (EnvironmentVariables.VerifyInstallationPathEnvironmentVarExists())
                {
                    this.Installation = new DirectoryInfo(EnvironmentVariables.InstallationPath);
                    this.Exists = this.Installation.Exists;
                    if (!this.Exists) this.NotFoundReason = InstallationPathNotExistsReasons.NotExists;
                    else
                    {
                        this.NotFoundReason = InstallationPathNotExistsReasons.None;
                        this.Path = this.Installation.FullName;
                        DirectoryInfo[] directories = this.Installation.GetDirectories();
                        if (!object.ReferenceEquals(directories, null) && directories.Length > 0) this.SubDirectories = new List<DirectoryInfo>(directories);
                        FileInfo[] files = this.Installation.GetFiles();
                        if (!object.ReferenceEquals(files, null) && files.Length > 0) this.Files = new List<FileInfo>(files);
                    }
                }
                this.NotFoundReason = InstallationPathNotExistsReasons.EnvironmentVariableNotFound;
            }
            catch (SecurityException)
            {
                this.NotFoundReason = InstallationPathNotExistsReasons.SecurityException;
            }
            catch (Exception)
            {
                this.NotFoundReason = InstallationPathNotExistsReasons.OtherException;
            }
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */