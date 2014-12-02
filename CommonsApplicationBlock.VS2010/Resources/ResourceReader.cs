#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-02 9:34:52
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
using System.Collections;
using System.IO;
using Reader = System.Resources.ResourceReader;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources
{
    /// <summary>
    /// <para>
    /// 提供了读取.resources资源文件的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ResourceReader{T}"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="ResourceReader{T}"/> is an abstract type !
    /// </para>
    /// </summary>
    /// <typeparam name="T">资源类型。</typeparam>
    /// <remarks>
    /// <see cref="ResourceReader{T}"/> is an abstract type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// <seealso cref="Reader"/>
    /// <seealso cref="ResourceCollection{T}"/>
    /// <seealso cref="Resource{T}"/>
    /// <seealso cref="IDictionaryEnumerator"/>
    /// <exception cref="ResourceFileNotFoundException">
    /// 当指定资源文件不存在时，抛出此异常。
    /// </exception>
    public abstract class ResourceReader<T>
    {
        private string _fileName;
        private ResourceCollection<T> _resources;

        #region FileName
        /// <summary>
        /// 资源文件完整名称。
        /// </summary>
        /// <value>获取资源文件完整名称。</value>
        public virtual string FileName
        {
            get { return _fileName; }
            protected set { _fileName = value; }
        }
        #endregion

        #region Resources
        /// <summary>
        /// 资源字典集合。
        /// </summary>
        /// <value>获取资源字典集合。</value>
        public virtual ResourceCollection<T> Resources
        {
            get { return _resources; }
            protected set { _resources = value; }
        }
        #endregion

        #region ResourceReader Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ResourceReader{T}" />对象实例。
        /// </summary>
        /// <param name="fileName">资源文件(*.resources)完整名称。</param>
        protected ResourceReader(string fileName)
        {
            this.FileName = fileName;
            this.Resources = new ResourceCollection<T>();
        }

        #endregion

        #region VerifyResourceFileIsExists
        /// <summary>
        /// 验证资源文件是否存在。
        /// </summary>
        protected virtual void VerifyResourceFileIsExists()
        {
            if (!File.Exists(this.FileName))
                throw new ResourceFileNotFoundException();
        }
        #endregion

        #region GetEnumerator
        /// <summary>
        /// 获取资源文件中的资源键值对。
        /// </summary>
        /// <param name="reader"><see cref="Reader"/>对象实例。</param>
        /// <returns>实现了<see cref="IDictionaryEnumerator"/>接口的对象实例。</returns>
        protected virtual IDictionaryEnumerator GetEnumerator(Reader reader)
        {
            return reader.GetEnumerator();
        }
        #endregion

        #region LoadCurrentEntry
        /// <summary>
        /// 将当前的键值对加载到Resources属性中。
        /// </summary>
        /// <param name="entry">键值对。</param>
        protected abstract void LoadCurrentEntry(DictionaryEntry entry);
        #endregion

        #region Read
        /// <summary>
        /// 读取资源文件。
        /// </summary>
        public virtual void Read()
        {
            this.VerifyResourceFileIsExists();
            using (Stream resourceStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read))
            {
                using (Reader resourceReader = new Reader(resourceStream))
                {
                    try
                    {
                        IDictionaryEnumerator enumerator = resourceReader.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            this.LoadCurrentEntry(enumerator.Entry);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        resourceReader.Close();
                        resourceStream.Close();
                    }
                }
            }
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */