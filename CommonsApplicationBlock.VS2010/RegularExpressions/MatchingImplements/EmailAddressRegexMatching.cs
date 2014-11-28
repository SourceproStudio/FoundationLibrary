#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 14:30:17
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements
{
    /// <summary>
    /// <para>
    /// 提供了匹配电子邮件地址的正则表达式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="EmailAddressRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="EmailAddressRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="EmailAddressRegexMatching"/> !
    /// </remarks>
    public sealed class EmailAddressRegexMatching : RegexMatching, IMatching
    {
        private const string Expression = @"(?<UserName>[a-zA-Z\d\.\-_]+)@(?<DomainName>[\da-zA-z\-_]+\.[\da-zA-Z\-_]+(\.[\da-zA-Z\-_]+)?)";

        #region EmailAddressRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="EmailAddressRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        public EmailAddressRegexMatching()
            : base(Expression)
        { }

        #endregion

        #region GetMatchDomainName
        /// <summary>
        /// 获取匹配的邮箱域名。
        /// </summary>
        /// <param name="match"><see cref="Match"/>对象实例。</param>
        /// <returns>
        /// <para>捕获的邮箱域名。</para>
        /// <para>如果不匹配，则返回<see cref="string"/>.Empty。</para>
        /// </returns>
        static public string GetMatchDomainName(Match match)
        {
            if (match.Success && !object.ReferenceEquals(match.Groups["DomainName"], null) && match.Groups["DomainName"].Success && !string.IsNullOrWhiteSpace(match.Groups["DomainName"].Value))
                return match.Groups["DomainName"].Value;
            else
                return string.Empty;
        }
        #endregion

        #region GetMatchEmailDescriptionName
        /// <summary>
        /// 获取匹配的邮箱描述名称。
        /// </summary>
        /// <param name="match"><see cref="Match"/>对象实例。</param>
        /// <returns>
        /// <para>捕获的邮箱名称。</para>
        /// <para>如果不匹配，则返回<see cref="string"/>.Empty。</para>
        /// </returns>
        static public string GetMatchEmailDescriptionName(Match match)
        {
            if (match.Success && !object.ReferenceEquals(match.Groups["UserName"], null) && match.Groups["UserName"].Success && !string.IsNullOrWhiteSpace(match.Groups["UserName"].Value))
                return match.Groups["UserName"].Value;
            else
                return string.Empty;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */