#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 14:01:51
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

using System.Web.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching
{
    /// <summary>
    /// <para>
    /// 提供了ASP.NET缓存依赖的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="AspCacheItemDependency"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    public class AspCacheItemDependency : CacheItemDependency
    {
        #region AspCacheItemDependency Constructors

        /// <summary>
        /// 用于初始化一个<see cref="AspCacheItemDependency" />对象实例。
        /// </summary>
        public AspCacheItemDependency(params string[] files)
            : base(files)
        { }

        #endregion

        #region GetDependency
        /// <summary>
        /// 获取对应的<see cref="CacheDependency"/>对象实例。
        /// </summary>
        /// <returns><see cref="CacheDependency"/>对象实例。</returns>
        public virtual CacheDependency GetDependency()
        {
            if (base.DependencyFiles.Count > 0)
            {
                string[] arrary = new string[base.DependencyFiles.Count];
                base.DependencyFiles.CopyTo(arrary, 0);
                return new CacheDependency(arrary);
            }
            else return null;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */