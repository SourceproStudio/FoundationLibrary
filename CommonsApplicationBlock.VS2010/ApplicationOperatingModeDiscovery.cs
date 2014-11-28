#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-27 17:33:16
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
using System.Web;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons
{
    /// <summary>
    /// <para>
    /// 提供了自动判别应用运行模式的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ApplicationOperatingModeDiscovery"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="ApplicationOperatingModeDiscovery"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="ApplicationOperatingModeDiscovery"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// <seealso cref="ApplicationOperatingMode"/>
    public static class ApplicationOperatingModeDiscovery
    {
        static private bool _alreadyDiscover = false;

        #region AlreadyDiscover
        /// <summary>
        /// 是否已经自动判别过一次。
        /// </summary>
        /// <value>设置或获取是否已经自动判别过一次。</value>
        static private bool AlreadyDiscover
        {
            get { return _alreadyDiscover; }
            set { _alreadyDiscover = value; }
        }
        #endregion

        #region AutoDiscover
        /// <summary>
        /// 自动判别应用运行模式。
        /// </summary>
        /// <returns><see cref="ApplicationOperatingMode"/>中的一个值。</returns>
        static public ApplicationOperatingMode AutoDiscover()
        {
            if (!ApplicationOperatingModeDiscovery.AlreadyDiscover && ApplicationOperatingModeRegistration.InternalAccessVariable == ApplicationOperatingMode.Unknown)
            {
                if (ApplicationOperatingModeDiscovery.IsWindowsApplication())
                    ApplicationOperatingModeRegistration.Register(ApplicationOperatingMode.WindowsApplication);
                else
                    ApplicationOperatingModeRegistration.Register(ApplicationOperatingMode.WebApplication);
                ApplicationOperatingModeDiscovery.AlreadyDiscover = true;
            }
            return ApplicationOperatingModeRegistration.InternalAccessVariable;
        }
        #endregion

        #region IsWindowsApplication
        /// <summary>
        /// 验证当前应用是否为Windows可执行性应用。
        /// </summary>
        /// <returns>如果是Windows可执行性应用返回true；否则返回false。</returns>
        static private bool IsWindowsApplication()
        {
            return (string.IsNullOrWhiteSpace(HttpRuntime.AppDomainAppId) && string.IsNullOrWhiteSpace(HttpRuntime.AppDomainId)) || AppDomain.CurrentDomain.FriendlyName.ToLower().EndsWith(".exe");
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */