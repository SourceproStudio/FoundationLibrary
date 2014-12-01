#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 13:32:51
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
    /// 提供了访问单一资源项的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="Resource{T}"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="Resource{T}"/> is an abstract type !
    /// </para>
    /// </summary>
    /// <typeparam name="T">资源类型。</typeparam>
    /// <remarks>
    /// <see cref="Resource{T}"/> is an abstract type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    [Serializable]
    public abstract class Resource<T>
    {
        private string _name;
        private T _data;

        #region Name
        /// <summary>
        /// 资源标识名称。
        /// </summary>
        /// <value>设置或获取资源的标识名称。</value>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Data
        /// <summary>
        /// <typeparamref name="T"/>类型的资源。
        /// </summary>
        /// <value>设置或获取<typeparamref name="T"/>类型资源。</value>
        public virtual T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion

        #region Resource Constructors

        /// <summary>
        /// 用于初始化一个<see cref="Resource{T}" />对象实例。
        /// </summary>
        /// <param name="name">资源的标识名称。</param>
        /// <param name="data"><typeparamref name="T"/>类型的资源。</param>
        protected Resource(string name, T data)
        {
            this.Name = name;
            this.Data = data;
        }

        /// <summary>
        /// 用于初始化一个<see cref="Resource{T}" />对象实例。
        /// </summary>
        protected Resource()
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */