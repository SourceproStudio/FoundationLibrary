#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-10 13:45:19
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
using System.Text;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections
{
    /// <summary>
    /// <para>
    /// 提供了Base64算法方式的保护方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// </para>
    /// <para>
    /// Type : <see cref="Base64Protection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="Base64Protection"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// <seealso cref="NoneProtection"/>
    /// <seealso cref="IDatabasePropertyProtection"/>
    /// <remarks>
    /// Can not inherit from <see cref="Base64Protection"/> !
    /// </remarks>
    public sealed class Base64Protection : NoneProtection, IDatabasePropertyProtection
    {
        #region Base64Protection Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="Base64Protection" />对象实例。
        /// </para>
        /// </summary>
        public Base64Protection()
        { }

        #endregion

        #region Protect
        /// <summary>
        /// 使用Base64算法保护属性值。
        /// </summary>
        /// <param name="value">属性值。</param>
        /// <returns>经过保护的属性值。</returns>
        public override string Protect(string value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(buffer);
        }
        #endregion

        #region UnProtect
        /// <summary>
        /// 使用Base64算法解除对字符串的保护。
        /// </summary>
        /// <param name="value">属性值。</param>
        /// <returns>解除保护的属性值。</returns>
        public override string UnProtect(string value)
        {
            byte[] buffer = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(buffer);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */