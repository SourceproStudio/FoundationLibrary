#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 16:27:45
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了缓存ASP.NET配置信息的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="WebConfigurationStorage"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// <seealso cref="ConfigurationStorage"/>
    /// <seealso cref="AspCache"/>
    public class WebConfigurationStorage : ConfigurationStorage
    {
        AspCache cache = new AspCache();

        #region WebConfigurationStorage Constructors

        /// <summary>
        /// 用于初始化一个<see cref="WebConfigurationStorage" />对象实例。
        /// </summary>
        public WebConfigurationStorage()
            : base()
        { }

        #endregion

        #region Save
        /// <summary>
        /// 保存到缓存区。
        /// </summary>
        /// <param name="sectionName">自定义配置节（组）名称。</param>
        /// <param name="section">自定义配置节（组）。</param>
        /// <param name="dependencies">缓存依赖文件。</param>
        public override void Save(string sectionName, object section, params string[] dependencies)
        {
            cache.Add(new AspCacheItem(sectionName, section)
            {
                Policy = new AspCacheItemPolicy()
                {
                    AbsoluteExpiration = DateTime.Now.AddDays(1),
                    SlidingExpiration = AspCacheItemPolicy.NoneSlidingExpiration,
                    Dependency = new AspCacheItemDependency(dependencies),
                    Priority = CacheItemPriority.Default,
                    RemovedCallBack = null,
                    UpdatedCallBack = null
                }
            });
        }
        #endregion

        #region IsExists
        /// <summary>
        /// 验证是否缓存了配置节（组）信息。
        /// </summary>
        /// <param name="sectionName">配置节（组）名称。</param>
        /// <returns>是否已经写入缓存。</returns>
        public override bool IsExists(string sectionName)
        {
            return cache.IsExists(sectionName);
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取已经缓存的配置。
        /// </summary>
        /// <param name="sectionName">自定义配置节名称。</param>
        /// <returns>配置对象。</returns>
        public override object Get(string sectionName)
        {
            return this.cache.Get(sectionName);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */