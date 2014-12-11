#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 10:11:24
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

using System.Configuration;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration
{
    /// <summary>
    /// <para>
    /// 数据库组件配置组。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseSectionGroup"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration"/>
    /// <seealso cref="ConfigurationSectionGroup"/>
    public class DatabaseSectionGroup : ConfigurationSectionGroup
    {
        #region SectionGroupName
        /// <summary>
        /// 配置节组名称。
        /// </summary>
        public const string GroupName = "sourcepro.data";
        #endregion

        #region DbDefaultOptions
        /// <summary>
        /// 数据库组件默认选项。
        /// </summary>
        /// <value>获取数据库组件默认选项。</value>
        public virtual DefaultDatabaseOptionsSection DbDefaultOptions
        {
            get { return base.Sections[DefaultDatabaseOptionsSection.SectionName] as DefaultDatabaseOptionsSection; }
        }
        #endregion

        #region DbConnection
        /// <summary>
        /// 数据库连接配置。
        /// </summary>
        /// <value>获取数据库连接配置。</value>
        public virtual DatabaseConnectionSection DbConnection
        {
            get { return this.Sections[DatabaseConnectionSection.SectionName] as DatabaseConnectionSection; }
        }
        #endregion

        #region DbProtection
        /// <summary>
        /// 数据库属性保护配置。
        /// </summary>
        /// <value>获取数据库属性保护配置。</value>
        public virtual DatabasePropertyProtectionSection DbProtection
        {
            get { return this.Sections[DatabasePropertyProtectionSection.SectionName] as DatabasePropertyProtectionSection; }
        }
        #endregion

        #region DbProvider
        /// <summary>
        /// 数据库访问器配置。
        /// </summary>
        /// <value>获取数据库访问器配置。</value>
        public virtual DatabaseAccessProviderSection DbProvider
        {
            get { return this.Sections[DatabaseAccessProviderSection.SectionName] as DatabaseAccessProviderSection; }
        }
        #endregion

        #region DatabaseSectionGroup Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseSectionGroup" />对象实例。
        /// </summary>
        public DatabaseSectionGroup()
            : base()
        { }

        #endregion

        #region Add
        /// <summary>
        /// 添加<paramref name="section"/>。
        /// </summary>
        /// <param name="name">自定义配置节。</param>
        /// <param name="section"><see cref="ConfigurationSection"/>对象实例。</param>
        public virtual void Add(string name,ConfigurationSection section)
        {
            object config = this.Sections[name];
            if (!object.ReferenceEquals(config, null)) this.Sections.Remove(name);
            this.Sections.Add(name, section);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */