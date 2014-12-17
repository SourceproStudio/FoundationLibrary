#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-17 16:45:53
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

namespace SourcePro.Csharp.Lab.Commons
{
    /// <summary>
    /// <para>
    /// 生成反射信息错误回调方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="GenerateReflectionInfoErrorHandler"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <param name="fileName">发射错误的文件名称。</param>
    /// <seealso cref="SourcePro.Csharp.Lab.Commons"/>
    public delegate void GenerateReflectionInfoErrorHandler(string fileName);
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */