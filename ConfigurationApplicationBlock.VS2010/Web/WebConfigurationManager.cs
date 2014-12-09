#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-09 16:35:10
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
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration;
using System.Configuration;
using Config = System.Configuration.Configuration;
using System.Collections.Generic;
using Location = SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.ConfigurationLocation;
using Manager = SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.ConfigurationManager;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration
{
    /// <summary>
    /// <para>
    /// 提供了访问ASP.NET配置的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="WebConfigurationManager"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Web.Configuration"/>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.ConfigurationManager"/>
    /// <seealso cref="ConfigurationSourceElement"/>
    public class WebConfigurationManager : Manager
    {
        #region WebConfigurationManager Constructors

        /// <summary>
        /// 用于初始化一个<see cref="WebConfigurationManager" />对象实例。
        /// </summary>
        public WebConfigurationManager()
            : this(WebConfigurationContext.Default)
        { }

        /// <summary>
        /// 用于初始化一个<see cref="WebConfigurationManager" />对象实例。
        /// </summary>
        /// <param name="ctx">ASP.NET配置上下文。</param>
        public WebConfigurationManager(WebConfigurationContext ctx)
            : base(ctx)
        {
        }

        #endregion

        #region Initialize
        /// <summary>
        /// 初始化此<see cref="WebConfigurationManager"/>对象。
        /// </summary>
        protected override void Initialize()
        {
            this.Storage = new WebConfigurationStorage();
            this.AppSettings = new Dictionary<string, string>();
            AppSettingsSection settings = this.Context.ConfigurationObject.AppSettings;
            foreach (KeyValueConfigurationElement item in settings.Settings)
            {
                this.AppSettings.Add(item.Key, item.Value);
            }
            this.ConnectionStrings = this.Context.ConfigurationObject.ConnectionStrings;
        }
        #endregion

        #region GetSourceConfiguration
        /// <summary>
        /// 获取指定源文件的配置。
        /// </summary>
        /// <param name="source">自定义配置源。</param>
        /// <returns><see cref="Config"/>对象实例。</returns>
        protected override Config GetSourceConfiguration(ConfigurationSourceElement source)
        {
            Location location = new Location(source);
            if (location.IsExists)
            {
                string virtualDirectory = "/PrivateConfigs";
                if (!object.ReferenceEquals(source.AspNetCompatibilitySupportProperties, null) && !string.IsNullOrWhiteSpace(source.AspNetCompatibilitySupportProperties.VirtualDirectory))
                    virtualDirectory = source.AspNetCompatibilitySupportProperties.VirtualDirectory;
                return InternalWebConfigurationManager.OpenMappedWebConfiguration(location.Path, virtualDirectory);
            }
            else
                return null;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */