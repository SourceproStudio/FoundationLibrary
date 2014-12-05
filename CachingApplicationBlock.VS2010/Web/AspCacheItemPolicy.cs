#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 14:09:16
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
using SourcePro.Csharp.Practices.FoundationLibrary.Commons;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching
{
    /// <summary>
    /// <para>
    /// 提供了适用于ASP.NET的缓存策略。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="AspCacheItemPolicy"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// <seealso cref="CacheItemPolicy"/>
    public class AspCacheItemPolicy : CacheItemPolicy
    {
        #region UpdatedCallBack
        /// <summary>
        /// <para>Warning !</para>
        /// <para>
        /// <see cref="AspCacheItemPolicy"/>中，不再提供缓存项更新后回调方法选项。
        /// </para>
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// <see cref="AspCacheItemPolicy"/>中，不再提供缓存项更新后回调方法选项。
        /// </exception>
        [ImportantNotice("AspCacheItemPolicy中，不再提供缓存项更新后回调方法选项。")]
        public override CacheItemWasUpdatedCallback UpdatedCallBack
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Dependency
        /// <summary>
        /// 缓存依赖。
        /// </summary>
        /// <value>设置或获取<see cref="AspCacheItemDependency"/>缓存依赖。</value>
        public new AspCacheItemDependency Dependency
        {
            get
            {
                return base.Dependency as AspCacheItemDependency;
            }
            set
            {
                base.Dependency = value;
            }
        }
        #endregion

        #region AspCacheItemPolicy Constructors

        /// <summary>
        /// 用于初始化一个<see cref="AspCacheItemPolicy" />对象实例。
        /// </summary>
        public AspCacheItemPolicy()
        { }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */