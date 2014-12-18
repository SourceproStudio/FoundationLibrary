#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-17 15:41:29
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
using System.IO;
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
    /// Type : <see cref="DynamicAssemblyDomain"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Commons"/>
    public class DynamicAssemblyDomain
    {
        private AppDomain _domain;
        private DynamicAssembly _dynamicAssembly;

        #region DynamicAssemblyDomain Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DynamicAssemblyDomain" />对象实例。
        /// </summary>
        /// <param name="fileName">程序集文件名称。</param>
        public DynamicAssemblyDomain(string fileName)
        {
            _domain = AppDomain.CreateDomain("SourceProStudio.ConfiguratonConsole.PrivateAppDomain");
            this._dynamicAssembly = (DynamicAssembly)_domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().GetName().Name + ".exe", "SourcePro.Csharp.Lab.Commons.DynamicAssembly");
            this._dynamicAssembly.FileName = fileName;
        }

        #endregion

        #region GetTypes
        /// <summary>
        /// 获取指定程序集中所有的类型。
        /// </summary>
        /// <returns><see cref="IList{T}"/>对象实例。</returns>
        public IList<Type> GetTypes()
        {
            IList<Type> list = this._dynamicAssembly.GetTypes();
            AppDomain.Unload(this._domain);
            return list;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */