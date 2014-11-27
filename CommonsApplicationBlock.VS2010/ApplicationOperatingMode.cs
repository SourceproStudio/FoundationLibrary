#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-27 16:51:44
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
    /// 定义了应用工作运行模式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ApplicationOperatingMode"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    [Serializable, Flags]
    public enum ApplicationOperatingMode
    {
        /// <summary>
        /// 代表一个WEB应用程序。
        /// </summary>
        WebApplication = 1,
        /// <summary>
        /// 代表一个Windows可执行程序。
        /// </summary>
        WindowsApplication = 2,
        /// <summary>
        /// 未知模式的应用程序。
        /// </summary>
        Unknown = 4
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */