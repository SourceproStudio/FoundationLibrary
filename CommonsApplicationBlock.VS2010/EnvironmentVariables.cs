#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 9:48:15
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
using System.Security;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons
{
    /// <summary>
    /// <para>
    /// 提供了访问基础库环境变量的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="EnvironmentVariables"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="EnvironmentVariables"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="EnvironmentVariables"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// <seealso cref="Environment"/>
    public static class EnvironmentVariables
    {
        #region InstallationPathEnvironmentVariableName
        /// <summary>
        /// 安装路径环境变量名称。
        /// </summary>
        public const string InstallationPathEnvironmentVariableName = "FLIB_PATH";
        #endregion
        static private string _installationPath = string.Empty;
        static private bool _allreadyVerified = false;

        #region AllreadyVerified
        /// <summary>
        /// 是否已经验证过环境变量是否存在。
        /// </summary>
        /// <value>设置或获取是否已经验证过环境变量是否存在。</value>
        static private bool AllreadyVerified
        {
            get { return _allreadyVerified; }
            set { _allreadyVerified = value; }
        }
        #endregion

        #region InstallationPath
        /// <summary>
        /// 安装路径环境变量（%FLIB_PATH%）值。
        /// </summary>
        /// <value>获取安装路径环境变量（%FLIB_PATH%）值。</value>
        static public string InstallationPath
        {
            get { return _installationPath; }
            private set { _installationPath = value; }
        }
        #endregion

        #region VerifyInstallationPathEnvironmentVarExists
        /// <summary>
        /// 验证安装路径环境变量是否存在。
        /// </summary>
        /// <returns>如果存在则返回true；否则返回false。</returns>
        /// <exception cref="SecurityException">
        /// 当当前线程用户无访问系统环境变量权限时，抛出此异常。
        /// </exception>
        static public bool VerifyInstallationPathEnvironmentVarExists()
        {
            try
            {
                if (!EnvironmentVariables.AllreadyVerified)
                {
                    EnvironmentVariables.InstallationPath = 
                        Environment.GetEnvironmentVariable(EnvironmentVariables.InstallationPathEnvironmentVariableName, EnvironmentVariableTarget.Machine);
                    EnvironmentVariables.AllreadyVerified = true;
                }
                return !string.IsNullOrWhiteSpace(EnvironmentVariables.InstallationPath);
            }
            catch (SecurityException securityEx)
            {
                throw securityEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ResetAllreadyVerifiedStatus
        /// <summary>
        /// 重置<see cref="AllreadyVerified"/>属性。
        /// </summary>
        static public void ResetAllreadyVerifiedStatus()
        {
            EnvironmentVariables.AllreadyVerified = false;
        }
        #endregion

        #region SetInstallationPathEnvironmentVariable
        /// <summary>
        /// 将路径<paramref name="installedPath"/>设置为环境变量。
        /// </summary>
        /// <param name="installedPath">指定的安装路径。</param>
        /// <exception cref="SecurityException">
        /// 当当前线程用户无访问系统环境变量权限时，抛出此异常。
        /// </exception>
        static public void SetInstallationPathEnvironmentVariable(string installedPath)
        {
            try
            {
                Environment.SetEnvironmentVariable(EnvironmentVariables.InstallationPathEnvironmentVariableName, installedPath, EnvironmentVariableTarget.Machine);
                EnvironmentVariables.InstallationPath = installedPath;
                EnvironmentVariables.AllreadyVerified = true;
            }
            catch (SecurityException securityEx)
            {
                throw securityEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */