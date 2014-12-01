#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 14:02:23
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
    /// 当未能找到资源文件时，抛出此异常。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ResourceFileNotFoundException"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="ResourceFileNotFoundException"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// <remarks>
    /// Can not inherit from <see cref="ResourceFileNotFoundException"/> !
    /// </remarks>
    [Serializable]
    public sealed class ResourceFileNotFoundException : Exception
    {
        private string _fileName;

        #region FileName
        /// <summary>
        /// 未找到的资源文件完整名称。
        /// </summary>
        /// <value>获取未能找到的资源文件完整名称。</value>
        public string FileName
        {
            get { return _fileName; }
            private set { _fileName = value; }
        }
        #endregion

        #region ResourceFileNotFoundException Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ResourceFileNotFoundException" />对象实例。
        /// </para>
        /// </summary>
        public ResourceFileNotFoundException()
            : base()
        { }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ResourceFileNotFoundException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="message">异常信息。</param>
        /// <param name="innerException">引发了此异常的<see cref="Exception"/>对象实例。</param>
        public ResourceFileNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ResourceFileNotFoundException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="message">异常信息。</param>
        public ResourceFileNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ResourceFileNotFoundException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="fileName">未找到的资源文件完整名称。</param>
        /// <param name="message">异常信息。</param>
        /// <param name="innerException">引发了此异常的<see cref="Exception"/>对象实例。</param>
        public ResourceFileNotFoundException(string fileName, string message, Exception innerException)
            : this(message, innerException)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ResourceFileNotFoundException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="fileName">未找到的资源文件完整名称。</param>
        /// <param name="message">异常信息。</param>
        public ResourceFileNotFoundException(string fileName, string message)
            : this(message)
        {
            this.FileName = fileName;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */