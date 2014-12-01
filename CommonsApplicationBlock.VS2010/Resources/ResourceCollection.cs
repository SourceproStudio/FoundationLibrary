#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 13:38:42
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources
{
    /// <summary>
    /// <para>
    /// 单一资源集合。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ResourceCollection<T>"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <typeparam name="T">资源类型。</typeparam>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    [Serializable]
    public class ResourceCollection<T> : Dictionary<string, Resource<T>>
    {
        #region ResourceCollection Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ResourceCollection<T>" />对象实例。
        /// </summary>
        public ResourceCollection()
        { }

        /// <summary>
        /// 用于初始化一个<see cref="ResourceCollection<T>" />对象实例。
        /// </summary>
        /// <param name="initialization">用于初始化集合的数据。</param>
        public ResourceCollection(IEnumerable<Resource<T>> initialization)
        {
            foreach (Resource<T> item in initialization)
            {
                this.Add(item.Name, item);
            }
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */