#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 9:36:14
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
using System.Runtime.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal;
using Item = System.Runtime.Caching.CacheItem;
using Policy = System.Runtime.Caching.CacheItemPolicy;
using Priority = System.Runtime.Caching.CacheItemPriority;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 提供了数据缓存处理的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="Cache"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// <seealso cref="System.Runtime.Caching"/>
    /// <seealso cref="ObjectCache"/>
    /// <seealso cref="MemoryCache"/>
    /// <seealso cref="Policy"/>
    /// <seealso cref="Item"/>
    /// <seealso cref="Priority"/>
    /// <seealso cref="CacheItem"/>
    /// <seealso cref="CacheItemPolicy"/>
    /// <seealso cref="CacheItemDependency"/>
    public class Cache : ICache
    {
        private ObjectCache _cacheProvider;

        #region CacheProvider
        /// <summary>
        /// 数据缓存底层服务。
        /// </summary>
        /// <value>设置或获取数据缓存底层服务对象实例。</value>
        protected virtual ObjectCache CacheProvider
        {
            get { return _cacheProvider; }
            set { _cacheProvider = value; }
        }
        #endregion

        #region Cache Constructors

        /// <summary>
        /// 用于初始化一个<see cref="Cache" />对象实例。
        /// </summary>
        public Cache()
        {
            this.CacheProvider = MemoryCache.Default;
        }

        #endregion

        #region CreateCacheItemInstance
        /// <summary>
        /// 创建<see cref="Item"/>缓存项对象实例。
        /// </summary>
        /// <param name="cache"><see cref="CacheItem"/>对象实例。</param>
        /// <returns><see cref="Item"/>对象实例。</returns>
        protected virtual Item CreateCacheItemInstance(CacheItem cache)
        {
            return new Item(cache.Key, cache.Data);
        }

        /// <summary>
        /// 创建<see cref="Item"/>缓存项对象实例。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <returns><see cref="Item"/>对象实例。</returns>
        protected virtual Item CreateCacheItemInstance(string key, object data)
        {
            return new Item(key, data);
        }
        #endregion

        #region CreateCachePolicyInstance
        /// <summary>
        /// 创建<see cref="Policy"/>缓存策略对象实例。
        /// </summary>
        /// <param name="policy"><see cref="CacheItemPolicy"/>对象实例。</param>
        /// <returns><see cref="Policy"/>缓存策略对象实例。</returns>
        protected virtual Policy CreateCachePolicyInstance(CacheItemPolicy policy)
        {
            if (object.ReferenceEquals(policy, null)) return new Policy();
            else
            {
                Policy cachePolicy = new Policy()
                {
                    AbsoluteExpiration = policy.ExpirationOption == CacheItemExpirationOptions.Sliding ? ObjectCache.InfiniteAbsoluteExpiration : policy.AbsoluteExpiration,
                    SlidingExpiration = policy.ExpirationOption == CacheItemExpirationOptions.Sliding ? policy.SlidingExpiration : ObjectCache.NoSlidingExpiration,
                    Priority = new CacheItemPriorityConverter(policy.Priority).Convert(),
                    UpdateCallback = object.ReferenceEquals(policy.UpdatedCallBack, null) ? null : new CacheEntryUpdateCallback(new InternalCacheItemUpdatedCallBackHandler(policy.UpdatedCallBack).Do),
                    RemovedCallback = object.ReferenceEquals(policy.UpdatedCallBack, null) ? new CacheEntryRemovedCallback(new InternalCacheItemRemovedCallBackHandler(policy.RemovedCallBack).Do) : null
                };
                this.SetChangeMonitor(cachePolicy, policy.Dependency);
                return cachePolicy;
            }
        }
        #endregion

        #region SetChangeMonitor
        /// <summary>
        /// 设置缓存策略的ChangeMonitors属性。
        /// </summary>
        /// <param name="policy"><see cref="Policy"/>缓存策略。</param>
        /// <param name="dependency">缓存依赖。</param>
        protected virtual void SetChangeMonitor(Policy policy, CacheItemDependency dependency)
        {
            if (!object.ReferenceEquals(dependency, null) && !object.ReferenceEquals(dependency.DependencyFiles, null) && dependency.DependencyFiles.Count > 0)
            {
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(dependency.DependencyFiles));
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="cache"><see cref="CacheItem"/>缓存项对象实例。</param>
        /// <remarks>
        /// 如果指定名称的缓存项存在，则先移除旧有的缓存项，则添加<paramref name="cache"/>。
        /// </remarks>
        public virtual void Add(CacheItem cache)
        {
            if (this.IsExists(cache.Key)) this.Remove(cache.Key);
            if (this.Nullable || (!this.Nullable && !object.ReferenceEquals(cache.Data, null)))
            {
                this.CacheProvider.Add(this.CreateCacheItemInstance(cache), this.CreateCachePolicyInstance(cache.Policy));
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="policy">缓存策略。</param>
        public virtual void Add(KeyValuePair<string, object> cache, CacheItemPolicy policy)
        {
            this.Add(new CacheItem(cache.Key, cache.Value) { Policy = policy });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        public virtual void Add(KeyValuePair<string, object> cache)
        {
            this.Add(cache, new CacheItemPolicy()
            {
                AbsoluteExpiration = CacheItemPolicy.NoneAbsoluteExpiration,
                SlidingExpiration = new TimeSpan(0, 30, 0, 0, 0),
                Priority = CacheItemPriority.Default,
                RemovedCallBack = null,
                UpdatedCallBack = null
            });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="dependency">缓存依赖。</param>
        public virtual void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency)
        {
            this.Add(cache, new CacheItemPolicy()
            {
                AbsoluteExpiration = CacheItemPolicy.NoneAbsoluteExpiration,
                SlidingExpiration = new TimeSpan(0, 30, 0, 0, 0),
                Dependency = dependency,
                Priority = CacheItemPriority.Default,
                RemovedCallBack = null,
                UpdatedCallBack = null
            });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="dependency">缓存依赖。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        public virtual void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            this.Add(cache, new CacheItemPolicy()
            {
                Dependency = dependency,
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
                UpdatedCallBack = null,
                RemovedCallBack = null,
                Priority = CacheItemPriority.Default
            });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="dependency">缓存依赖。</param>
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
        public virtual void Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated)
        {
            this.Add(cache, new CacheItemPolicy()
            {
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
                RemovedCallBack = afterRemoved,
                UpdatedCallBack = afterUpdated,
                Dependency = dependency,
                Priority = CacheItemPriority.Default
            });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="policy">缓存项策略。</param>
        public virtual void Add(string key, object data, CacheItemPolicy policy)
        {
            this.Add(new KeyValuePair<string, object>(key, data), policy);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        public virtual void Add(string key, object data)
        {
            this.Add(new KeyValuePair<string, object>(key, data));
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖对象。</param>
        public virtual void Add(string key, object data, CacheItemDependency dependency)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖对象。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        public virtual void Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency, absoluteExpiration, slidingExpiration);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖对象。</param>
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
        public virtual void Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency, absoluteExpiration, slidingExpiration, afterRemoved, afterUpdated);
        }
        #endregion

        #region TryGet
        /// <summary>
        /// 尝试获取执行名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">缓存数据。</param>
        /// <returns>缓存项是否存在。</returns>
        public virtual bool TryGet(string key, out object data)
        {
            data = null;
            bool exists = this.IsExists(key);
            if (exists) data = this.CacheProvider[key];
            return exists;
        }
        #endregion

        #region IsExists
        /// <summary>
        /// 验证指定名称的缓存项是否存在。
        /// </summary>
        /// <param name="key">缓存项。</param>
        /// <returns>指定名称的数据缓存项是否存在。</returns>
        public virtual bool IsExists(string key)
        {
            return this.CacheProvider.Contains(key);
        }
        #endregion

        #region this
        /// <summary>
        /// 设置或获取指定名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <returns>缓存的数据。</returns>
        public virtual object this[string key]
        {
            get
            {
                return this.IsExists(key) ? this.CacheProvider[key] : null;
            }
            set
            {
                if (this.IsExists(key)) this.Update(key, value);
                else this.Add(new KeyValuePair<string, object>(key, value));
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取指定名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <returns>缓存数据。</returns>
        public virtual object Get(string key)
        {
            return this[key];
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新执行名称的缓存项。
        /// </summary>
        /// <param name="key">标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        public virtual void Update(string key, object data)
        {
            if (this.IsExists(key))
            {
                if (this.Nullable || !object.ReferenceEquals(data, null))
                    this.CacheProvider[key] = data;
            }
        }
        #endregion

        #region Nullable
        /// <summary>
        /// 获取是否允许空值写入缓存。
        /// </summary>
        public virtual bool Nullable
        {
            get { return true; }
        }
        #endregion

        #region Remove
        /// <summary>
        /// 删除指定名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        public virtual void Remove(string key)
        {
            if (this.IsExists(key))
                this.CacheProvider.Remove(key);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */