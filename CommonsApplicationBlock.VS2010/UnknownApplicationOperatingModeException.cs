#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 9:46:33
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons
{
    /// <summary>
    /// <para>
    /// 当：当前应用运行模式等于<see cref="ApplicationOperatingMode"/>.Unknown时，抛出此异常。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="UnknownApplicationOperatingModeException"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="UnknownApplicationOperatingModeException"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// <remarks>
    /// Can not inherit from <see cref="UnknownApplicationOperatingModeException"/> !
    /// </remarks>
    [Serializable]
    public sealed class UnknownApplicationOperatingModeException : Exception
    {
        #region UnknownApplicationOperatingModeException Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="UnknownApplicationOperatingModeException" />对象实例。
        /// </para>
        /// </summary>
        public UnknownApplicationOperatingModeException()
            : base()
        { }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="UnknownApplicationOperatingModeException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="message">异常信息。</param>
        public UnknownApplicationOperatingModeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="UnknownApplicationOperatingModeException" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="message">异常信息。</param>
        /// <param name="innerException">引发了此次异常的<see cref="Exception"/>对象实例。</param>
        public UnknownApplicationOperatingModeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */