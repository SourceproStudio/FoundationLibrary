#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-17 15:36:10
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
using System.Reflection;
using System.Collections.Generic;

namespace SourcePro.Csharp.Lab.Commons
{
    /// <summary>
    /// <para>
    /// 提供了动态加载程序集的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DynamicAssembly"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Commons"/>
    public class DynamicAssembly : MarshalByRefObject
    {
        private string _fileName;

        #region FileName
        /// <summary>
        /// 程序集文件名称。
        /// </summary>
        /// <value>设置或获取程序集文件名称。</value>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        #endregion

        #region DynamicAssembly Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DynamicAssembly" />对象实例。
        /// </summary>
        public DynamicAssembly()
        {
        }

        #endregion

        #region Load
        /// <summary>
        /// 加载程序集。
        /// </summary>
        /// <returns><see cref="Assembly"/>对象实例。</returns>
        private Assembly Load()
        {
            try
            {
                return Assembly.LoadFile(this._fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetTypes
        /// <summary>
        /// 获取指定程序集中所有的类型字符串。
        /// </summary>
        /// <returns><see cref="IList{T}"/>对象实例。</returns>
        public IList<string> GetTypes()
        {
            List<string> typeList = new List<string>();
            Type[] types = this.Load().GetTypes();
            foreach (Type item in types) typeList.Add(item.AssemblyQualifiedName);
            return typeList;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */