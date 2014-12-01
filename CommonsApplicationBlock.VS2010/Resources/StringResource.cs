#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 13:44:55
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
    /// 提供了访问单一字符串资源项的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="StringResource"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// <seealso cref="Resource{T}"/>
    [Serializable]
    public class StringResource : Resource<string>
    {
        #region StringResource Constructors

        /// <summary>
        /// 用于初始化一个<see cref="StringResource" />对象实例。
        /// </summary>
        public StringResource()
        { }

        /// <summary>
        /// 用于初始化一个<see cref="StringResource" />对象实例。
        /// </summary>
        /// <param name="name">字符串资源标识名称。</param>
        /// <param name="resourceStr">资源字符串。</param>
        public StringResource(string name, string resourceStr)
            : base(name, resourceStr)
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */