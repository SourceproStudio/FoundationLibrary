#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-10 14:15:16
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
using System.Globalization;
using System.Text.RegularExpressions;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections
{
    /// <summary>
    /// <para>
    /// 针对<see cref="int"/>类型的属性值，提供的16进制保护方式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// </para>
    /// <para>
    /// Type : <see cref="HexProtection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="HexProtection"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// <seealso cref="NoneProtection"/>
    /// <seealso cref="IDatabasePropertyProtection"/>
    /// <remarks>
    /// Can not inherit from <see cref="HexProtection"/> !
    /// </remarks>
    public sealed class HexProtection : NoneProtection, IDatabasePropertyProtection
    {
        private const string RegularExpression1 = @"^\{HEX:0x(?<HexString>[0-9a-fA-F]*)\}$";
        private const string RegularExpression2 = @"^\d*$";

        #region IsInteger
        /// <summary>
        /// 验证字符串<paramref name="s"/>是否为一个整型值字符串序列。
        /// </summary>
        /// <param name="s">需要验证的字符串。</param>
        /// <returns>true or false。</returns>
        private bool IsInteger(string s)
        {
            RegexMatching matching = new RegexMatching(RegularExpression2);
            return matching.IsMatch(s, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }
        #endregion

        #region Protect
        /// <summary>
        /// 对<paramref name="value"/>进行保护。
        /// </summary>
        /// <param name="value">需要保护的字符串。</param>
        /// <returns>经过保护的字符串。</returns>
        /// <exception cref="ArgumentException">
        /// 当<paramref name="value"/>不是一个字符串序列时抛出此异常。
        /// </exception>
        public override string Protect(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "(none)";
            }
            else
            {
                if (!this.IsInteger(value)) throw new ArgumentException();
                return this.Protect(int.Parse(value));
            }
        }
        #endregion

        #region Protect
        /// <summary>
        /// 执行保护，并返回指定格式的字符串。
        /// </summary>
        /// <param name="value">需要保护的整型值。</param>
        /// <returns>16进制格式的字符串。</returns>
        public string Protect(int value)
        {
            return string.Format("{0}HEX:0x{1}{2}", "{", value.ToString("X"), "}");
        }
        #endregion

        #region UnProtect
        /// <summary>
        /// 对指定字符串解除保护。
        /// </summary>
        /// <param name="value">需要解除保护的字符串。</param>
        /// <returns>字符串。</returns>
        /// <exception cref="ArgumentException">
        /// 当<paramref name="value"/>的格式不符合指定格式时，抛出此异常。
        /// </exception>
        public override string UnProtect(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.ToLower().Equals("(none)"))
            {
                return "0";
            }
            else
            {
                RegexMatching matching = new RegexMatching(RegularExpression1);
                if (!matching.IsMatch(value)) throw new ArgumentException();
                Match match = matching.Match(value, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (!object.ReferenceEquals(match.Groups["HexString"], null) && match.Groups["HexString"].Success && !string.IsNullOrWhiteSpace(match.Groups["HexString"].Value))
                {
                    return int.Parse(match.Groups["HexString"].Value, NumberStyles.AllowHexSpecifier).ToString();
                }
                else return "0";
            }
        }
        #endregion

        #region HexProtection Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="HexProtection" />对象实例。
        /// </para>
        /// </summary>
        public HexProtection()
        { }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */