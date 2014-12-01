#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 10:32:20
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO
{
    /// <summary>
    /// <para>
    /// 定义了验证安装路径不存在的原因枚举类型。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InstallationPathNotExistsReasons"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    [Serializable]
    public enum InstallationPathNotExistsReasons : int
    {
        /// <summary>
        /// 安装路径不存在。
        /// </summary>
        NotExists = 1,
        /// <summary>
        /// 由于访问环境变量引发的安全异常。
        /// </summary>
        SecurityException = 2,
        /// <summary>
        /// 由于访问环境变量印发的其他异常。
        /// </summary>
        OtherException = 3,
        /// <summary>
        /// 环境变量不存在。
        /// </summary>
        EnvironmentVariableNotFound = 4,
        /// <summary>
        /// 无。
        /// </summary>
        None = 5
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */