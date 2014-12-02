#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-02 10:07:32
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

using System.Collections;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources
{
    /// <summary>
    /// <para>
    /// 提供了读取*.resources文件的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="StringResourceReader"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    public class StringResourceReader : ResourceReader<string>
    {
        private StringResourceCollection _stringResources;

        #region StringResources
        /// <summary>
        /// 字符串资源。
        /// </summary>
        /// <value>获取字符串资源。</value>
        public virtual StringResourceCollection StringResources
        {
            get { return _stringResources; }
            protected set { _stringResources = value; }
        }
        #endregion

        #region StringResourceReader Constructors

        /// <summary>
        /// 用于初始化一个<see cref="StringResourceReader" />对象实例。
        /// </summary>
        /// <param name="fileName">*.resources资源文件完整名称。</param>
        public StringResourceReader(string fileName)
            : base(fileName)
        {
            this.StringResources = new StringResourceCollection();
        }

        #endregion

        #region LoadCurrentEntry
        /// <summary>
        /// 将当前的资源键值对加载到<see cref="StringResources"/>属性中。
        /// </summary>
        /// <param name="entry">资源键值对。</param>
        protected override void LoadCurrentEntry(DictionaryEntry entry)
        {
            string key = entry.Key.ToString();
            string value = object.ReferenceEquals(entry.Value, null) ? string.Empty : entry.Value.ToString();
            StringResource resourceItem = new StringResource(key, value);
            base.Resources.Add(key, resourceItem);
            this.StringResources.Add(key, resourceItem);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */