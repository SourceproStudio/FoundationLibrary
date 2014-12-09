#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 9:49:38
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

using System.Configuration;
using System.IO;
using Config = System.Configuration.Configuration;
using Manager = System.Configuration.ConfigurationManager;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了配置组件内部使用的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InternalConfigurationManager"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="InternalConfigurationManager"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="InternalConfigurationManager"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// <seealso cref="Config"/>
    /// <seealso cref="Manager"/>
    internal static class InternalConfigurationManager
    {
        #region OpenExeConfiguration
        /// <summary>
        /// 打开当前可执行文件的配置。
        /// </summary>
        /// <returns><see cref="Config"/>对象实例。</returns>
        static internal Config OpenExeConfiguration()
        {
            return Manager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        #endregion

        #region OpenMappedExeConfiguration
        /// <summary>
        /// 打开映射到当前可执行文件的应用配置。
        /// </summary>
        /// <param name="mappedConfigFile">映射的配置文件完整名称。</param>
        /// <returns><see cref="Config"/>对象实例。</returns>
        /// <exception cref="FileNotFoundException">
        /// 当映射配置文件<paramref name="mappedConfigFile"/>未找到时抛出此异常。
        /// </exception>
        static internal Config OpenMappedExeConfiguration(string mappedConfigFile)
        {
            if (!File.Exists(mappedConfigFile)) throw new FileNotFoundException("Configuration file not found!", mappedConfigFile);
            ExeConfigurationFileMap map = new ExeConfigurationFileMap() { ExeConfigFilename = mappedConfigFile };
            return Manager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */