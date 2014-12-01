#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 11:30:21
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources
{
    /// <summary>
    /// <para>
    /// 提供了访问单一资源的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ResourceItem{TName, TValue}"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="ResourceItem{TName, TValue}"/> is an abstract type !
    /// </para>
    /// </summary>
    /// <typeparam name="TName">资源名称类型。</typeparam>
    /// <typeparam name="TValue">资源类型。</typeparam>
    /// <remarks>
    /// <see cref="ResourceItem{TName, TValue}"/> is an abstract type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    [Serializable]
    public abstract class ResourceItem<TName, TValue>
    {
        private TName _name;
        private TValue _value;

        #region Name
        /// <summary>
        /// 资源名称。
        /// </summary>
        /// <value>设置或获取资源名称。</value>
        public virtual TName Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Value
        /// <summary>
        /// 资源。
        /// </summary>
        /// <value>设置或获取资源。</value>
        public virtual TValue Value
        {
            get { return _value; }
            set { _value = value; }
        }
        #endregion

        #region ResourceItem Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ResourceItem{TName, TValue}" />对象实例。
        /// </summary>
        /// <param name="name"><typeparamref name="TName"/>类型的资源名称。</param>
        /// <param name="value"><typeparamref name="TValue"/>类型的资源。</param>
        protected ResourceItem(TName name, TValue value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 用于初始化一个<see cref="ResourceItem{TName, TValue}" />对象实例。
        /// </summary>
        /// <param name="name"><typeparamref name="TName"/>类型的资源名称。</param>
        protected ResourceItem(TName name)
            : this(name, default(TValue))
        {
        }

        /// <summary>
        /// 用于初始化一个<see cref="ResourceItem{TName, TValue}" />对象实例。
        /// </summary>
        protected ResourceItem()
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */