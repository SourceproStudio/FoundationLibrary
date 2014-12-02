#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-02 11:21:53
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
using System.EnterpriseServices.Internal;
using System.IO;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Deployment
{
    /// <summary>
    /// <para>
    /// 提供了将程序集安装到GAC的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Deployment"/>
    /// </para>
    /// <para>
    /// Type : <see cref="GacInstallation"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="GacInstallation"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="GacInstallation"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Deployment"/>
    /// <seealso cref="System.EnterpriseServices.Internal"/>
    /// <seealso cref="Publish"/>
    public static class GacInstallation
    {
        #region Install
        /// <summary>
        /// 将程序集文件<paramref name="fileName"/>安装到程序集。
        /// </summary>
        /// <param name="fileName">程序集文件完整名称。</param>
        static public void Install(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException();
            try
            {
                Publish publish = new Publish();
                publish.GacInstall(fileName);
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