#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 15:11:19
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
    /// Type : <see cref="FoundationLibraryInstallationDirectoryInfo"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="FoundationLibraryInstallationDirectoryInfo"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// <remarks>
    /// Can not inherit from <see cref="FoundationLibraryInstallationDirectoryInfo"/> !
    /// </remarks>
    public sealed class FoundationLibraryInstallationDirectoryInfo
    {
        private string _name;
        private string _environmentVariableName;
        private bool _environmentVariableExists;
        private string _fullName;
        static private FoundationLibraryInstallationDirectoryInfo _installationDirectory = null;

        #region InstallationDirectory
        /// <summary>
        /// 获取基础的安装路径信息。
        /// </summary>
        static public FoundationLibraryInstallationDirectoryInfo InstallationDirectory
        {
            get
            {
                if (object.ReferenceEquals(_installationDirectory, null)) _installationDirectory = new FoundationLibraryInstallationDirectoryInfo();
                return _installationDirectory;
            }
            private set
            {
                _installationDirectory = value;
            }
        }
        #endregion

        #region Name
        /// <summary>
        /// 安装目录名称。
        /// </summary>
        /// <value>获取安装目录名称。</value>
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        #endregion

        #region EnvironmentVariableName
        /// <summary>
        /// 安装目录环境变量名称。
        /// </summary>
        /// <value>获取安装目录环境变量名称。</value>
        public string EnvironmentVariableName
        {
            get { return _environmentVariableName; }
            private set { _environmentVariableName = value; }
        }
        #endregion

        #region EnvironmentVariableExists
        /// <summary>
        /// 环境变量是否存在。
        /// </summary>
        /// <value>获取安装目录环境变量是否存在。</value>
        public bool EnvironmentVariableExists
        {
            get { return _environmentVariableExists; }
            private set { _environmentVariableExists = value; }
        }
        #endregion

        #region FullName
        /// <summary>
        /// 安装目录完整名称。
        /// </summary>
        /// <value>获取安装目录完整名称。</value>
        public string FullName
        {
            get { return _fullName; }
            private set { _fullName = value; }
        }
        #endregion

        #region CheckEnvironmentVariableExists
        /// <summary>
        /// 检查环境变量是否存在。
        /// </summary>
        /// <returns>
        /// 安装目录环境变量如果存在返回true；否则返回false。
        /// </returns>
        private bool CheckEnvironmentVariableExists()
        {
            try
            {
                this.FullName = Environment.GetEnvironmentVariable(this.EnvironmentVariableName, EnvironmentVariableTarget.Machine);
                return !string.IsNullOrWhiteSpace(this.FullName);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetAssemblyLoadedDirectory
        /// <summary>
        /// 如果环境变量不存在，则获取程序集加载目录。
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/>对象实例。</returns>
        private DirectoryInfo GetAssemblyLoadedDirectory()
        {
            return new FileInfo(typeof(Environment).Assembly.Location).Directory;
        }
        #endregion

        #region FoundationLibraryInstallationDirectoryInfo Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="FoundationLibraryInstallationDirectoryInfo" />对象实例。
        /// </para>
        /// </summary>
        private FoundationLibraryInstallationDirectoryInfo()
        {
            this.EnvironmentVariableName = FoundationLibraryConstants.InstallationPathEnvironmentVariableName;
            this.EnvironmentVariableExists = this.CheckEnvironmentVariableExists();
            if (!this.EnvironmentVariableExists)
            {
                DirectoryInfo loadedDir = this.GetAssemblyLoadedDirectory();
                this.FullName = loadedDir.FullName;
                this.Name = loadedDir.Name;
            }
            else
            {
                this.Name = new DirectoryInfo(this.FullName).Name;
            }
        }

        #endregion

        #region SubFolders
        /// <summary>
        /// 定义了安装路径下的子文件夹。
        /// </summary>
        [Serializable, Flags]
        public enum SubFolders
        {
            /// <summary>
            /// 代表根目录。
            /// </summary>
            Root = 0,
            /// <summary>
            /// 代表Bin文件夹（此文件夹中包含所有程序集）。
            /// </summary>
            Bin = 1,
            /// <summary>
            /// 配置文件文件夹。
            /// </summary>
            Config = 2,
            /// <summary>
            /// XML文档文件夹。
            /// </summary>
            Xml = 4
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */