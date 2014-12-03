#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 10:16:34
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 提供了访问缓存项的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItem"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// <seealso cref="CacheItemPolicy"/>
    [Serializable]
    public class CacheItem
    {
        private string _key;
        private object _data;
        private CacheItemPolicy _policy;

        #region Key
        /// <summary>
        /// 缓存项标识名称。
        /// </summary>
        /// <value>设置或获取缓存项标识名称。</value>
        /// <exception cref="NullReferenceException">
        /// 当设置的值为null或者<see cref="string"/>.Empty时抛出此异常。
        /// </exception>
        public virtual string Key
        {
            get { return _key; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new NullReferenceException();
                _key = value;
            }
        }
        #endregion

        #region Data
        /// <summary>
        /// 需要缓存的实际数据。
        /// </summary>
        /// <value>设置或获取需要缓存的数据。</value>
        public virtual object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion

        #region Policy
        /// <summary>
        /// 缓存项使用的策略。
        /// </summary>
        /// <value>设置或获取缓存策略。</value>
        public virtual CacheItemPolicy Policy
        {
            get { return _policy; }
            set { _policy = value; }
        }
        #endregion

        #region CacheItem Constructors

        /// <summary>
        /// 用于初始化一个<see cref="CacheItem" />对象实例。
        /// </summary>
        public CacheItem()
        { }

        /// <summary>
        /// 用于初始化一个<see cref="CacheItem" />对象实例。
        /// </summary>
        /// <param name="key">缓存项标识名称。</param>
        /// <param name="data">需要缓存的数据。</param>
        public CacheItem(string key, object data)
            : this()
        {
            this.Key = key;
            this.Data = data;
        }

        #endregion

        #region IsNothing
        /// <summary>
        /// 验证Data是否为null值。
        /// </summary>
        /// <returns>如果Data为null值，则返回true；否则返回false。</returns>
        public virtual bool IsNothing()
        {
            return object.ReferenceEquals(this.Data, null);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */