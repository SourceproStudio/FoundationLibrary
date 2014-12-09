#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 15:19:51
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

using System.IO;
using System.Web.Configuration;
using System.Web.Hosting;
using Config = System.Configuration.Configuration;
using Manager = System.Web.Configuration.WebConfigurationManager;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration
{
    /// <summary>
    /// <para>
    /// 提供给内部使用的访问ASP.NET配置的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InternalWebConfigurationManager"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="InternalWebConfigurationManager"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="InternalWebConfigurationManager"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// <seealso cref="Config"/>
    /// <seealso cref="Manager"/>
    internal static class InternalWebConfigurationManager
    {
        #region OpenWebConfiguration
        /// <summary>
        /// 打开当前应用的web.config文件，并获取相关配置。
        /// </summary>
        /// <returns><see cref="Config"/>对象实例。</returns>
        static internal Config OpenWebConfiguration()
        {
            return Manager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath, HostingEnvironment.SiteName);
        }
        #endregion

        #region OpenMappedWebConfiguration
        /// <summary>
        /// 打开映射的配置文件，并获取相关配置。
        /// </summary>
        /// <param name="fileName">映射的配置文件名称。</param>
        /// <param name="virtualPath">自定义配置文件的虚拟目录。</param>
        /// <returns><see cref="Config"/>对象实例。</returns>
        /// <exception cref="FileNotFoundException">
        /// 当配置文件<paramref name="fileName"/>未找到时抛出此异常。
        /// </exception>
        static internal Config OpenMappedWebConfiguration(string fileName, string virtualPath = "/PrivateConfigs")
        {
            FileInfo file = new FileInfo(fileName);
            if (!file.Exists) throw new FileNotFoundException("Configuration file not found!", fileName);
            string virtualDirectory = string.Format("{0}{1}{2}", HostingEnvironment.ApplicationVirtualPath, HostingEnvironment.ApplicationVirtualPath.EndsWith("/") ? string.Empty : "/", virtualPath.TrimStart('/'));
            WebConfigurationFileMap map = new WebConfigurationFileMap();
            map.VirtualDirectories.Add(
                virtualDirectory,
                new VirtualDirectoryMapping(file.Directory.FullName, false, file.Name));
            return Manager.OpenMappedWebConfiguration(map, virtualDirectory, HostingEnvironment.SiteName);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */