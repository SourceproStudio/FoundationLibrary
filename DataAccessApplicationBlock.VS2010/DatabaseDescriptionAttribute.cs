#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-10 10:45:44
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
    /// 用于标记数据库描述信息。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseDescriptionAttribute"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="DatabaseDescriptionAttribute"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="Attribute"/>
    /// <remarks>
    /// Can not inherit from <see cref="DatabaseDescriptionAttribute"/> !
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DatabaseDescriptionAttribute : Attribute
    {
        private string _databaseName;

        #region DatabaseName
        /// <summary>
        /// 数据库名称。
        /// </summary>
        /// <value>获取数据库标识名称。</value>
        public string DatabaseName
        {
            get { return _databaseName; }
            private set { _databaseName = value; }
        }
        #endregion

        #region DatabaseDescriptionAttribute Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="DatabaseDescriptionAttribute" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="dbName">数据库标识名称。</param>
        public DatabaseDescriptionAttribute(string dbName)
        {
            this.DatabaseName = dbName;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */