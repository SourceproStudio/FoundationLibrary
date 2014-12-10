#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-10 13:41:20
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


namespace SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections
{
    /// <summary>
    /// <para>
    /// 未提供任何保护方式。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// </para>
    /// <para>
    /// Type : <see cref="NoneProtection"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.Protections"/>
    /// <seealso cref="IDatabasePropertyProtection"/>
    public class NoneProtection : IDatabasePropertyProtection
    {
        #region NoneProtection Constructors

        /// <summary>
        /// 用于初始化一个<see cref="NoneProtection" />对象实例。
        /// </summary>
        public NoneProtection()
        { }

        #endregion

        #region Protect
        /// <summary>
        /// 获取原始数据库属性值。
        /// </summary>
        /// <param name="value">属性值。</param>
        /// <returns>未经过任何保护方式处理的属性值。</returns>
        public virtual string Protect(string value)
        {
            return value;
        }
        #endregion

        #region UnProtect
        /// <summary>
        /// 获取原始属性值。
        /// </summary>
        /// <param name="value">属性值。</param>
        /// <returns>未经过任何保护方式处理的属性值。</returns>
        public virtual string UnProtect(string value)
        {
            return value;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */