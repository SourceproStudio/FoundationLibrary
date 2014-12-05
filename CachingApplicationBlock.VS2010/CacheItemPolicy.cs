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
        private CacheItemWasRemovedCallback _removedCallBack;
        private CacheItemWasUpdatedCallback _updatedCallBack;
        private CacheItemPriority _priority;
        #region NoneAbsoluteExpiration
        /// <summary>
        /// 无效的绝对缓存项失效时间。
        /// </summary>
        public static readonly DateTime NoneAbsoluteExpiration = new DateTime(1983, 9, 15, 0, 0, 0, 0);
        #endregion
        #region NoneSlidingExpiration
        /// <summary>
        /// 无效的滑动缓存项失效时间设置。
        /// </summary>
        public static readonly TimeSpan NoneSlidingExpiration = new TimeSpan(0, 0, 0, 0, 1);
        private CacheItemDependency _dependency;
        #endregion

        #region ExpirationOption
        /// <summary>
        /// 缓存项失效选项。
        /// </summary>
        /// <value>获取缓存项失效选项。</value>
        public virtual CacheItemExpirationOptions ExpirationOption
        {
            get
            {
                if ((this.AbsoluteExpiration - CacheItemPolicy.NoneAbsoluteExpiration).TotalMilliseconds > 0 && (this.AbsoluteExpiration - DateTime.Now).TotalMilliseconds > 0)
                {
                    return CacheItemExpirationOptions.Absolute;
                }
                else if (this.SlidingExpiration.TotalMilliseconds > 1)
                {
                    return CacheItemExpirationOptions.Sliding;
                }
                else
                {
                    this.SlidingExpiration = new TimeSpan(0, 30, 0, 0, 0);
                    return CacheItemExpirationOptions.Sliding;
                }
            }
        }
        #endregion

        #region AbsoluteExpiration
        /// <summary>
        /// <para>
        /// 缓存绝对失效时间。
        /// </para>
        /// <para>
        /// 如果设置<see cref="AbsoluteExpiration"/>，则<see cref="SlidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。
        /// </para>
        /// </summary>
        /// <value>设置或获取缓存项绝对失效时间。</value>
        /// <remarks>
        /// 如果设置<see cref="AbsoluteExpiration"/>，则<see cref="SlidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。
        /// </remarks>
        public virtual DateTime AbsoluteExpiration
        {
            get { return _absoluteExpiration; }
            set { _absoluteExpiration = value; }
        }
        #endregion

        #region SlidingExpiration
        /// <summary>
        /// <para>滑动的缓存项失效时间设定。</para>
        /// <para>如果设置<see cref="SlidingExpiration"/>，则<see cref="AbsoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </summary>
        /// <value>设置或获取滑动的缓存项失效时间设定。</value>
        /// <remarks>
        /// 如果设置<see cref="SlidingExpiration"/>，则<see cref="AbsoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。
        /// </remarks>
        public virtual TimeSpan SlidingExpiration
        {
            get { return _slidingExpiration; }
            set { _slidingExpiration = value; }
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
        {
            this.AbsoluteExpiration = CacheItemPolicy.NoneAbsoluteExpiration;
            this.SlidingExpiration = new TimeSpan(0, 30, 0);
            this.Priority = CacheItemPriority.Default;
        }

        #endregion

        #region Priority
        /// <summary>
        /// 缓存项优先级。
        /// </summary>
        /// <value>设置或获取缓存项优先级。</value>
        public virtual CacheItemPriority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        #endregion

        #region Dependency
        /// <summary>
        /// 缓存项依赖环境。
        /// </summary>
        /// <value>设置或获取缓存项依赖环境。</value>
        public virtual CacheItemDependency Dependency
        {
            get { return _dependency; }
            set { _dependency = value; }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */