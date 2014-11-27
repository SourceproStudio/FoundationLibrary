#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-27 17:22:52
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
    /// 提供了注册应用运行模式的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ApplicationOperatingModeRegistration"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="ApplicationOperatingModeRegistration"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="ApplicationOperatingModeRegistration"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// <seealso cref="ApplicationOperatingMode"/>
    public static class ApplicationOperatingModeRegistration
    {
        private static ApplicationOperatingMode _internalAccessVariable;

        #region InternalAccessVariable
        /// <summary>
        /// 供内部访问的<see cref="ApplicationOperatingMode"/>值。
        /// </summary>
        /// <value>获取<see cref="ApplicationOperatingMode"/>值。</value>
        internal static ApplicationOperatingMode InternalAccessVariable
        {
            get { return _internalAccessVariable; }
            private set { _internalAccessVariable = value; }
        }
        #endregion

        #region Register
        /// <summary>
        /// 为当前应用注册<see cref="ApplicationOperatingMode"/>值。
        /// </summary>
        /// <param name="mode">
        /// <para><see cref="ApplicationOperatingMode"/>中的一个值。</para>
        /// <para>默认值为<see cref="ApplicationOperatingMode"/>.Unknown</para>
        /// </param>
        static public void Register(ApplicationOperatingMode mode = ApplicationOperatingMode.Unknown)
        {
            ApplicationOperatingModeRegistration.InternalAccessVariable = mode;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */