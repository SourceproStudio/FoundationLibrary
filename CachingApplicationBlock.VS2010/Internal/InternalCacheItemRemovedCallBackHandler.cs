#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 10:32:29
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
using System.Runtime.Caching;
using System.Dynamic;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal
{
    /// <summary>
    /// <para>
    /// 提供了缓存组件内部使用的移除后回调方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InternalCacheItemRemovedCallBackHandler"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    internal class InternalCacheItemRemovedCallBackHandler
    {
        private CacheItemWasRemovedCallback _handler;

        #region Handler
        /// <summary>
        /// 缓存项移除后执行的回调方法。
        /// </summary>
        /// <value>设置或获取缓存项移除后执行的回调方法。</value>
        internal CacheItemWasRemovedCallback Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }
        #endregion

        #region InternalCacheItemRemovedCallBackHandler Constructors

        /// <summary>
        /// 用于初始化一个<see cref="InternalCacheItemRemovedCallBackHandler" />对象实例。
        /// </summary>
        /// <param name="callback">回调方法。</param>
        internal InternalCacheItemRemovedCallBackHandler(CacheItemWasRemovedCallback callback)
        {
            this.Handler = callback;
        }

        #endregion

        #region Do
        /// <summary>
        /// 指定内部回调方法。
        /// </summary>
        /// <param name="args">回调方法参数。</param>
        internal void Do(CacheEntryRemovedArguments args)
        {
            if (!object.ReferenceEquals(this.Handler, null))
            {
                dynamic state = new ExpandoObject();
                state.Key = args.CacheItem.Key;
                state.CacheItem = new CacheItem(args.CacheItem.Key, args.CacheItem.Value);
                state.RemovedReason = args.RemovedReason;
                this.Handler.Invoke(new CacheItem(args.CacheItem.Key, args.CacheItem.Value), state);
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */