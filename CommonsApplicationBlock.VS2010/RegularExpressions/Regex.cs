#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 11:18:17
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
    /// 提供了执行正则匹配的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    /// </para>
    /// <para>
    /// Type : <see cref="Regex&lt;T&gt;"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="Regex&lt;T&gt;"/> is a static type !
    /// </para>
    /// </summary>
    /// <typeparam name="T">实现了<see cref="IMatching"/>接口的类型。</typeparam>
    /// <remarks>
    /// <see cref="Regex&lt;T&gt;"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions"/>
    /// <seealso cref="IMatching"/>
    /// <seealso cref="RegexOptions"/>
    /// <seealso cref="Match"/>
    /// <seealso cref="MatchCollection"/>
    public static class Regex<T>
        where T : class, IMatching
    {
        #region IsMatch
        /// <summary>
        /// 使用<paramref name="match"/>验证<paramref name="input"/>是否匹配。
        /// </summary>
        /// <param name="match">实现了<see cref="IMatching"/>接口的类型。</param>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>如果匹配则返回true；否则返回false。</returns>
        static public bool IsMatch(T match, string input, RegexOptions options = RegexOptions.None)
        {
            return match.IsMatch(input, options);
        }
        #endregion

        #region Match
        /// <summary>
        /// 获取<paramref name="input"/>中的第一个匹配项。
        /// </summary>
        /// <param name="match">实现了<see cref="IMatching"/>接口的类型。</param>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="Match"/>对象实例。</returns>
        static public Match Match(T match, string input, RegexOptions options = RegexOptions.None)
        {
            return match.Match(input, options);
        }
        #endregion

        #region Matches
        /// <summary>
        /// 获取<paramref name="input"/>中的所有匹配项。
        /// </summary>
        /// <param name="match">实现了<see cref="IMatching"/>接口的类型。</param>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="MatchCollection"/>对象实例。</returns>
        static public MatchCollection Matches(T match, string input, RegexOptions options = RegexOptions.None)
        {
            return match.Matches(input, options);
        }
        #endregion

        #region Split
        /// <summary>
        /// 使用<paramref name="match"/>将<paramref name="input"/>分割成字符串数组。
        /// </summary>
        /// <param name="match">实现了<see cref="IMatching"/>接口的类型。</param>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns><see cref="string"/>数组。</returns>
        static public string[] Split(T match, string input, RegexOptions options = RegexOptions.None)
        {
            return match.Split(input, options);
        }
        #endregion

        #region Replace
        /// <summary>
        /// 使用<paramref name="match"/>将<paramref name="input"/>中所有匹配项替换成<paramref name="replace"/>
        /// </summary>
        /// <param name="match">实现了<see cref="IMatching"/>接口的类型。</param>
        /// <param name="input">需要匹配的字符串。</param>
        /// <param name="replace">需要替换的字符串。</param>
        /// <param name="options"><see cref="RegexOptions"/>匹配选项。</param>
        /// <returns>替换后的字符串。</returns>
        static public string Replace(T match, string input, string replace, RegexOptions options = RegexOptions.None)
        {
            return match.Replace(input, replace, options);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */