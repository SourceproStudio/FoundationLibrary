#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-10 11:51:06
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


namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 定义了保护数据库属性的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabasePropertyProtection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    public interface IDatabasePropertyProtection
    {
        #region Protect
        /// <summary>
        /// 执行保存。
        /// </summary>
        /// <param name="value">需要执行保护的属性值。</param>
        /// <returns>执行保护后的属性值。</returns>
        string Protect(string value);
        #endregion

        #region UnProtect
        /// <summary>
        /// 执行反保护，获取原始属性值。
        /// </summary>
        /// <param name="value">保护后的属性值字符串。</param>
        /// <returns>反保护后的属性值字符串。</returns>
        string UnProtect(string value);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */