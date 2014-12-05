#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 10:20:21
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
    /// 供缓存组件内部使用的缓存项更新后回调方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InternalCacheItemUpdatedCallBackHandler"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    internal class InternalCacheItemUpdatedCallBackHandler
    {
        private CacheItemWasUpdatedCallback _handler;

        #region Handler
        /// <summary>
        /// 更新缓存项回调方法。
        /// </summary>
        /// <value>设置或获取更新缓存项回调方法。</value>
        internal CacheItemWasUpdatedCallback Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }
        #endregion

        #region InternalCacheItemUpdatedCallBackHandler Constructors

        /// <summary>
        /// 用于初始化一个<see cref="InternalCacheItemUpdatedCallBackHandler" />对象实例。
        /// </summary>
        /// <param name="callback">回调方法。</param>
        internal InternalCacheItemUpdatedCallBackHandler(CacheItemWasUpdatedCallback callback)
        {
            this.Handler = callback;
        }

        #endregion

        #region Do
        /// <summary>
        /// 执行回调。
        /// </summary>
        /// <param name="args">回调参数。</param>
        internal void Do(CacheEntryUpdateArguments args)
        {
            if (!object.ReferenceEquals(this.Handler, null))
            {
                dynamic state = new ExpandoObject();
                state.Key = args.Key;
                state.RemovedReason = args.RemovedReason;
                state.CacheItem = new CacheItem(args.Key, args.UpdatedCacheItem.Value);
                this.Handler.Invoke(args.Key, state);
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */