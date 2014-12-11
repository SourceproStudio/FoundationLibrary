#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 10:41:50
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

using System.Data.Common;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 定义了与数据库连接相关的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabaseConnection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DbConnection"/>
    public interface IDatabaseConnection
    {
        #region Connection
        /// <summary>
        /// 数据库连接对象实例。
        /// </summary>
        /// <value><see cref="DbConnection"/>对象实例。</value>
        DbConnection Connection { get; }
        #endregion

        #region ConnectionString
        /// <summary>
        /// 数据库连接串。
        /// </summary>
        /// <value>获取数据库连接串。</value>
        string ConnectionString { get; }
        #endregion

        #region Open
        /// <summary>
        /// 打开数据库连接。
        /// </summary>
        void Open();
        #endregion

        #region Close
        /// <summary>
        /// 关闭数据库连接。
        /// </summary>
        void Close();
        #endregion

        #region Event ConnectionError
        /// <summary>
        /// 数据库连接异常事件。
        /// </summary>
        event DatabaseConnectionErrorEventHandler ConnectionError;
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */