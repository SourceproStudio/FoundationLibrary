#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 15:12:00
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
using System.Web;
using System.Web.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons;
using SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching.Internal;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching
{
    /// <summary>
    /// <para>
    /// 提供了适用于ASP.NET的缓存方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="AspCache"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Web.Caching"/>
    /// <seealso cref="AspCacheItem"/>
    /// <seealso cref="CacheDependency"/>
    /// <seealso cref="CacheItemPolicy"/>
    /// <seealso cref="AspCacheItemDependency"/>
    public class AspCache : ICache
    {
        #region AspCache Constructors

        /// <summary>
        /// 用于初始化一个<see cref="AspCache" />对象实例。
        /// </summary>
        public AspCache()
        { }

        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="cache"><see cref="AspCacheItem"/>缓存项。</param>
        public virtual void Add(AspCacheItem cache)
        {
            if (this.IsExists(cache.Key)) this.Remove(cache.Key);
            if (this.Nullable || !object.ReferenceEquals(cache.Data, null))
                HttpRuntime.Cache.Insert(cache.Key, cache.Data,
                    object.ReferenceEquals(cache.Policy.Dependency, null) ? null : cache.Policy.Dependency.GetDependency(),
                    cache.Policy.ExpirationOption == CacheItemExpirationOptions.Sliding ? System.Web.Caching.Cache.NoAbsoluteExpiration : cache.Policy.AbsoluteExpiration,
                    cache.Policy.ExpirationOption == CacheItemExpirationOptions.Sliding ? cache.Policy.SlidingExpiration : System.Web.Caching.Cache.NoSlidingExpiration,
                    new CacheItemPriorityConverter(cache.Policy.Priority).Convert(),
                    new CacheItemRemovedCallback(new InternalCacheItemRemovedCallBackHandler(cache.Policy.RemovedCallBack).Do)
                    );
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="cache">缓存项。</param>
        /// <exception cref="ArgumentException">
        /// 如果<paramref name="cache"/>不是<see cref="AspCacheItem"/>对象实例时，抛出此异常。
        /// </exception>
        void ICache.Add(CacheItem cache)
        {
            if (cache.GetType().Equals(typeof(AspCacheItem)))
            {
                this.Add(cache as AspCacheItem);
            }
            else throw new ArgumentException();
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="policy">缓存策略。</param>
        public virtual void Add(KeyValuePair<string, object> cache, AspCacheItemPolicy policy)
        {
            this.Add(new AspCacheItem(cache.Key, cache.Value) { Policy = policy });
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="policy">缓存策略。</param>
        /// <exception cref="ArgumentException">
        /// 当<paramref name="policy"/>不是一个<see cref="AspCacheItemPolicy"/>对象实例时，抛出此异常。
        /// </exception>
        void ICache.Add(KeyValuePair<string, object> cache, CacheItemPolicy policy)
        {
            if (policy.GetType().Equals(typeof(AspCacheItemPolicy)))
            {
                this.Add(cache, policy as AspCacheItemPolicy);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        public virtual void Add(KeyValuePair<string, object> cache)
        {
            this.Add(cache, new AspCacheItemPolicy()
            {
                AbsoluteExpiration = CacheItemPolicy.NoneAbsoluteExpiration,
                SlidingExpiration = new TimeSpan(0, 30, 0, 0, 0),
                Dependency = null,
                Priority = SourcePro.Csharp.Practices.FoundationLibrary.Caching.CacheItemPriority.Default,
                RemovedCallBack = null
            });
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="dependency">缓存依赖项。</param>
        public virtual void Add(KeyValuePair<string, object> cache, AspCacheItemDependency dependency)
        {
            this.Add(cache, new AspCacheItemPolicy()
            {
                AbsoluteExpiration = CacheItemPolicy.NoneAbsoluteExpiration,
                SlidingExpiration = new TimeSpan(0, 30, 0, 0, 0),
                Dependency = dependency,
                Priority = FoundationLibrary.Caching.CacheItemPriority.Default,
                RemovedCallBack = null,
                UpdatedCallBack = null
            });
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加键值对类型的缓存项。
        /// </summary>
        /// <param name="cache">键值对。</param>
        /// <param name="dependency">缓存依赖项。</param>
        void ICache.Add(KeyValuePair<string, object> cache, CacheItemDependency dependency)
        {
            if (dependency.GetType().Equals(typeof(AspCacheItemDependency)))
            {
                this.Add(cache, dependency as AspCacheItemDependency);
            }
            else
            {
                throw new ArgumentException();
            }
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
        public virtual void Add(KeyValuePair<string, object> cache, AspCacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            this.Add(cache, new AspCacheItemPolicy()
            {
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
                Dependency = dependency,
                Priority = FoundationLibrary.Caching.CacheItemPriority.Default,
                RemovedCallBack = null,
                UpdatedCallBack = null
            });
        }
        #endregion

        #region ICache.Add
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
        void ICache.Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            if (dependency.GetType().Equals(typeof(AspCacheItemDependency)))
            {
                this.Add(cache, dependency as AspCacheItemDependency, absoluteExpiration, slidingExpiration);
            }
            else
            {
                throw new ArgumentException();
            }
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
        /// <param name="afterRemoved">缓存项移除后执行的回调方法。</param>
        public virtual void Add(KeyValuePair<string, object> cache, AspCacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved)
        {
            this.Add(cache, new AspCacheItemPolicy()
            {
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
                Dependency = dependency,
                RemovedCallBack = afterRemoved,
                UpdatedCallBack = null,
                Priority = FoundationLibrary.Caching.CacheItemPriority.Default
            });
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 此方法已过时，会抛出<see cref="NotImplementedException"/>异常。
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="dependency"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="afterRemoved"></param>
        /// <param name="afterUpdated"></param>
        [ImportantNotice("此方法已过时！"), Obsolete("此方法已过时，请不要调用！", true)]
        void ICache.Add(KeyValuePair<string, object> cache, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="policy">缓存策略。</param>
        public virtual void Add(string key, object data, AspCacheItemPolicy policy)
        {
            this.Add(new KeyValuePair<string, object>(key, data), policy);
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="policy">缓存策略。</param>
        void ICache.Add(string key, object data, CacheItemPolicy policy)
        {
            (this as ICache).Add(new KeyValuePair<string, object>(key, data), policy);
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
        /// <param name="dependency">缓存依赖项。</param>
        public virtual void Add(string key, object data, AspCacheItemDependency dependency)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency);
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖项。</param>
        void ICache.Add(string key, object data, CacheItemDependency dependency)
        {
            (this as ICache).Add(new KeyValuePair<string, object>(key, data), dependency);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖项。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        public virtual void Add(string key, object data, AspCacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency, absoluteExpiration, slidingExpiration);
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖项。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        void ICache.Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            (this as ICache).Add(key, data, dependency, absoluteExpiration, slidingExpiration);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        /// <param name="dependency">缓存依赖项。</param>
        /// <param name="absoluteExpiration">
        /// <para>缓存项绝对失效时间。</para>
        /// <para>如果设置此值，则<paramref name="slidingExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneSlidingExpiration。</para>
        /// </param>
        /// <param name="slidingExpiration">
        /// <para>缓存项滑动失效时间。每次访问缓存项，则失效时间增加指定数量。</para>
        /// <para>如果设置此值，则<paramref name="absoluteExpiration"/>必须设置为<see cref="CacheItemPolicy"/>.NoneAbsoluteExpiration。</para>
        /// </param>
        /// <param name="afterRemoved">缓存项移除后执行的回调方法。</param>
        public virtual void Add(string key, object data, AspCacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved)
        {
            this.Add(new KeyValuePair<string, object>(key, data), dependency, absoluteExpiration, slidingExpiration, afterRemoved);
        }
        #endregion

        #region ICache.Add
        /// <summary>
        /// 此方法已过时，会抛出<see cref="NotImplementedException"/>异常。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="dependency"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="afterRemoved"></param>
        /// <param name="afterUpdated"></param>
        [ImportantNotice("此方法已过时！"), Obsolete("此方法已过时，请不要调用！", true)]
        void ICache.Add(string key, object data, CacheItemDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemWasRemovedCallback afterRemoved, CacheItemWasUpdatedCallback afterUpdated)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TryGet
        /// <summary>
        /// 尝试获取指定名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">如果指定标识名称的缓存项存在，则返回缓存数据。</param>
        /// <returns>指定标识名称的缓存项是否存在。</returns>
        public virtual bool TryGet(string key, out object data)
        {
            data = null;
            bool exists = this.IsExists(key);
            if (exists) data = this[key];
            return exists;
        }
        #endregion

        #region IsExists
        /// <summary>
        /// 验证指定标识名称的缓存项是否存在。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <returns>指定标识名称的缓存项是否存在。</returns>
        public virtual bool IsExists(string key)
        {
            return !object.ReferenceEquals(this[key], null);
        }
        #endregion

        #region this
        /// <summary>
        /// 设置或获取指定标识名称的缓存项。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <returns>缓存数据。</returns>
        public virtual object this[string key]
        {
            get
            {
                return HttpRuntime.Cache[key];
            }
            set
            {
                if (this.IsExists(key))
                {
                    this.Update(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取指定标识名称的缓存项。
        /// </summary>
        /// <param name="key">标识名称。</param>
        /// <returns>缓存数据。</returns>
        public virtual object Get(string key)
        {
            return this[key];
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新缓存数据。
        /// </summary>
        /// <param name="key">指定的缓存项标识名称。</param>
        /// <param name="data">需要更新的缓存数据。</param>
        public virtual void Update(string key, object data)
        {
            if (this.Nullable || !object.ReferenceEquals(data, null))
                HttpRuntime.Cache[key] = data;
        }
        #endregion

        #region Nullable
        /// <summary>
        /// 是否允许null值写入缓存。
        /// </summary>
        /// <value>获取是否允许null值写入缓存。</value>
        public virtual bool Nullable
        {
            get { return false; }
        }
        #endregion

        #region Remove
        /// <summary>
        /// 删除指定标识名称的缓存项。
        /// </summary>
        /// <param name="key">标识名称。</param>
        public virtual void Remove(string key)
        {
            if (this.IsExists(key))
                HttpRuntime.Cache.Remove(key);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */