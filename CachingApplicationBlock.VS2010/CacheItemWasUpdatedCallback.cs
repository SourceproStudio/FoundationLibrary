#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 10:54:13
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


namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 缓存项被更新后的执行的回调方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItemWasUpdatedCallback"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <param name="key">被更新的缓存项标识名称。</param>
    /// <param name="state">附加的参数。</param>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    public delegate void CacheItemWasUpdatedCallback(string key, object state);
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */