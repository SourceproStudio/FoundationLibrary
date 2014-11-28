#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 13:57:16
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
    /// 提供了标准日期时间格式匹配正则表达式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DateTimeRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="DateTimeRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="DateTimeRegexMatching"/> !
    /// </remarks>
    public sealed class DateTimeRegexMatching : RegexMatching, IMatching
    {
        private const string Expression = @"(?<Year>[1-9]\d{3})(?<YearSplitter>[-\/年\._])(?<Month>(1[0-2])|(0?[1-9]))(?<MonthSplitter>[-\/月\._])(?<Day>(3[01])|(2\d)|(1\d)|0?[1-9])(?<DaySplitter>[\s日])?";

        #region DateTimeRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="DateTimeRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        public DateTimeRegexMatching()
            : base(Expression)
        { }

        #endregion

        #region GetMatchDay
        /// <summary>
        /// 获取匹配的日期值。
        /// </summary>
        /// <param name="match"><see cref="Match"/>对象实例。</param>
        /// <returns>
        /// <para>匹配的日期字符串。</para>
        /// <para>如果不匹配则返回<see cref="string"/>.Empty</para>
        /// </returns>
        static public string GetMatchDay(Match match)
        {
            if (match.Success && !object.ReferenceEquals(match.Groups["Day"], null) && match.Groups["Day"].Success && !string.IsNullOrWhiteSpace(match.Groups["Day"].Value))
                return match.Groups["Day"].Value;
            else
                return string.Empty;
        }
        #endregion

        #region GetMatchMonth
        /// <summary>
        /// 获取匹配的月份值。
        /// </summary>
        /// <param name="match"><see cref="Match"/>对象实例。</param>
        /// <returns>
        /// <para>匹配的月份字符串。</para>
        /// <para>如果不匹配则返回<see cref="string"/>.Empty</para>
        /// </returns>
        static public string GetMatchMonth(Match match)
        {
            if (match.Success && !object.ReferenceEquals(match.Groups["Month"], null) && match.Groups["Month"].Success && !string.IsNullOrWhiteSpace(match.Groups["Month"].Value))
                return match.Groups["Month"].Value;
            else
                return string.Empty;
        }
        #endregion

        #region GetMatchYear
        /// <summary>
        /// 获取匹配的年份值。
        /// </summary>
        /// <param name="match"><see cref="Match"/>对象实例。</param>
        /// <returns>
        /// <para>匹配的年份字符串。</para>
        /// <para>如果不匹配则返回<see cref="string"/>.Empty</para>
        /// </returns>
        static public string GetMatchYear(Match match)
        {
            if (match.Success && !object.ReferenceEquals(match.Groups["Year"], null) && match.Groups["Year"].Success && !string.IsNullOrWhiteSpace(match.Groups["Year"].Value))
                return match.Groups["Year"].Value;
            else
                return string.Empty;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */