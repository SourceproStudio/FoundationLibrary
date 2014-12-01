#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 11:08:03
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


namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements
{
    /// <summary>
    /// <para>
    /// 提供了验证IP地址的正则表达式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IPAddressRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="IPAddressRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="IPAddressRegexMatching"/> !
    /// </remarks>
    public sealed class IPAddressRegexMatching : RegexMatching, IMatching
    {
        private const string Expression = @"(25[0-5]|2[0-4]\d|\d|[1-9]\d|1\d{2})\.(25[0-5]|2[0-4]\d|\d|[1-9]\d|1\d{2})\.(25[0-5]|2[0-4]\d|\d|[1-9]\d|1\d{2})\.(25[0-5]|2[0-4]\d|\d|[1-9]\d|1\d{2})";

        #region IPAddressRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="IPAddressRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        public IPAddressRegexMatching()
            : base(Expression)
        { }

        #endregion
    }
}

/*
 * 参考资料：
 * 
 * http://www.cnblogs.com/txw1958/archive/2011/10/13/2210114.html
 * http://www.cnblogs.com/txw1958/archive/2011/10/13/ip_address_regular_expression.html
 */

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */