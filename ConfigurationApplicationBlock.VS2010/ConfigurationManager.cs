#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 11:08:04
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
using Manager = System.Configuration.ConfigurationManager;
using System.Collections.Generic;
using System.Configuration;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了访问自定义配置的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationManager"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// <seealso cref="Config"/>
    /// <seealso cref="Manager"/>
    /// <seealso cref="ConfigurationContext"/>
    /// <seealso cref="ConfigurationLocation"/>
    /// <seealso cref="IDictionary{TKey,TValue}"/>
    /// <seealso cref="ConnectionStringsSection"/>
    /// <seealso cref="ConfigurationStorage"/>
    /// <seealso cref="ConfigurationSourceElement"/>
    public class ConfigurationManager
    {
        private ConfigurationContext _context;
        private IDictionary<string, string> _appSettings;
        private ConnectionStringsSection _connectionStrings;
        private ConfigurationStorage _storage;

        #region Context
        /// <summary>
        /// 自定义配置上下文。
        /// </summary>
        /// <value>设置或获取自定义配置上下文对象。</value>
        protected virtual ConfigurationContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        #endregion

        #region AppSettings
        /// <summary>
        /// AppSettings配置节字典集合。
        /// </summary>
        /// <value>获取AppSettings配置节字典集合。</value>
        public virtual IDictionary<string, string> AppSettings
        {
            get { return _appSettings; }
            protected set { _appSettings = value; }
        }
        #endregion

        #region ConnectionStrings
        /// <summary>
        /// <see cref="ConnectionStringsSection"/>配置对象。
        /// </summary>
        /// <value>获取<see cref="ConnectionStringsSection"/>配置对象。</value>
        public virtual ConnectionStringsSection ConnectionStrings
        {
            get { return _connectionStrings; }
            protected set { _connectionStrings = value; }
        }
        #endregion

        #region Storage
        /// <summary>
        /// 用于保存配置信息的工具。
        /// </summary>
        /// <value>设置或获取用于保存配置信息的工具。</value>
        protected virtual ConfigurationStorage Storage
        {
            get { return _storage; }
            set { _storage = value; }
        }
        #endregion

        #region Initialize
        /// <summary>
        /// 初始化。
        /// </summary>
        protected virtual void Initialize()
        {
            this.Storage = new ConfigurationStorage();
            this.AppSettings = new Dictionary<string, string>();
            AppSettingsSection settings = this.Context.ConfigurationObject.AppSettings;
            foreach (KeyValueConfigurationElement item in settings.Settings)
            {
                this.AppSettings.Add(item.Key, item.Value);
            }
            this.ConnectionStrings = this.Context.ConfigurationObject.ConnectionStrings;
        }
        #endregion

        #region ConfigurationManager Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ConfigurationManager" />对象实例。
        /// </summary>
        /// <param name="ctx">自定义配置上下文。</param>
        public ConfigurationManager(ConfigurationContext ctx)
        {
            this.Context = ctx;
            this.Initialize();
        }

        /// <summary>
        /// 用于初始化一个<see cref="ConfigurationManager" />对象实例。
        /// </summary>
        public ConfigurationManager()
            : this(ConfigurationContext.Default)
        {
        }

        #endregion

        #region GetSectionGroup
        /// <summary>
        /// 获取指定名称的自定义配置组。
        /// </summary>
        /// <param name="sectionGroupName">自定义配置组名称。</param>
        /// <returns>自定义配置对象。</returns>
        public virtual ConfigurationSectionGroup GetSectionGroup(string sectionGroupName)
        {
            if (this.Storage.IsExists(sectionGroupName))
                return this.Storage.Get(sectionGroupName) as ConfigurationSectionGroup;
            else
            {
                ConfigurationSourceElement source = this.GetConfigurationSource(sectionGroupName);
                Config configurationObject = null;
                if (!object.ReferenceEquals(source, null) && !string.IsNullOrWhiteSpace(source.Path))
                {
                    configurationObject = this.GetSourceConfiguration(source);
                }
                else configurationObject = this.Context.ConfigurationObject;
                ConfigurationSectionGroup sectionGroup = configurationObject.GetSectionGroup(sectionGroupName);
                this.Storage.Save(sectionGroupName, sectionGroup, configurationObject.FilePath, this.Context.ConfigurationObject.FilePath);
                return sectionGroup;
            }
        }
        #endregion

        #region GetSection
        /// <summary>
        /// 获取指定名称的自定义配置节。
        /// </summary>
        /// <param name="sectionName">自定义配置节名称。</param>
        /// <returns>自定义配置对象。</returns>
        public virtual ConfigurationSection GetSection(string sectionName)
        {
            if (this.Storage.IsExists(sectionName))
                return this.Storage.Get(sectionName) as ConfigurationSection;
            else
            {
                ConfigurationSourceElement source = this.GetConfigurationSource(sectionName);
                Config configurationObject = null;
                if (!object.ReferenceEquals(source, null) && !string.IsNullOrWhiteSpace(source.Path))
                {
                    configurationObject = this.GetSourceConfiguration(source);
                }
                else configurationObject = this.Context.ConfigurationObject;
                ConfigurationSection section = configurationObject.GetSection(sectionName);
                this.Storage.Save(sectionName, section, configurationObject.FilePath, this.Context.ConfigurationObject.FilePath);
                return section;
            }
        }
        #endregion

        #region GetConfigurationSource
        /// <summary>
        /// 获取自定义配置节（组）对应的配置源。
        /// </summary>
        /// <param name="sectionName">配置节（组）名称。</param>
        /// <returns>配置源。</returns>
        protected virtual ConfigurationSourceElement GetConfigurationSource(string sectionName)
        {
            if (object.ReferenceEquals(this.Context.ConfigurationSources, null)) return null;
            else
            {
                ConfigurationSourceElement source = this.Context.ConfigurationSources.Sources[sectionName];
                return source;
            }
        }
        #endregion

        #region GetSourceConfiguration
        /// <summary>
        /// 获取指定源文件的配置。
        /// </summary>
        /// <param name="source">自定义配置源。</param>
        /// <returns><see cref="Config"/>对象实例。</returns>
        protected virtual Config GetSourceConfiguration(ConfigurationSourceElement source)
        {
            ConfigurationLocation location = new ConfigurationLocation(source);
            if (location.IsExists)
                return InternalConfigurationManager.OpenMappedExeConfiguration(location.Path);
            else
                return null;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */