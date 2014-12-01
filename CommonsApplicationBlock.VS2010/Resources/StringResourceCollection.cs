#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 13:50:33
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
    /// 字符串资源项集合。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="StringResourceCollection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="StringResourceCollection"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// <remarks>
    /// Can not inherit from <see cref="StringResourceCollection"/> !
    /// </remarks>
    [Serializable]
    public sealed class StringResourceCollection : ResourceCollection<string>
    {
        #region StringResourceCollection Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="StringResourceCollection" />对象实例。
        /// </para>
        /// </summary>
        public StringResourceCollection()
            : base()
        { }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="StringResourceCollection" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="initialization">用于初始化的资源项。</param>
        public StringResourceCollection(IEnumerable<StringResource> initialization)
            : base(initialization)
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */