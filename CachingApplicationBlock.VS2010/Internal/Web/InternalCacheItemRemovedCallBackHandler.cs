#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 13:30:51
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

using System.Dynamic;
using System.Web.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching.Internal
{
    /// <summary>
    /// <para>
    /// Description
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching.Internal"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InternalCacheItemRemovedCallBackHandler"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching.Internal"/>
    /// <seealso cref="CacheItemRemovedReason"/>
    /// <seealso cref="System.Web.Caching"/>
    /// <seealso cref="CacheItemWasRemovedCallback"/>
    internal class InternalCacheItemRemovedCallBackHandler
    {
        private CacheItemWasRemovedCallback _handler;

        #region Handler
        /// <summary>
        /// 缓存项被移除后执行的回调方法。
        /// </summary>
        /// <value>设置或获取缓存项被移除后执行的回调方法。</value>
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
        /// 内部回调方法。
        /// </summary>
        /// <param name="key">被移除的缓存项标识名称。</param>
        /// <param name="data">被移除的关联的缓存数据。</param>
        /// <param name="reason"><see cref="CacheItemRemovedReason"/>中的一个值。</param>
        internal void Do(string key, object data, CacheItemRemovedReason reason)
        {
            if (!object.ReferenceEquals(this.Handler, null))
            {
                dynamic state = new ExpandoObject();
                state.Key = key;
                state.Data = data;
                state.RemovedReason = reason;
                this.Handler.Invoke(new CacheItem(key, data), state);
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */