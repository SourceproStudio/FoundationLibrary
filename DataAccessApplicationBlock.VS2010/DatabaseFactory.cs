#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-12 10:54:58
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
using System.Collections.Generic;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 提供了创建数据库<see cref="Database"/>对象实例的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseFactory"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DatabaseContext"/>
    /// <seealso cref="Database"/>
    public class DatabaseFactory
    {
        private DatabaseContext _databaseContext;

        #region DatabaseContext
        /// <summary>
        /// 数据库上下文。
        /// </summary>
        /// <value>设置或获取数据库上下文。</value>
        protected virtual DatabaseContext DatabaseContext
        {
            get { return _databaseContext; }
            set { _databaseContext = value; }
        }
        #endregion

        #region DatabaseFactory Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseFactory" />对象实例。
        /// </summary>
        /// <param name="ctx">数据库上下文。</param>
        public DatabaseFactory(DatabaseContext ctx)
        {
            this.DatabaseContext = ctx;
        }

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseFactory" />对象实例。
        /// </summary>
        public DatabaseFactory()
            : this(DatabaseContext.Default)
        {
        }

        #endregion

        #region CreateDatabase
        /// <summary>
        /// 创建指定名称的数据库实例。
        /// </summary>
        /// <param name="name">数据库名称。</param>
        /// <returns><see cref="Database"/>对象实例。</returns>
        /// <remarks>
        /// 如果<paramref name="name"/>为<see cref="string"/>.Empty则返回默认选项中指定名称的数据库。
        /// </remarks>
        public virtual Database CreateDatabase(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (object.ReferenceEquals(this.DatabaseContext, null) || object.ReferenceEquals(this.DatabaseContext.ConfigurationObject, null) || object.ReferenceEquals(this.DatabaseContext.ConfigurationObject.DbDefaultOptions, null) || string.IsNullOrWhiteSpace(this.DatabaseContext.ConfigurationObject.DbDefaultOptions.DefaultDatabaseConnection))
                    throw new Exception("Invalid default database!");
                return this.CreateDatabase(this.DatabaseContext.ConfigurationObject.DbDefaultOptions.DefaultDatabaseConnection);
            }
            else
            {
                if (!this.DatabaseContext.Initializers.ContainsKey(name)) throw new KeyNotFoundException("Invalid database name!");
                DatabaseInitializer initializer = this.DatabaseContext.Initializers[name];
                return Activator.CreateInstance(Type.GetType(initializer.ProviderType), initializer) as Database;
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */