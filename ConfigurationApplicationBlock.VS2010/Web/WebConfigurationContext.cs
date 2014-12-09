#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 15:40:46
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
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching;
using Config = System.Configuration.Configuration;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了访问ASP.NET配置上下文的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="WebConfigurationContext"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// <seealso cref="ConfigurationContext"/>
    public class WebConfigurationContext : ConfigurationContext
    {
        #region Default
        /// <summary>
        /// 默认的ASP.NET配置上下文。
        /// </summary>
        public new static readonly WebConfigurationContext Default = WebConfigurationContext.CreateDefault();
        #endregion
        private const string CacheKey = "SOURCEPROSTUDIO_CONFIGCONTEXT";

        #region CreateDefault
        /// <summary>
        /// 创建默认的ASP.NET配置上下文。
        /// </summary>
        /// <returns><see cref="WebConfigurationContext"/>对象实例。</returns>
        static private WebConfigurationContext CreateDefault()
        {
            Config config = InternalWebConfigurationManager.OpenWebConfiguration();
            ConfigurationSourceSection sources = config.GetSection(ConfigurationSourceSection.SectionName) as ConfigurationSourceSection;
            return new WebConfigurationContext() { ConfigurationObject = config, ConfigurationSources = sources };
        }
        #endregion

        #region WebConfigurationContext Constructors

        /// <summary>
        /// 用于初始化一个<see cref="WebConfigurationContext" />对象实例。
        /// </summary>
        protected WebConfigurationContext()
            : base()
        { }

        #endregion

        #region Current
        /// <summary>
        /// 当前的配置上下文。
        /// </summary>
        /// <value>获取当前的配置上下文。</value>
        static public new WebConfigurationContext Current
        {
            get
            {
                AspCache cache = new AspCache();
                return cache.IsExists(WebConfigurationContext.CacheKey) ? cache.Get(WebConfigurationContext.CacheKey) as WebConfigurationContext : null;
            }
        }
        #endregion

        #region AddContextCache
        /// <summary>
        /// 将配置上下文添加到缓存中。
        /// </summary>
        /// <param name="dependencies">缓存依赖文件。</param>
        protected override void AddContextCache(params string[] dependencies)
        {
            AspCache cache = new AspCache();
            cache.Add(new AspCacheItem(WebConfigurationContext.CacheKey, this)
            {
                Policy = new AspCacheItemPolicy()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(1),
                    SlidingExpiration = AspCacheItemPolicy.NoneSlidingExpiration,
                    Dependency = new AspCacheItemDependency(dependencies),
                    RemovedCallBack = null,
                    UpdatedCallBack = null
                }
            });
        }
        #endregion

        #region Create
        /// <summary>
        /// 依据文件创建配置上下文。
        /// </summary>
        /// <param name="fileName">自定义配置文件名称。</param>
        /// <param name="virtualPath">指定的虚拟路径。</param>
        /// <returns><see cref="WebConfigurationContext"/>对象实例。</returns>
        static public WebConfigurationContext Create(string fileName, string virtualPath = "/PrivateConfigContext")
        {
            if (string.IsNullOrWhiteSpace(fileName)) return WebConfigurationContext.Default;
            else
            {
                Config config = InternalWebConfigurationManager.OpenMappedWebConfiguration(fileName, virtualPath);
                ConfigurationSourceSection sources = config.GetSection(ConfigurationSourceSection.SectionName) as ConfigurationSourceSection;
                WebConfigurationContext context = new WebConfigurationContext()
                {
                    ConfigurationObject = config,
                    ConfigurationSources = sources
                };
                context.AddContextCache(fileName, WebConfigurationContext.Default.ConfigurationObject.FilePath);
                return context;
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */