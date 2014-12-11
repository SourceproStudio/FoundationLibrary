#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 10:46:22
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
using System.Data.Common;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 数据库连接对象异常参数。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseConnectionErrorEventArgs"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="EventArgs"/>
    /// <seealso cref="DbConnection"/>
    /// <seealso cref="Exception"/>
    [Serializable]
    public class DatabaseConnectionErrorEventArgs : EventArgs
    {
        private string _methodName;
        private DbConnection _instance;
        private Exception _error;

        #region MethodName
        /// <summary>
        /// 发生数据库连接异常的方法名称。
        /// </summary>
        /// <value>获取发生数据库连接异常的方法名称。</value>
        public virtual string MethodName
        {
            get { return _methodName; }
            protected set { _methodName = value; }
        }
        #endregion

        #region Instance
        /// <summary>
        /// 引发此异常的<see cref="DbConnection"/>对象实例。
        /// </summary>
        /// <value>获取引发此异常的<see cref="DbConnection"/>对象实例。</value>
        public virtual DbConnection Instance
        {
            get { return _instance; }
            protected set { _instance = value; }
        }
        #endregion

        #region Error
        /// <summary>
        /// <see cref="Exception"/>对象实例。
        /// </summary>
        /// <value>获取<see cref="Exception"/>对象实例。</value>
        public virtual Exception Error
        {
            get { return _error; }
            protected set { _error = value; }
        }
        #endregion

        #region DatabaseConnectionErrorEventArgs Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseConnectionErrorEventArgs" />对象实例。
        /// </summary>
        /// <param name="methodName">引发数据库连接异常的方法名称。</param>
        /// <param name="connection">引发数据库连接异常的<see cref="DbConnection"/>对象实例。</param>
        /// <param name="error"><see cref="Exception"/>对象实例。</param>
        public DatabaseConnectionErrorEventArgs(string methodName, DbConnection connection, Exception error)
        {
            this.MethodName = methodName;
            this.Instance = connection;
            this.Error = error;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */