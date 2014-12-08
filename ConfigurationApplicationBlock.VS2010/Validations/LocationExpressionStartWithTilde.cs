#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-08 14:19:53
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
    /// 提供了验证路径字符串是否以波浪号（~）开始。
    /// </para>
    /// <para>
    /// 如果以波浪号开始，则波浪号以当前运行目录替代。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations"/>
    /// </para>
    /// <para>
    /// Type : <see cref="LocationExpressionStartWithTilde"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration.Validations"/>
    public class LocationExpressionStartWithTilde
    {
        #region RegularExpression
        /// <summary>
        /// 正则表达式。
        /// </summary>
        private const string RegularExpression = @"^(?<StartWith>\u007E)(?<Surffix>[\u0020-\u007D\u00FF-\uFFFF]?)[\u0020-\u007D\u00FF-\uFFFF]*";
        #endregion
        private bool _isStartWithTilde;
        private bool _followThePath;

        #region IsStartWithTilde
        /// <summary>
        /// 是否以波浪号开始。
        /// </summary>
        /// <value>获取是否以波浪号开始。</value>
        public virtual bool IsStartWithTilde
        {
            get { return _isStartWithTilde; }
            protected set { _isStartWithTilde = value; }
        }
        #endregion

        #region FollowThePath
        /// <summary>
        /// 是否紧跟路径符（\）。
        /// </summary>
        /// <value>获取是否紧跟路径符（\）。</value>
        public virtual bool FollowThePath
        {
            get { return _followThePath; }
            set { _followThePath = value; }
        }
        #endregion

        #region LocationExpressionStartWithTilde Constructors

        /// <summary>
        /// 用于初始化一个<see cref="LocationExpressionStartWithTilde" />对象实例。
        /// </summary>
        /// <param name="path">路径。</param>
        public LocationExpressionStartWithTilde(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                this.IsStartWithTilde = false;
                this.FollowThePath = false;
            }
            else
            {
                RegexMatching matching = new RegexMatching(LocationExpressionStartWithTilde.RegularExpression);
                if (matching.IsMatch(path))
                {
                    Match match = matching.Match(path);
                    this.IsStartWithTilde = !object.ReferenceEquals(match.Groups["StartWith"], null) && match.Groups["StartWith"].Success && match.Groups["StartWith"].Value.Equals("~");
                    this.FollowThePath = !object.ReferenceEquals(match.Groups["Surffix"], null) && match.Groups["Surffix"].Success && match.Groups["Surffix"].Value.Equals(@"\");
                }
            }
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */