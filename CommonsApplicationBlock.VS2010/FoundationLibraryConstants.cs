#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 10:01:09
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
    /// 基础开发库常量值。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="FoundationLibraryConstants"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="FoundationLibraryConstants"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="FoundationLibraryConstants"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    public static class FoundationLibraryConstants
    {
        #region InstallationPathEnvironmentVariableName
        /// <summary>
        /// 开发库安装路径环境变量名称。
        /// </summary>
        public const string InstallationPathEnvironmentVariableName = "SOURCEPRO_LIB_PATH";
        #endregion

        #region DefaultConfigurationFileName
        /// <summary>
        /// 基础库默认配置文件名称。
        /// </summary>
        public const string DefaultConfigurationFileName = "SourceProStudio.FoundationLibrary.config";
        #endregion

        #region DefaultCultureInfoLCID
        /// <summary>
        /// 默认的文化区域标识。
        /// </summary>
        public const int DefaultCultureInfoLCID = 2052;
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */