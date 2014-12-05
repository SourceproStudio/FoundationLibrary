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
        /// <![CDATA[AspCacheItemPolicy中，不再提供缓存项更新后回调方法选项。调用时基础库将认为这是一个错误！]]>
        /// </summary>
        [Obsolete("AspCacheItemPolicy中，不再提供缓存项更新后回调方法选项。", true)]
        public override CacheItemWasUpdatedCallback UpdatedCallBack
        {
            get
            {
                return null;
            }
            set
            {
                base.UpdatedCallBack = null;
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