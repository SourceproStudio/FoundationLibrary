#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 11:39:52
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
using System.Text.RegularExpressions;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements
{
    /// <summary>
    /// <para>
    /// 用于匹配环境变量名称模式（即：%Environment Variable Name%）。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="EnvironmentVariableRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="EnvironmentVariableRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="EnvironmentVariableRegexMatching"/> !
    /// </remarks>
    public sealed class EnvironmentVariableRegexMatching : RegexMatching, IMatching
    {
        private string _environmentVariableName;

        #region EnvironmentVariableName
        /// <summary>
        /// 环境变量名称。
        /// </summary>
        /// <value>设置或获取环境变量名称。</value>
        public string EnvironmentVariableName
        {
            get { return _environmentVariableName; }
            set { _environmentVariableName = value; }
        }
        #endregion

        #region EnvironmentVariableRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="EnvironmentVariableRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="environmentVariable">环境变量名称。</param>
        public EnvironmentVariableRegexMatching(string environmentVariable)
            : base(string.Format("%(?<EnvironmentVariable>{0})%", Regex.Escape(environmentVariable)))
        {
            this.EnvironmentVariableName = environmentVariable;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */