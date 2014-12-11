#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 13:24:22
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
using System.Data.Common;
using System.Data;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 定义了访问数据库参数的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabaseParameter"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DbParameter"/>
    /// <seealso cref="ParameterDirection"/>
    /// <seealso cref="DbType"/>
    public interface IDatabaseParameter
    {
        #region ParameterNamePrefix
        /// <summary>
        /// 构成参数名称的前缀。
        /// </summary>
        /// <value>获取构成参数名称的前缀。</value>
        string ParameterNamePrefix { get; }
        #endregion

        #region CreateParameter
        /// <summary>
        /// 创建参数。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="direction"><see cref="ParameterDirection"/>中的一个值。</param>
        /// <param name="dbType"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="DbParameter"/>对象实例。</returns>
        DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, DbType dbType = DbType.Object);
        #endregion

        #region AddParameters
        /// <summary>
        /// 添加<paramref name="parameters"/>到命令<paramref name="cmd"/>中。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <param name="parameters">参数数组。</param>
        void AddParameters(DbCommand cmd, params DbParameter[] parameters);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */