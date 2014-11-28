#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 10:45:08
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions
{
    /// <summary>
    /// <para>
    /// 提供了正则表达式匹配的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    /// </para>
    /// <para>
    /// Type : <see cref="RegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    public class RegexMatching : IMatching
    {
        private string _patternExpression;

        #region RegexMatching Constructors

        /// <summary>
        /// 用于初始化一个<see cref="RegexMatching" />对象实例。
        /// </summary>
        public RegexMatching()
        { }

        /// <summary>
        /// 用于初始化一个<see cref="RegexMatching" />对象实例。
        /// </summary>
        /// <param name="pattern">用于执行匹配的正则表达式。</param>
        public RegexMatching(string pattern)
            : this()
        {
            this.Pattern = pattern;
        }

        #endregion

        #region Pattern
        /// <summary>
        /// 用于执行匹配的正则表达式。
        /// </summary>
        /// <value>设置或获取用于执行匹配的正则表达式。</value>
        /// <exception cref="NullReferenceException">
        /// 当正则表达式为null、<see cref="string"/>.Empty时抛出此异常。
        /// </exception>
        public virtual string Pattern
        {
            get
            {
                if (string.IsNullOrEmpty(this._patternExpression))
                    throw new NullReferenceException();
                return this._patternExpression;
            }
            set
            {
                this._patternExpression = value;
            }
        }
        #endregion

        #region IsMatch
        /// <summary>
        /// 验证<paramref name="input"/>与<see cref="Pattern"/>匹配。
        /// </summary>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>如果匹配则返回true；否则返回false。</returns>
        public virtual bool IsMatch(string input, RegexOptions options = RegexOptions.None)
        {
            return Regex.IsMatch(input, this.Pattern, options);
        }
        #endregion

        #region Match
        /// <summary>
        /// 获取<paramref name="input"/>中与<see cref="Pattern"/>匹配的项。
        /// </summary>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="Match"/>对象实例。</returns>
        public virtual Match Match(string input, RegexOptions options = RegexOptions.None)
        {
            return this.IsMatch(input, options) ? Regex.Match(input, this.Pattern, options) : null;
        }
        #endregion

        #region Matches
        /// <summary>
        /// 获取<paramref name="input"/>与<see cref="Pattern"/>匹配的所有项。
        /// </summary>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="MatchCollection"/>对象实例。</returns>
        public virtual MatchCollection Matches(string input, RegexOptions options = RegexOptions.None)
        {
            return this.IsMatch(input, options) ? Regex.Matches(input, this.Pattern, options) : null;
        }
        #endregion

        #region Split
        /// <summary>
        /// 使用<see cref="Pattern"/>将<paramref name="input"/>分割成字符串数组。
        /// </summary>
        /// <param name="input">需要分割的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>
        /// <para><see cref="string"/>数组。</para>
        /// <para>如果<paramref name="input"/>与<see cref="Pattern"/>不匹配，则返回<paramref name="input"/>。</para>
        /// </returns>
        public virtual string[] Split(string input, RegexOptions options = RegexOptions.None)
        {
            return this.IsMatch(input, options) ? Regex.Split(input, this.Pattern, options) : new string[1] { input };
        }
        #endregion

        #region Replace
        /// <summary>
        /// 将<paramref name="input"/>中的<see cref="Pattern"/>匹配项替换成<paramref name="replace"/>。
        /// </summary>
        /// <param name="input">需要替换的字符串。</param>
        /// <param name="replace">替换字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>
        /// <para>替换后的字符串。</para>
        /// <para>如果<paramref name="input"/>不匹配<see cref="Pattern"/>则返回<paramref name="input"/>。</para>
        /// </returns>
        public virtual string Replace(string input, string replace, RegexOptions options = RegexOptions.None)
        {
            return this.IsMatch(input, options) ? Regex.Replace(input, this.Pattern, replace, options) : input;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */