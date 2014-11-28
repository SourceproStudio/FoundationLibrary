#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 15:05:47
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
    /// 提供了匹配手机号码的正则表达式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="MobileNumberRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="MobileNumberRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="MobileNumberRegexMatching"/> !
    /// </remarks>
    public sealed class MobileNumberRegexMatching : RegexMatching, IMatching
    {
        private const string Expression = @"(?<Globalization>\+?\d{2,})?\-?\s?(?<MobileNumber>1\d{10})";

        #region MobileNumberRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="MobileNumberRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        public MobileNumberRegexMatching()
            : base(Expression)
        { }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */