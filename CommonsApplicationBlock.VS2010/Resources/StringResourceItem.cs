#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 11:38:20
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
    /// 提供了访问单一字符串资源的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="StringResourceItem"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    [Serializable]
    public class StringResourceItem : ResourceItem<string, string>
    {
        #region StringResourceItem Constructors

        /// <summary>
        /// 用于初始化一个<see cref="StringResourceItem" />对象实例。
        /// </summary>
        /// <param name="name">字符串资源名称。</param>
        /// <param name="value">字符串资源。</param>
        public StringResourceItem(string name, string value)
            : base(name, value)
        { }

        /// <summary>
        /// 用于初始化一个<see cref="StringResourceItem" />对象实例。
        /// </summary>
        /// <param name="name">字符串资源名称。</param>
        public StringResourceItem(string name)
            : base(name)
        {
        }

        /// <summary>
        /// 用于初始化一个<see cref="StringResourceItem" />对象实例。
        /// </summary>
        public StringResourceItem()
            : base()
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */