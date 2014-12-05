#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 15:07:31
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching
{
    /// <summary>
    /// <para>
    /// 适用于ASP.NET的缓存项。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="AspCacheItem"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    public class AspCacheItem : CacheItem
    {
        #region AspCacheItem Constructors

        /// <summary>
        /// 用于初始化一个<see cref="AspCacheItem" />对象实例。
        /// </summary>
        public AspCacheItem()
            : base()
        { }

        /// <summary>
        /// 用于初始化一个<see cref="AspCacheItem" />对象实例。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">缓存数据。</param>
        public AspCacheItem(string key, object data)
            : base(key, data)
        {
        }

        #endregion

        #region Policy
        /// <summary>
        /// 缓存策略。
        /// </summary>
        /// <value>设置或获取<see cref="AspCacheItemPolicy"/>缓存策略。</value>
        public new AspCacheItemPolicy Policy
        {
            get
            {
                return base.Policy as AspCacheItemPolicy;
            }
            set
            {
                base.Policy = value;
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */