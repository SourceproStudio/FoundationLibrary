#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 10:39:38
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
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;
using Config = System.Configuration.Configuration;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了访问配置上下文的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationContext"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// <seealso cref="Config"/>
    public class ConfigurationContext
    {
        #region Default
        /// <summary>
        /// 默认上下文。
        /// </summary>
        static public readonly ConfigurationContext Default = ConfigurationContext.CreateDefault();
        #endregion
        private Config _configurationObject;
        private ConfigurationSourceSection _configurationSources;
        private const string CacheKey = "SOURCEPROSTUDIO_CONFIGCONTEXT";

        #region ConfigurationObject
        /// <summary>
        /// 配置对象。
        /// </summary>
        /// <value>获取关联的上下文配置对象。</value>
        public virtual Config ConfigurationObject
        {
            get { return _configurationObject; }
            protected set { _configurationObject = value; }
        }
        #endregion

        #region ConfigurationSources
        /// <summary>
        /// 配置源。
        /// </summary>
        /// <value>获取当前配置对象中的配置源。</value>
        public virtual ConfigurationSourceSection ConfigurationSources
        {
            get { return _configurationSources; }
            protected set { _configurationSources = value; }
        }
        #endregion

        #region Current
        /// <summary>
        /// 当前使用的配置上下文。
        /// </summary>
        /// <value>获取当前线程使用的配置上下文。</value>
        static public ConfigurationContext Current
        {
            get
            {
                Cache cache = new Cache();
                if (cache.IsExists(ConfigurationContext.CacheKey))
                    return cache.Get(ConfigurationContext.CacheKey) as ConfigurationContext;
                else return null;
            }
        }
        #endregion

        #region CreateDefault
        /// <summary>
        /// 创建默认配置上下文。
        /// </summary>
        /// <returns><see cref="ConfigurationContext"/>对象实例。</returns>
        static private ConfigurationContext CreateDefault()
        {
            ApplicationOperatingMode mode = ApplicationOperatingModeDiscovery.AutoDiscover();
            if (mode != ApplicationOperatingMode.Unknown && mode != ApplicationOperatingMode.WebApplication)
            {
                Config config = InternalConfigurationManager.OpenExeConfiguration();
                ConfigurationSourceSection sourcesSection = config.GetSection(ConfigurationSourceSection.SectionName) as ConfigurationSourceSection;
                return new ConfigurationContext() { ConfigurationObject = config, ConfigurationSources = sourcesSection };
            }
            else return null;
        }
        #endregion

        #region ConfigurationContext Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ConfigurationContext" />对象实例。
        /// </summary>
        protected ConfigurationContext()
        { }

        #endregion

        #region Create
        /// <summary>
        /// 使用指定配置文件创建上下文。
        /// </summary>
        /// <param name="fileName">指定配置文件完整名称。</param>
        /// <returns><see cref="ConfigurationContext"/>对象实例。</returns>
        /// <exception cref="FileNotFoundException">
        /// 当<paramref name="fileName"/>指定的配置文件不存在时抛出此异常。
        /// </exception>
        /// <remarks>
        /// 当<paramref name="fileName"/>采用默认值时，将以应用配置文件app.config创建上下文。
        /// </remarks>
        static public ConfigurationContext Create(string fileName = "")
        {
            if (!string.IsNullOrWhiteSpace(fileName) && !File.Exists(fileName)) throw new FileNotFoundException("Configuration file not found !", fileName);
            if (string.IsNullOrWhiteSpace(fileName))
                return ConfigurationContext.Default;
            else
            {
                Config config = InternalConfigurationManager.OpenMappedExeConfiguration(fileName);
                ConfigurationSourceSection sourcesSection = config.GetSection(ConfigurationSourceSection.SectionName) as ConfigurationSourceSection;
                ConfigurationContext context = new ConfigurationContext() { ConfigurationObject = config, ConfigurationSources = sourcesSection };
                context.AddContextCache(fileName);
                return context;
            }
        }
        #endregion

        #region AddContextCache
        /// <summary>
        /// 将此上下文对象写入缓存。
        /// </summary>
        /// <param name="dependencies">缓存依赖文件。</param>
        protected virtual void AddContextCache(params string[] dependencies)
        {
            Cache cache = new Cache();
            cache.Add(new CacheItem(ConfigurationContext.CacheKey, this)
            {
                Policy = new CacheItemPolicy()
                {
                    AbsoluteExpiration = DateTime.Now.AddDays(1),
                    SlidingExpiration = CacheItemPolicy.NoneSlidingExpiration,
                    Dependency = new CacheItemDependency(dependencies),
                    Priority = CacheItemPriority.Default,
                    RemovedCallBack = null,
                    UpdatedCallBack = null
                }
            });
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */