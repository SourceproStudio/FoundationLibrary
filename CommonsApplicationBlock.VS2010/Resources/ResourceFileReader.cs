#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 13:58:14
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
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources
{
    /// <summary>
    /// <para>
    /// 提供了读取资源文件的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ResourceFileReader"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="ResourceFileReader"/> is an abstract type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="ResourceFileReader"/> is an abstract type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Resources"/>
    public abstract class ResourceFileReader
    {
        private string _name;
        private FileInfo _info;

        #region Name
        /// <summary>
        /// 资源文件名称。
        /// </summary>
        /// <value>设置或获取资源文件名称。</value>
        public virtual string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        #endregion

        #region Info
        /// <summary>
        /// 资源文件相关信息。
        /// </summary>
        /// <value>设置或获取资源文件相关信息。</value>
        protected virtual FileInfo Info
        {
            get { return _info; }
            set { _info = value; }
        }
        #endregion

        #region ResourceFileReader Constructors

        /// <summary>
        /// 用于初始化一个<see cref="ResourceFileReader" />对象实例。
        /// </summary>
        /// <param name="name">资源文件完整名称。</param>
        protected ResourceFileReader(string name)
        {
            this.Name = name;
            this.Info = new FileInfo(this.Name);
        }

        #endregion

        #region VerifyResourceFileIsExists
        /// <summary>
        /// 验证资源文件是否存在。
        /// </summary>
        protected virtual void VerifyResourceFileIsExists()
        {
            if (!this.Info.Exists)
                throw new ResourceFileNotFoundException();
        }
        #endregion

        #region ReadResourceFile
        /// <summary>
        /// 读取资源文件。
        /// </summary>
        /// <typeparam name="T">资源类型。</typeparam>
        /// <returns><see cref="ResourceCollection{T}"/>对象实例。</returns>
        protected virtual ResourceCollection<T> ReadResourceFile<T>()
        {
            this.VerifyResourceFileIsExists();
            List<Resource<T>> resources = new List<Resource<T>>();
            using (Stream resourceFileStream = new FileStream(this.Info.FullName, FileMode.Open, FileAccess.Read))
            {
                using (ResourceReader resourceReader = new ResourceReader(resourceFileStream))
                {
                    try
                    {
                        IDictionaryEnumerator resourceDic = resourceReader.GetEnumerator();
                        while (resourceDic.MoveNext())
                        {
                            this.InsertResourceValueIntoList<T>(resources, resourceDic.Entry);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        resourceReader.Close();
                        resourceFileStream.Close();
                    }
                }
            }
            return new ResourceCollection<T>(resources);
        }
        #endregion

        #region InsertResourceValueIntoList
        /// <summary>
        /// 将<paramref name="entry"/>资源插入到<paramref name="destination"/>集合中。
        /// </summary>
        /// <typeparam name="T">资源类型。</typeparam>
        /// <param name="destination">列表集合。</param>
        /// <param name="entry">资源键值对。</param>
        protected abstract void InsertResourceValueIntoList<T>(IList<Resource<T>> destination, DictionaryEntry entry);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */