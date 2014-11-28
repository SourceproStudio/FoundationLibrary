#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 10:16:38
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions
{
    /// <summary>
    /// <para>
    /// 定义了正则表达式匹配的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    /// <seealso cref="RegexOptions"/>
    /// <seealso cref="Match"/>
    /// <seealso cref="MatchCollection"/>
    public interface IMatching
    {
        #region Pattern
        /// <summary>
        /// 用于匹配的正则表达式。
        /// </summary>
        /// <value>设置或获取用于匹配的正则表达式。</value>
        string Pattern { get; set; }
        #endregion

        #region IsMatch
        /// <summary>
        /// 验证<paramref name="input"/>是否匹配。
        /// </summary>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>选项值。</param>
        /// <returns>如果匹配返回true；否则返回false。</returns>
        bool IsMatch(string input, RegexOptions options = RegexOptions.None);
        #endregion

        #region Match
        /// <summary>
        /// 获取匹配项。
        /// </summary>
        /// <param name="input">需要执行匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="Match"/>对象实例。</returns>
        Match Match(string input, RegexOptions options = RegexOptions.None);
        #endregion

        #region Matches
        /// <summary>
        /// 获取所有匹配项。
        /// </summary>
        /// <param name="input">需要执行匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="MatchCollection"/>对象实例。</returns>
        MatchCollection Matches(string input, RegexOptions options = RegexOptions.None);
        #endregion

        #region Split
        /// <summary>
        /// 按照指定正则表达式匹配模式进行分割。
        /// </summary>
        /// <param name="input">需要执行匹配分割的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>
        /// <para><see cref="string"/>数组。</para>
        /// <para>如果不匹配，则返回<paramref name="input"/>。</para>
        /// </returns>
        string[] Split(string input, RegexOptions options = RegexOptions.None);
        #endregion

        #region Replace
        /// <summary>
        /// 如果匹配，则用<paramref name="replace"/>替换掉<paramref name="input"/>中所有匹配项。
        /// </summary>
        /// <param name="input">需要执行替换的字符串。</param>
        /// <param name="replace">替换的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>
        /// <para>替换后的字符串。</para>
        /// <para>如果<paramref name="input"/>不匹配，则返回<paramref name="input"/>。</para>
        /// </returns>
        string Replace(string input, string replace, RegexOptions options = RegexOptions.None);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */