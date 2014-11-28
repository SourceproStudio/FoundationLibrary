#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-11-28 15:01:13
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
    /// 提供了匹配（固定）电话号码的正则表达式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// </para>
    /// <para>
    /// Type : <see cref="TelephoneNumberRegexMatching"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="TelephoneNumberRegexMatching"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements"/>
    /// <remarks>
    /// Can not inherit from <see cref="TelephoneNumberRegexMatching"/> !
    /// </remarks>
    public sealed class TelephoneNumberRegexMatching : RegexMatching, IMatching
    {
        private const string Expression = @"(?<Globalization>\+?\d{2,})?\s?(?<Region>\d{2,})?\-?\s?(?<PhoneNumber>\d{6,8})\s?(?<ExtSplitter>[\-\s转\(])?(?<ExtNumber>\d*)\)?";

        #region TelephoneNumberRegexMatching Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="TelephoneNumberRegexMatching" />对象实例。
        /// </para>
        /// </summary>
        public TelephoneNumberRegexMatching()
            : base(Expression)
        { }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */