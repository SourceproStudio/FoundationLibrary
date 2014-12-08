#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-08 11:33:35
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 定义了合并配置项时的优先级。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationMergePriority"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    [Serializable]
    public enum ConfigurationMergePriority : int
    {
        /// <summary>
        /// 用户自定义配置文件优先合并。
        /// </summary>
        UserPrior = 1,
        /// <summary>
        /// 应用配置文件（app.config或web.config）优先合并。
        /// </summary>
        ApplicationPrior
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */