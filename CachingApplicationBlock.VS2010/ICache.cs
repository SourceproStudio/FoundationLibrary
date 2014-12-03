#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 14:08:59
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
    /// 定义了数据缓存的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ICache"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// <seealso cref="CacheItem"/>
    /// <seealso cref="KeyValuePair{TKey,TValue}"/>
    /// <seealso cref="CacheItemPolicy"/>
    /// <seealso cref="CacheItemDependency"/>
    /// <seealso cref="CacheItemWasRemovedCallback"/>
    /// <seealso cref="CacheItemWasUpdatedCallback"/>
    public interface ICache
    {
        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="cache"><see cref="CacheItem"/>缓存项对象实例。</param>
        void Add(CacheItem cache);

        #region KeyValuePair Caching Handlers
 
        /// <summary>
        /// 添加键值对缓存项<paramref name="cache"/>。
        /// </summary>
        /// <param name="cache">键值对类型缓存项。</param>
        /// <param name="policy">缓存策略。</param>
        void Add(KeyValuePair<string, object> cache, CacheItemPolicy policy);

        /// <summary>
        /// 添加键值对缓存项<paramref name="cache"/>。
        /// </summary>
        /// <param name="cache">键值对类型缓存项。</param>
        void Add(KeyValuePair<string, object> cache);

        /// <summary>
        /// 添加键值对缓存项<paramref name="cache"/>。
        /// </summary>
        /// <param name="cache">键值对类型缓存项。</param>
        /// <param name="dependency">缓存项依赖环境。</param>
        void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency);

        /// <summary>
        /// 添加键值对缓存项<paramref name="cache"/>。
        /// </summary>
        /// <param name="cache">键值对类型缓存项。</param>
        /// <param name="dependency">缓存项依赖环境。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration);

        /// <summary>
        /// 添加键值对缓存项<paramref name="cache"/>。
        /// </summary>
        /// <param name="cache">键值对类型缓存项。</param>
        /// <param name="dependency">缓存项依赖环境。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        /// <param name="afterRemoved">缓存数据被移除后执行的回调方法。</param>
        /// <param name="afterUpdated">缓存数据被更新后执行的回调方法。</param>
        void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated);

       #endregion

        #region String + Object Caching Handlers

        /// <summary>
        /// 将<paramref name="data"/>以指定名称(<paramref name="key"/>)写入缓存项。
        /// </summary>
        /// <param name="key">缓存项的标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="policy">缓存项应用的策略。</param>
        void Add(string key, object data, CacheItemPolicy policy);

        /// <summary>
        /// 将<paramref name="data"/>以指定名称(<paramref name="key"/>)写入缓存项。
        /// </summary>
        /// <param name="key">缓存项的标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        void Add(string key, object data);

        /// <summary>
        /// 将<paramref name="data"/>以指定名称(<paramref name="key"/>)写入缓存项。
        /// </summary>
        /// <param name="key">缓存项的标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存项依赖的环境。</param>
        void Add(string key, object data, CacheItemDependency dependency);

        /// <summary>
        /// 将<paramref name="data"/>以指定名称(<paramref name="key"/>)写入缓存项。
        /// </summary>
        /// <param name="key">缓存项的标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存项依赖的环境。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        void Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration);

        /// <summary>
        /// 将<paramref name="data"/>以指定名称(<paramref name="key"/>)写入缓存项。
        /// </summary>
        /// <param name="key">缓存项的标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存项依赖的环境。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        /// <param name="afterRemoved">缓存项被移除后执行的回调方法。</param>
        /// <param name="afterUpdated">缓存项被更新后执行的回调方法。</param>
        void Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated);

        #endregion
        #endregion

        #region TryGet
        /// <summary>
        /// 尝试获取指定标识名称<paramref name="key"/>的缓存数据。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">
        /// <para>缓存项数据。</para>
        /// <para>输出参数。</para>
        /// </param>
        /// <returns>如果指定标识名称<paramref name="key"/>的缓存项存在则返回true；否则返回false。</returns>
        bool TryGet(string key, out object data);
        #endregion

        #region IsExists
        /// <summary>
        /// 验证指定标识名称的缓存项是否存在。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <returns>缓存项是否存在。</returns>
        bool IsExists(string key);
        #endregion

        #region this
        /// <summary>
        /// 设置或获取指定标识名称的缓存项。
        /// </summary>
        /// <param name="key">标识名称。</param>
        /// <returns>缓存数据。</returns>
        object this[string key] { get; set; }
        #endregion

        #region Get
        /// <summary>
        /// 获取指定标识名称的缓存项。
        /// </summary>
        /// <param name="key">标识名称。</param>
        /// <returns>缓存数据。</returns>
        object Get(string key);
        #endregion

        #region Update
        /// <summary>
        /// 更新指定标识名称的缓存数据。
        /// </summary>
        /// <param name="key">标识名称。</param>
        /// <param name="data">需要更新的缓存数据。</param>
        void Update(string key, object data);
        #endregion

        #region Nullable
        /// <summary>
        /// 是否接受null值缓存项。
        /// </summary>
        /// <value>获取是否接受null值缓存项。</value>
        bool Nullable { get; }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */