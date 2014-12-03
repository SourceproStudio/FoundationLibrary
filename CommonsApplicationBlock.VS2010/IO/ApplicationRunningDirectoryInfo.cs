#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 9:36:30
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
using System.Web.Hosting;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO
{
    /// <summary>
    /// <para>
    /// 提供了访问应用运行目录信息的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ApplicationRunningDirectoryInfo"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// <seealso cref="ApplicationOperatingMode"/>
    /// <seealso cref="System.IO"/>
    /// <seealso cref="DirectoryInfo"/>
    public class ApplicationRunningDirectoryInfo
    {
        private string _folderName;
        private string _path;
        private ApplicationOperatingMode _mode;

        #region FolderName
        /// <summary>
        /// 应用运行文件夹名称。
        /// </summary>
        /// <value>获取应用运行文件夹名称。</value>
        public virtual string FolderName
        {
            get { return _folderName; }
            protected set { _folderName = value; }
        }
        #endregion

        #region Path
        /// <summary>
        /// 应用运行目录完整路径。
        /// </summary>
        /// <value>应用运行目录完整路径。</value>
        public virtual string Path
        {
            get { return _path; }
            protected set { _path = value; }
        }
        #endregion

        #region Mode
        /// <summary>
        /// 应用运行模式。
        /// </summary>
        /// <value>设置或获取应用运行模式。</value>
        protected virtual ApplicationOperatingMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        #endregion

        #region ApplicationRunningDirectoryInfo Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ApplicationRunningDirectoryInfo" />对象实例。
        /// </summary>
        /// <param name="mode">应用运行模式。</param>
        /// <exception cref="UnknownApplicationOperatingModeException">
        /// 当<paramref name="mode"/>等于<see cref="ApplicationOperatingMode"/>.Unknown时，抛出此异常。
        /// </exception>
        public ApplicationRunningDirectoryInfo(ApplicationOperatingMode mode)
        {
            if (mode == ApplicationOperatingMode.Unknown)
            {
                throw new UnknownApplicationOperatingModeException();
            }
            this.Mode = mode;
            DirectoryInfo appDirectoryInfo = this.CreateDirectoryInfoInstance();
            this.FolderName = appDirectoryInfo.Name;
            this.Path = appDirectoryInfo.FullName;
        }

        #endregion

        #region CreateDirectoryInfoInstance
        /// <summary>
        /// 创建应用运行目录信息实例。
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/>对象实例。</returns>
        protected virtual DirectoryInfo CreateDirectoryInfoInstance()
        {
            if (this.Mode == ApplicationOperatingMode.WindowsApplication)
            {
                return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                return new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */