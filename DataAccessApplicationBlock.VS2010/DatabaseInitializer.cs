#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 13:37:46
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 提供了用于初始化数据库对象实例的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseInitializer"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DatabaseSectionGroup"/>
    [Serializable]
    public class DatabaseInitializer
    {
        private string _name;
        private string _connectionString;
        private int _commandTimeoutSeconds;
        private string _defaultSchemaName;
        private string _provider;
        private string _providerType;

        #region Name
        /// <summary>
        /// 数据库标识名称。
        /// </summary>
        /// <value>设置或获取数据库的标识名称。</value>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region ConnectionString
        /// <summary>
        /// 数据库连接串。
        /// </summary>
        /// <value>设置或获取数据库连接串。</value>
        public virtual string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        #endregion

        #region CommandTimeoutSeconds
        /// <summary>
        /// 数据库命令执行超时(秒)。
        /// </summary>
        /// <value>设置或获取数据库命令执行超时(秒)。</value>
        public virtual int CommandTimeoutSeconds
        {
            get { return _commandTimeoutSeconds; }
            set { _commandTimeoutSeconds = value; }
        }
        #endregion

        #region DefaultSchemaName
        /// <summary>
        /// 默认的数据库架构名称。
        /// </summary>
        /// <value>设置或获取默认的数据库架构名称。</value>
        public virtual string DefaultSchemaName
        {
            get { return _defaultSchemaName; }
            set { _defaultSchemaName = value; }
        }
        #endregion

        #region Provider
        /// <summary>
        /// 数据库访问提供者名称。
        /// </summary>
        /// <value>设置或获取数据库访问提供者名称。</value>
        public virtual string Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        #endregion

        #region ProviderType
        /// <summary>
        /// 数据库访问提供者类型名称。
        /// </summary>
        /// <value>设置或获取数据库访问提供者类型名称。</value>
        public virtual string ProviderType
        {
            get { return _providerType; }
            set { _providerType = value; }
        }
        #endregion

        #region DatabaseInitializer Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseInitializer" />对象实例。
        /// </summary>
        protected DatabaseInitializer()
        { }

        #endregion

        #region CreateInitializer
        /// <summary>
        /// 创建一个初始化器。
        /// </summary>
        /// <param name="config"><see cref="DatabaseSectionGroup"/>对象实例。</param>
        /// <param name="dbName">数据库标识名称。</param>
        /// <returns><see cref="DatabaseInitializer"/>对象实例。</returns>
        /// <exception cref="ArgumentNullException">
        /// 当<paramref name="config"/>为null值时抛出此异常。
        /// </exception>
        static internal DatabaseInitializer CreateInitializer(DatabaseSectionGroup config, string dbName)
        {
            if (object.ReferenceEquals(config, null)) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(dbName)) dbName = DatabaseInitializer.GetDefaultDatabase(config.DbDefaultOptions);
            DatabaseConnectionElement connection = DatabaseInitializer.GetConnectionConfig(dbName, config.DbConnection);
            string providerName = DatabaseInitializer.GetConnectionPropertyValue("provider", config, connection);
            string timeout = DatabaseInitializer.GetConnectionPropertyValue("commandTimeoutSeconds", config, connection);
            return new DatabaseInitializer()
            {
                Name = dbName,
                DefaultSchemaName = DatabaseInitializer.GetConnectionPropertyValue("defaultSechema", config, connection),
                CommandTimeoutSeconds = string.IsNullOrWhiteSpace(timeout) ? 0 : int.Parse(timeout),
                ConnectionString = DatabaseInitializer.GetConnectionPropertyValue("connectionString", config, connection),
                Provider = providerName,
                ProviderType = DatabaseInitializer.GetDatabaseProviderType(providerName, config)
            };
        }
        #endregion

        #region GetDefaultDatabase
        /// <summary>
        /// 获取默认的数据库名称。
        /// </summary>
        /// <param name="defaultOptions">默认配置选项。</param>
        /// <returns>默认的数据库名称。</returns>
        /// <exception cref="ArgumentNullException">
        /// 当<paramref name="defaultOptions"/>为null值或默认数据库连接名称配置为<see cref="string"/>.Empty时抛出此异常。
        /// </exception>
        static private string GetDefaultDatabase(DefaultDatabaseOptionsSection defaultOptions)
        {
            if (object.ReferenceEquals(defaultOptions, null) || string.IsNullOrWhiteSpace(defaultOptions.DefaultDatabaseConnection)) throw new ArgumentNullException();
            return defaultOptions.DefaultDatabaseConnection;
        }
        #endregion

        #region GetConnectionConfig
        /// <summary>
        /// 获取指定名称的数据库连接配置。
        /// </summary>
        /// <param name="dbName">数据库连接标识名称。</param>
        /// <param name="config">数据库连接配置。</param>
        /// <returns><see cref="DatabaseConnectionElement"/>对象实例。</returns>
        /// <exception cref="ArgumentNullException">
        /// 当<paramref name="config"/>为null时抛出此异常。
        /// </exception>
        static private DatabaseConnectionElement GetConnectionConfig(string dbName, DatabaseConnectionSection config)
        {
            if (object.ReferenceEquals(config, null) || object.ReferenceEquals(config.Connections, null)) throw new ArgumentNullException();
            return config.Connections[dbName];
        }
        #endregion

        #region GetConnectionPropertyValue
        /// <summary>
        /// 获取指定连接属性值。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        /// <param name="config">数据库组件配置。</param>
        /// <param name="connectionConfig">数据库连接配置。</param>
        /// <returns>属性值。</returns>
        /// <exception cref="ArgumentNullException">
        /// 当<paramref name="connectionConfig"/>为null值时抛出此异常。
        /// </exception>
        static private string GetConnectionPropertyValue(string propertyName, DatabaseSectionGroup config, DatabaseConnectionElement connectionConfig)
        {
            if (object.ReferenceEquals(connectionConfig, null)) throw new ArgumentNullException();
            string propertyValue = string.Empty;
            if (!object.ReferenceEquals(connectionConfig.Protections, null)
                && !object.ReferenceEquals(connectionConfig.Protections[propertyName], null)
                && !string.IsNullOrWhiteSpace(connectionConfig.Protections[propertyName].ProtectedValue))
            {
                string protectionName = string.Empty;
                if (string.IsNullOrWhiteSpace(connectionConfig.Protections[propertyName].ProtectionName))
                {
                    if (object.ReferenceEquals(config.DbDefaultOptions, null) || string.IsNullOrWhiteSpace(config.DbDefaultOptions.DefaultDatabaseProtection))
                        throw new NullReferenceException("Not found database default protection config!");
                    protectionName = config.DbDefaultOptions.DefaultDatabaseProtection;
                }
                else protectionName = connectionConfig.Protections[protectionName].ProtectionName;
                if (string.IsNullOrWhiteSpace(protectionName) || object.ReferenceEquals(config.DbProtection, null) || object.ReferenceEquals(config.DbProtection.Protections, null) || object.ReferenceEquals(config.DbProtection.Protections[protectionName], null))
                    throw new NullReferenceException(string.Format("Not found database protection config! (Name: {0})", protectionName));
                propertyValue = (Activator.CreateInstance(Type.GetType(config.DbProtection.Protections[protectionName].Type)) as IDatabasePropertyProtection).UnProtect(connectionConfig.Protections[propertyName].ProtectedValue);
            }
            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                switch (propertyValue)
                {
                    case "commandTimeoutSeconds": propertyValue = connectionConfig.CommandTimeoutSeconds.ToString(); break;
                    case "connectionString": propertyValue = connectionConfig.ConnectionString; break;
                    case "defaultSechema": propertyValue = connectionConfig.DefaultSechema; break;
                    case "provider": propertyValue = connectionConfig.Provider; break;
                }
            }
            return propertyValue;
        }
        #endregion

        #region GetDatabaseProviderType
        /// <summary>
        /// 获取数据库访问提供者类型名称。
        /// </summary>
        /// <param name="providerName">标识名称。</param>
        /// <param name="config"><see cref="DatabaseSectionGroup"/>对象实例。</param>
        /// <returns>类型名称字符串。</returns>
        static private string GetDatabaseProviderType(string providerName, DatabaseSectionGroup config)
        {
            if (string.IsNullOrWhiteSpace(providerName))
            {
                if (object.ReferenceEquals(config.DbDefaultOptions, null) || string.IsNullOrWhiteSpace(config.DbDefaultOptions.DefaultDatabaseProvider)) throw new NullReferenceException("Not found default database provider!");
                providerName = config.DbDefaultOptions.DefaultDatabaseProvider;
            }
            if (object.ReferenceEquals(config.DbProvider, null) || object.ReferenceEquals(config.DbProvider.Providers, null) || object.ReferenceEquals(config.DbProvider.Providers[providerName], null))
                throw new NullReferenceException(string.Format("Not found database provider config! (Name: {0})", providerName));
            return config.DbProvider.Providers[providerName].Type;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */