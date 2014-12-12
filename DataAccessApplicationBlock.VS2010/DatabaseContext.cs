#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-12 9:46:47
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
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching;
using Configure = System.Configuration.Configuration;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 提供了访问数据库上下文的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseContext"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DatabaseSectionGroup"/>
    /// <seealso cref="DatabaseInitializer"/>
    /// <seealso cref="ConfigurationContext"/>
    /// <seealso cref="Configure"/>
    public class DatabaseContext
    {
        private DatabaseSectionGroup _configurationObject;
        private IDictionary<string, DatabaseInitializer> _initializers;
        private ConfigurationContext _configurationContext;
        static private ICache _cacheService = null;
        private const string CacheKey = "SOURCEPRO_DATACONTEXT";
        private Configure _applicationConfiguration;
        #region Default
        /// <summary>
        /// 默认的数据库上下文。
        /// </summary>
        public static readonly DatabaseContext Default = CreateDefault();
        #endregion

        #region ApplicationConfiguration
        /// <summary>
        /// 应用配置对象。
        /// </summary>
        /// <value>设置或获取应用配置对象。</value>
        protected virtual Configure ApplicationConfiguration
        {
            get { return _applicationConfiguration; }
            set { _applicationConfiguration = value; }
        }
        #endregion

        #region ConfigurationObject
        /// <summary>
        /// 数据库配置对象。
        /// </summary>
        /// <value>获取当前的数据库配置。</value>
        public virtual DatabaseSectionGroup ConfigurationObject
        {
            get { return _configurationObject; }
            protected set { _configurationObject = value; }
        }
        #endregion

        #region Initializers
        /// <summary>
        /// 用于初始化数据库属性的工具。
        /// </summary>
        /// <value>获取用于初始化数据库属性的工具。</value>
        public virtual IDictionary<string, DatabaseInitializer> Initializers
        {
            get { return _initializers; }
            protected set { _initializers = value; }
        }
        #endregion

        #region ConfigurationContext
        /// <summary>
        /// 数据库配置上下文。
        /// </summary>
        /// <value>设置或获取数据库配置上下文。</value>
        protected virtual ConfigurationContext ConfigurationContext
        {
            get { return _configurationContext; }
            set { _configurationContext = value; }
        }
        #endregion

        #region CacheService
        /// <summary>
        /// 缓存服务。
        /// </summary>
        /// <value>获取缓存服务对象实例。</value>
        static internal ICache CacheService
        {
            get
            {
                if (object.ReferenceEquals(_cacheService, null))
                {
                    ApplicationOperatingMode appMode = ApplicationOperatingModeDiscovery.AutoDiscover();
                    if (appMode == ApplicationOperatingMode.WebApplication) _cacheService = new AspCache();
                    else _cacheService = new Cache();
                }
                return _cacheService;
            }
        }
        #endregion

        #region Current
        /// <summary>
        /// 数据库上下文对象。
        /// </summary>
        /// <value>获取数据库上下文对象。</value>
        public static DatabaseContext Current
        {
            get
            {
                if (CacheService.IsExists(CacheKey))
                    return CacheService.Get(CacheKey) as DatabaseContext;
                else return null;
            }
        }
        #endregion

        #region CreateContext
        /// <summary>
        /// 创建上下文对象。
        /// </summary>
        /// <param name="configCtx">配置上下文。</param>
        /// <param name="setCurrent">是否设置为当前的数据库上下文。</param>
        /// <returns><see cref="DatabaseContext"/>对象实例。</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>当<paramref name="configCtx"/>为null时抛出此异常。</para>
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// <para>当未找到数据库配置时抛出此异常。</para>
        /// </exception>
        static public DatabaseContext CreateContext(ConfigurationContext configCtx, bool setCurrent = true)
        {
            if (object.ReferenceEquals(configCtx, null)) throw new ArgumentNullException();
            ApplicationOperatingMode mode = ApplicationOperatingModeDiscovery.AutoDiscover();
            ConfigurationManager manager = mode == ApplicationOperatingMode.WebApplication
                ? new WebConfigurationManager(configCtx as WebConfigurationContext)
                : new ConfigurationManager(configCtx);
            DatabaseSectionGroup dbConfig = manager.GetSectionGroup(DatabaseSectionGroup.GroupName) as DatabaseSectionGroup;
            if (object.ReferenceEquals(dbConfig, null)) throw new NullReferenceException("Not found database configuration!");
            DatabaseContext context = new DatabaseContext()
            {
                ApplicationConfiguration = configCtx.ConfigurationObject,
                ConfigurationContext = configCtx,
                ConfigurationObject = dbConfig
            };
            if (!object.ReferenceEquals(dbConfig.DbConnection, null) && !object.ReferenceEquals(dbConfig.DbConnection.Connections, null))
            {
                foreach (DatabaseConnectionElement item in dbConfig.DbConnection.Connections)
                {
                    context.Initializers.Add(item.Name, DatabaseInitializer.CreateInitializer(dbConfig, item.Name));
                }
            }
            if (setCurrent)
                CacheService.Add(
                    mode == ApplicationOperatingMode.WebApplication
                    ? new AspCacheItem(CacheKey, context) { Policy = new AspCacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(1), SlidingExpiration = CacheItemPolicy.NoneSlidingExpiration, Dependency = new AspCacheItemDependency(context.ApplicationConfiguration.FilePath), Priority = CacheItemPriority.Default } }
                    : new CacheItem(CacheKey, context) { Policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(1), SlidingExpiration = CacheItemPolicy.NoneSlidingExpiration, Dependency = new CacheItemDependency(context.ApplicationConfiguration.FilePath) } }
                    );
            return context;
        }
        #endregion

        #region CreateDefault
        /// <summary>
        /// 创建默认的数据库上下文。
        /// </summary>
        /// <returns><see cref="DatabaseContext"/>对象实例。</returns>
        static private DatabaseContext CreateDefault()
        {
            ApplicationOperatingMode mode = ApplicationOperatingModeDiscovery.AutoDiscover();
            return CreateContext(mode == ApplicationOperatingMode.WebApplication ? WebConfigurationContext.Default : ConfigurationContext.Default, false);
        }
        #endregion

        #region DatabaseContext Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseContext" />对象实例。
        /// </summary>
        protected DatabaseContext()
        {
            this.ConfigurationContext = null;
            this.Initializers = new Dictionary<string, DatabaseInitializer>();
            this.ConfigurationObject = null;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */