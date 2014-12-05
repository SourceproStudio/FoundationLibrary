#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 14:26:06
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

using System.Collections.Generic;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching
{
    /// <summary>
    /// <para>
    /// 提供了访问缓存项依赖环境的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItemDependency"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching"/>
    public class CacheItemDependency
    {
        private IList<string> _dependencyFiles;

        #region DependencyFiles
        /// <summary>
        /// 缓存项依赖的文件。
        /// </summary>
        /// <value>获取缓存项依赖的文件。</value>
        public virtual IList<string> DependencyFiles
        {
            get { return _dependencyFiles; }
            protected set { _dependencyFiles = value; }
        }
        #endregion

        #region CacheItemDependency Constructors

        /// <summary>
        /// 用于初始化一个<see cref="CacheItemDependency" />对象实例。
        /// </summary>
        public CacheItemDependency()
        {
            this.DependencyFiles = new List<string>();
        }

        /// <summary>
        /// 用于初始化一个<see cref="CacheItemDependency" />对象实例。
        /// </summary>
        /// <param name="files">缓存项依赖的一组文件名称。</param>
        public CacheItemDependency(string[] files)
            : this()
        {
            this.DependencyFiles = new List<string>(files);
        }

        /// <summary>
        /// 用于初始化一个<see cref="CacheItemDependency" />对象实例。
        /// </summary>
        /// <param name="fileName">缓存项依赖的文件完整名称。</param>
        public CacheItemDependency(string fileName)
            : this(new string[1] { fileName })
        {
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */