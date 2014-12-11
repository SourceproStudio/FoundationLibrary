#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 13:33:24
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 定义了数据库访问的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabaseProvider"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    public interface IDatabaseProvider : IDatabaseConnection, IDatabaseParameter, IDatabaseTransaction, IDatabaseCommand, IDisposable
    {
        #region CommandTimeoutSeconds
        /// <summary>
        /// 数据库命令执行超时(秒)。
        /// </summary>
        /// <value>设置或获取数据库命令执行超时(秒)。</value>
        int CommandTimeoutSeconds { get; set; }
        #endregion

        #region SchemaName
        /// <summary>
        /// 数据库架构名称。
        /// </summary>
        /// <value>设置或获取数据库架构名称。</value>
        string SchemaName { get; set; }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */