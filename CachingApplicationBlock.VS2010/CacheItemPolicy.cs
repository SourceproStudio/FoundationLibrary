#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 10:45:57
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 提供了访问缓存策略的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItemPolicy"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    [Serializable]
    public class CacheItemPolicy
    {
        private DateTime _absoluteExpiration;
        private TimeSpan _slidingExpiration;
        private IList<string> _dependencies;
        private CacheItemWasRemovedCallback _removedCallBack;
        private CacheItemWasUpdatedCallback _updatedCallBack;

        #region AbsoluteExpiration
        /// <summary>
        /// 缓存绝对失效时间。
        /// </summary>
        /// <value>设置或获取缓存项绝对失效时间。</value>
        public virtual DateTime AbsoluteExpiration
        {
            get { return _absoluteExpiration; }
            set { _absoluteExpiration = value; }
        }
        #endregion

        #region SlidingExpiration
        /// <summary>
        /// 滑动的缓存项失效时间设定。
        /// </summary>
        /// <value>设置或获取滑动的缓存项失效时间设定。</value>
        public virtual TimeSpan SlidingExpiration
        {
            get { return _slidingExpiration; }
            set { _slidingExpiration = value; }
        }
        #endregion

        #region Dependencies
        /// <summary>
        /// 缓存项依赖的文件。
        /// </summary>
        /// <value>获取缓存项依赖的文件。</value>
        public virtual IList<string> Dependencies
        {
            get { return _dependencies; }
            protected set { _dependencies = value; }
        }
        #endregion

        #region RemovedCallBack
        /// <summary>
        /// 缓存项被移除后执行的回调方法。
        /// </summary>
        /// <value>设置或获取缓存项被移除后执行的回调方法。</value>
        public virtual CacheItemWasRemovedCallback RemovedCallBack
        {
            get { return _removedCallBack; }
            set { _removedCallBack = value; }
        }
        #endregion

        #region UpdatedCallBack
        /// <summary>
        /// 缓存项被更新后执行的回调方法。
        /// </summary>
        /// <value>设置或获取缓存项被更新后执行的回调方法。</value>
        public virtual CacheItemWasUpdatedCallback UpdatedCallBack
        {
            get { return _updatedCallBack; }
            set { _updatedCallBack = value; }
        }
        #endregion

        #region CacheItemPolicy Constructors

        /// <summary>
        /// 用于初始化一个<see cref="CacheItemPolicy" />对象实例。
        /// </summary>
        public CacheItemPolicy()
        { }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */