#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-08 15:44:30
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
using System.Text.RegularExpressions;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了访问配置文件加载路径的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationLocation"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// <seealso cref="ConfigurationSourceElement"/>
    public class ConfigurationLocation
    {
        private bool _isExists = false;
        private string _path = string.Empty;

        #region IsExists
        /// <summary>
        /// 自定义配置文件是否存在。
        /// </summary>
        /// <value>获取自定义配置文件是否存在。</value>
        public virtual bool IsExists
        {
            get { return _isExists; }
            protected set { _isExists = value; }
        }
        #endregion

        #region Path
        /// <summary>
        /// 自定义配置文件路径。
        /// </summary>
        /// <value>获取自定义配置文件路径。</value>
        public virtual string Path
        {
            get { return _path; }
            protected set { _path = value; }
        }
        #endregion

        #region ConfigurationLocation Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ConfigurationLocation" />对象实例。
        /// </summary>
        /// <param name="config"><see cref="ConfigurationSourceElement"/>对象实例。</param>
        public ConfigurationLocation(ConfigurationSourceElement config)
        {
            if (!string.IsNullOrWhiteSpace(config.Path))
            {
                this.Path = this.GetPath(config.Path);
                this.IsExists = System.IO.File.Exists(this.Path);
            }
        }

        #endregion

        #region GetPath
        /// <summary>
        /// 获取自定配置文件最终路径。
        /// </summary>
        /// <param name="path">原始路径。</param>
        /// <returns>路径。</returns>
        protected virtual string GetPath(string path)
        {
            ConfigurationLocationValidation validation = new ConfigurationLocationValidation(path);
            if (validation.EnvironmentVarStart)
            {
                string envValue = Environment.GetEnvironmentVariable(validation.EnvironmentVariableName, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrWhiteSpace(envValue)) envValue = @"\";
                return new EnvironmentVariableRegexMatching(validation.EnvironmentVariableName).Replace(
                        path,
                        validation.FollowEnvironmentVar.Equals('\\') ? envValue.TrimEnd('\\') : envValue.TrimEnd('\\') + @"\",
                        RegexOptions.IgnoreCase
                    );
            }
            else if (validation.WaveStart)
            {
                string appDir = new ApplicationRunningDirectoryInfo(ApplicationOperatingModeDiscovery.AutoDiscover()).Path;
                return path.Replace("~",
                    validation.FollowWave.Equals('\\') ? appDir.TrimEnd('\\') : appDir.TrimEnd('\\') + @"\"
                    );
            }
            else return path;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */