#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-08 14:49:44
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

using System.Text.RegularExpressions;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations
{
    /// <summary>
    /// <para>
    /// 提供了验证配置文件路径的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ConfigurationLocationValidation"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations"/>
    public class ConfigurationLocationValidation
    {
        private const string RegularExpression1 = @"^(?<StartWith>\%[\u0020-\u007E]+\%)(?<Suffix>[\u0020-\uFFFF]?)[\u0020-\uFFFF]*";
        private const string RegularExpression2 = @"^(?<StartWith>~)(?<Suffix>[\u0020-\uFFFF]?)[\u0020-\uFFFF]*";
        private RegexMatching _matching1;
        private RegexMatching _matching2;
        private bool _waveStart = false;
        private char _followWave;
        private bool _environmentVarStart = false;
        private char _followEnvironmentVar;
        private const string Group1 = "StartWith";
        private const string Group2 = "Suffix";
        private string _environmentVariableName;

        #region Matching1
        /// <summary>
        /// 用于验证是否以环境变量名称格式起始。
        /// </summary>
        /// <value>设置或获取用于验证是否以环境变量名称格式起始的正则表达式。</value>
        protected virtual RegexMatching Matching1
        {
            get { return _matching1; }
            set { _matching1 = value; }
        }
        #endregion

        #region Matching2
        /// <summary>
        /// 用于验证是否以波浪号起始。
        /// </summary>
        /// <value>设置或获取用于验证是否以波浪号起始的正则表达式。</value>
        protected virtual RegexMatching Matching2
        {
            get { return _matching2; }
            set { _matching2 = value; }
        }
        #endregion

        #region WaveStart
        /// <summary>
        /// 是否以波浪号开始。
        /// </summary>
        /// <value>获取是否以波浪号开始。</value>
        public virtual bool WaveStart
        {
            get { return _waveStart; }
            protected set { _waveStart = value; }
        }
        #endregion

        #region FollowWave
        /// <summary>
        /// 跟随波浪号的字符。
        /// </summary>
        /// <value>获取跟随波浪号的字符。</value>
        public virtual char FollowWave
        {
            get { return _followWave; }
            protected set { _followWave = value; }
        }
        #endregion

        #region EnvironmentVarStart
        /// <summary>
        /// 是否以环境变量名称开始。
        /// </summary>
        /// <value>获取是否以环境变量名称开始。</value>
        public virtual bool EnvironmentVarStart
        {
            get { return _environmentVarStart; }
            protected set { _environmentVarStart = value; }
        }
        #endregion

        #region FollowEnvironmentVar
        /// <summary>
        /// 跟随环境变量名称后的字符。
        /// </summary>
        /// <value>获取跟随环境变量名称后的字符。</value>
        public virtual char FollowEnvironmentVar
        {
            get { return _followEnvironmentVar; }
            protected set { _followEnvironmentVar = value; }
        }
        #endregion

        #region EnvironmentVariableName
        /// <summary>
        /// 环境变量模式名称。
        /// </summary>
        /// <value>获取环境变量模式中的名称。</value>
        public virtual string EnvironmentVariableName
        {
            get { return _environmentVariableName; }
            protected set { _environmentVariableName = value; }
        }
        #endregion

        #region ConfigurationLocationValidation Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ConfigurationLocationValidation" />对象实例。
        /// </summary>
        /// <param name="path">配置文件路径字符串。</param>
        public ConfigurationLocationValidation(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                Match match = null;
                this.Matching1 = new RegexMatching(RegularExpression1);
                this.Matching2 = new RegexMatching(RegularExpression2);
                if (this.Matching1.IsMatch(path))
                {
                    match = this.Matching1.Match(path, RegexOptions.None);
                    this.EnvironmentVarStart = match.Success && !object.ReferenceEquals(match.Groups[Group1], null) && match.Groups[Group1].Success;
                    this.FollowEnvironmentVar = match.Success && !object.ReferenceEquals(match.Groups[Group2], null) && match.Groups[Group2].Success && !string.IsNullOrWhiteSpace(match.Groups[Group2].Value)
                        ? match.Groups[Group2].Value.ToCharArray()[0] : '0';
                    this.EnvironmentVariableName = match.Groups[Group1].Value.Replace("%", string.Empty);
                }
                else if (this.Matching2.IsMatch(path))
                {
                    match = this.Matching2.Match(path, RegexOptions.None);
                    this.WaveStart = match.Success && !object.ReferenceEquals(match.Groups[Group1], null) && match.Groups[Group1].Success;
                    this.FollowWave = match.Success && !object.ReferenceEquals(match.Groups[Group2], null) && match.Groups[Group2].Success && !string.IsNullOrWhiteSpace(match.Groups[Group2].Value)
                        ? match.Groups[Group2].Value.ToCharArray()[0] : '0';
                }
            }
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */