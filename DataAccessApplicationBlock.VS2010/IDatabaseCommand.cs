#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 11:08:55
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
    /// 定义了数据库命令相关的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabaseCommand"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="CommandType"/>
    /// <seealso cref="DbCommand"/>
    /// <seealso cref="DbTransaction"/>
    /// <seealso cref="DataSet"/>
    /// <seealso cref="DbDataReader"/>
    /// <seealso cref="CommandBehavior"/>
    /// <seealso cref="DataReaderAnalyzer"/>
    public interface IDatabaseCommand
    {
        #region CreateCommand
        /// <summary>
        /// 创建一个数据库命令对象实例。
        /// </summary>
        /// <param name="cmdText">数据库命令文本。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateCommand(string cmdText, CommandType cmdType);

        /// <summary>
        /// 创建一个数据库命令对象实例。
        /// </summary>
        /// <param name="cmdText">数据库命令文本。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateCommand(string cmdText);

        /// <summary>
        /// 创建一个事务性的数据库命令对象实例。
        /// </summary>
        /// <param name="cmdText">数据库命令文本。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateCommand(string cmdText, CommandType cmdType, DbTransaction transaction);

        /// <summary>
        /// 创建一个事务性的数据库命令对象实例。
        /// </summary>
        /// <param name="cmdText">数据库命令文本。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateCommand(string cmdText, DbTransaction transaction);
        #endregion

        #region CreateStoredProcedure
        /// <summary>
        /// 创建一个存储过程命令对象实例。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateStoredProcedure(string storedprocName);

        /// <summary>
        /// 创建一个事务性的存储过程命令对象实例。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        DbCommand CreateStoredProcedure(string storedprocName, DbTransaction transaction);
        #endregion

        #region ExecuteFill
        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并填充数据集<paramref name="dataSet"/>。
        /// </summary>
        /// <param name="selectCmd">查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        void ExecuteFill(DbCommand selectCmd, DataSet dataSet);

        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并填充数据集<paramref name="dataSet"/>。
        /// </summary>
        /// <param name="selectCmd">查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        void ExecuteFill(string selectCmd, DataSet dataSet);
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并返回数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <returns><see cref="DataSet"/>对象实例。</returns>
        DataSet ExecuteDataSet(DbCommand selectCmd);

        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并返回数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <returns><see cref="DataSet"/>对象实例。</returns>
        DataSet ExecuteDataSet(string selectCmd);
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并返回<see cref="DbDataReader"/>。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="behavior">
        /// <para><see cref="CommandBehavior"/>中的一个值。</para>
        /// <para>默认为:<see cref="CommandBehavior"/>.Default。</para>
        /// </param>
        /// <returns><see cref="DbDataReader"/>对象实例。</returns>
        DbDataReader ExecuteReader(DbCommand selectCmd, CommandBehavior behavior = CommandBehavior.Default);

        /// <summary>
        /// 执行<paramref name="selectCmd"/>查询命令，并返回<see cref="DbDataReader"/>。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="behavior">
        /// <para><see cref="CommandBehavior"/>中的一个值。</para>
        /// <para>默认为:<see cref="CommandBehavior"/>.Default。</para>
        /// </param>
        /// <returns><see cref="DbDataReader"/>对象实例。</returns>
        DbDataReader ExecuteReader(string selectCmd, CommandBehavior behavior = CommandBehavior.Default);
        #endregion

        #region ExecuteAnalysis
        /// <summary>
        /// 逐个分析<paramref name="dataReader"/>中的结果。
        /// </summary>
        /// <param name="dataReader"><see cref="DbDataReader"/>对象实例。</param>
        /// <param name="method"><see cref="DataReaderAnalyzer"/>委托。</param>
        void ExecuteAnalysis(DbDataReader dataReader, DataReaderAnalyzer method);
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库命令，并返回影响行数。
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/>对象实例。</param>
        /// <returns>影响行数。</returns>
        int ExecuteNonQuery(DbCommand cmd);

        /// <summary>
        /// 执行数据库命令，并返回影响行数。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>影响行数。</returns>
        int ExecuteNonQuery(string cmd);
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行数据库命令，并返回标量值。
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/>对象实例。</param>
        /// <returns>未知对象实例。</returns>
        object ExecuteScalar(DbCommand cmd);

        /// <summary>
        /// 执行数据库命令，并返回标量值。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>未知对象实例。</returns>
        object ExecuteScalar(string cmd);
        #endregion

        #region Event AfterExecuted
        /// <summary>
        /// 数据库命令执行事件。
        /// </summary>
        event DatabaseCommandExecuteEventHandler AfterExecuted;
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */