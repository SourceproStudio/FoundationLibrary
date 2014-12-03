#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-03 11:34:54
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


namespace SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal
{
    /// <summary>
    /// <para>
    /// 提供了<see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.CacheItemPriority"/>向<see cref="System.Runtime.Caching.CacheItemPriority"/>转换的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    /// </para>
    /// <para>
    /// Type : <see cref="CacheItemPriorityConverter"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.Internal"/>
    internal class CacheItemPriorityConverter
    {
        private CacheItemPriority _sourcePriority;

        #region SourcePriority
        /// <summary>
        /// 需要转换的<see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.CacheItemPriority"/>值。
        /// </summary>
        /// <value>设置或获取需要转换的<see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.CacheItemPriority"/>值。</value>
        internal CacheItemPriority SourcePriority
        {
            get { return _sourcePriority; }
            set { _sourcePriority = value; }
        }
        #endregion

        #region CacheItemPriorityConverter Constructors

        /// <summary>
        /// 用于初始化一个<see cref="CacheItemPriorityConverter" />对象实例。
        /// </summary>
        /// <param name="priority">需要转换的<see cref="SourcePro.Csharp.Practices.FoundationLibrary.Caching.CacheItemPriority"/>值。</param>
        internal CacheItemPriorityConverter(CacheItemPriority priority)
        {
            this.SourcePriority = priority;
        }

        #endregion

        #region Convert
        /// <summary>
        /// 将SourcePriority转换成<see cref="System.Runtime.Caching.CacheItemPriority"/>值。
        /// </summary>
        /// <returns><see cref="System.Runtime.Caching.CacheItemPriority"/>值。</returns>
        internal System.Runtime.Caching.CacheItemPriority Convert()
        {
            return 
                this.SourcePriority == CacheItemPriority.NotRemovable 
                    ? System.Runtime.Caching.CacheItemPriority.NotRemovable 
                    : System.Runtime.Caching.CacheItemPriority.Default;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */