#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-08 11:45:37
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Internal
{
    /// <summary>
    /// <para>
    /// 定义了合并配置的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Internal"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IConfigurationMerge"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Internal"/>
    /// <seealso cref="ConfigurationMergePriority"/>
    public interface IConfigurationMerge
    {
        #region Priority
        /// <summary>
        /// 合并优先级。
        /// </summary>
        /// <value>设置或获取合并优先级。</value>
        ConfigurationMergePriority Priority { get; set; }
        #endregion

        #region MergeSection
        /// <summary>
        /// 合并自定义配置节。
        /// </summary>
        /// <param name="userSection">配置用户自定义配置文件中的配置节。</param>
        /// <param name="appSection">配置在应用配置文件中的配置节。</param>
        /// <returns>合并后的自定义配置节。</returns>
        ConfigurationSection MergeSection(ConfigurationSection userSection, ConfigurationSection appSection);
        #endregion

        #region MergeSectionGroup
        /// <summary>
        /// 合并自定义配置节(组）。
        /// </summary>
        /// <param name="userSection">配置用户自定义配置文件中的配置节(组）。</param>
        /// <param name="appSection">配置在应用配置文件中的配置节(组）。</param>
        /// <returns>合并后的自定义配置节(组）。</returns>
        ConfigurationSectionGroup MergeSectionGroup(ConfigurationSectionGroup userSection, ConfigurationSectionGroup appSection);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */