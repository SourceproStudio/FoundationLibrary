#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 11:27:50
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 定义了缓存项优先级。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItemPriority"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    [Serializable]
    public enum CacheItemPriority : int
    {
        /// <summary>
        /// 默认优先级。
        /// </summary>
        Default = 1,
        /// <summary>
        /// 从不删除此缓存项。
        /// </summary>
        NotRemovable,
        /// <summary>
        /// 最低优先级。
        /// </summary>
        Low,
        /// <summary>
        /// 低于Normal。
        /// </summary>
        BelowNormal,
        /// <summary>
        /// 默认优先级。
        /// </summary>
        Normal,
        /// <summary>
        /// 高于Normal。
        /// </summary>
        AboveNormal,
        /// <summary>
        /// 最高优先级。服务器释放内存时，此优先级的缓存项最不易被删除。
        /// </summary>
        High
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */