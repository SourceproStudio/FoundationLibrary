#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-12 11:39:02
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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient
{
    /// <summary>
    /// <para>
    /// 提供了访问Microsoft SQL Server数据库的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient"/>
    /// </para>
    /// <para>
    /// Type : <see cref="SqlDatabase"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient"/>
    [DatabaseDescription("Microsoft.Products.SqlServer")]
    public class SqlDatabase : Database, IDatabaseProvider, IDatabaseConnection, IDatabaseTransaction, IDatabaseParameter, IDatabaseCommand, IDisposable
    {
        private SqlConnection _sqlConnection;

        #region SqlConnection
        /// <summary>
        /// SQL Server数据库连接对象。
        /// </summary>
        /// <value>获取SQL Server数据库连接对象。</value>
        public virtual SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
            protected set { _sqlConnection = value; }
        }
        #endregion

        #region SqlDatabase Constructors

        /// <summary>
        /// 用于初始化一个<see cref="SqlDatabase" />对象实例。
        /// </summary>
        /// <param name="connectionString">SQL Server数据库连接串。</param>
        public SqlDatabase(string connectionString)
            : base(connectionString)
        { }

        /// <summary>
        /// 用于初始化一个<see cref="SqlDatabase" />对象实例。
        /// </summary>
        /// <param name="initializer">用于初始化的数据库对象。</param>
        public SqlDatabase(DatabaseInitializer initializer)
            : base(initializer)
        {
        }

        #endregion

        #region InitializeConnection
        /// <summary>
        /// 初始化SQL Server数据库连接。
        /// </summary>
        protected override void InitializeConnection()
        {
            this.SqlConnection = new SqlConnection(this.ConnectionString);
            this.BaseConnection = this.SqlConnection;
        }
        #endregion

        #region CreateSqlParameter
        /// <summary>
        /// 创建一个<see cref="SqlParameter"/>对象实例。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="direction"><see cref="ParameterDirection"/>中的一个值。</param>
        /// <param name="sqlDbType"><see cref="SqlDbType"/>中的一个值。</param>
        /// <returns><see cref="SqlParameter"/>对象实例。</returns>
        public virtual SqlParameter CreateSqlParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, SqlDbType sqlDbType = SqlDbType.Variant)
        {
            return new SqlParameter(this.BuildParameterName(name), value) { Direction = direction, SqlDbType = sqlDbType };
        }
        #endregion

        #region CreateParameter
        /// <summary>
        /// 创建一个<see cref="SqlParameter"/>对象实例。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="direction"><see cref="ParameterDirection"/>中的一个值。</param>
        /// <param name="dbType"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="SqlParameter"/>对象实例。</returns>
        public override DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, DbType dbType = DbType.Object)
        {
            return this.CreateSqlParameter(name, value, direction, dbType.ToSqlDbType());
        }
        #endregion

        #region CreateSqlOutputParameter
        /// <summary>
        /// 创建一个用于输出的<see cref="SqlParameter"/>对象实例。
        /// </summary>
        /// <param name="name">数据库参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="sqlDbType"><see cref="SqlDbType"/>中的一个值。</param>
        /// <returns><see cref="SqlParameter"/>对象实例。</returns>
        public virtual SqlParameter CreateSqlOutputParameter(string name, object value, SqlDbType sqlDbType = SqlDbType.Variant)
        {
            SqlParameter parameter = this.CreateSqlParameter(name, value, ParameterDirection.Output, sqlDbType);
            return parameter;
        }

        /// <summary>
        /// 创建一个用于输出的<see cref="SqlParameter"/>对象实例。
        /// </summary>
        /// <param name="name">数据库参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="size">以字节为单位数据参数长度。</param>
        /// <param name="sqlDbType"><see cref="SqlDbType"/>中的一个值。</param>
        /// <returns><see cref="SqlParameter"/>对象实例。</returns>
        public virtual SqlParameter CreateSqlOutputParameter(string name, object value, int size, SqlDbType sqlDbType = SqlDbType.Variant)
        {
            SqlParameter parameter = this.CreateSqlOutputParameter(name, value, sqlDbType);
            parameter.Size = size;
            return parameter;
        }
        #endregion

        #region AddParameters
        /// <summary>
        /// 添加<paramref name="parameters"/>到<paramref name="cmd"/>命令中。
        /// </summary>
        /// <param name="cmd"><see cref="SqlCommand"/>对象实例。</param>
        /// <param name="parameters"><see cref="SqlParameter"/>对象实例数组。</param>
        public virtual void AddParameters(SqlCommand cmd, params SqlParameter[] parameters)
        {
            base.AddParameters(cmd, parameters);
        }
        #endregion

        #region BeginSqlTransaction
        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <returns><see cref="SqlTransaction"/>对象实例。</returns>
        public virtual SqlTransaction BeginSqlTransaction()
        {
            return this.SqlConnection.BeginTransaction();
        }

        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <param name="isolation"><see cref="IsolationLevel"/>中的一个值。</param>
        /// <returns><see cref="SqlTransaction"/>对象实例。</returns>
        public SqlTransaction BeginSqlTransaction(IsolationLevel isolation)
        {
            return this.SqlConnection.BeginTransaction(isolation);
        }
        #endregion

        #region BeginTransaction
        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <param name="transactionName">事务名称。</param>
        /// <returns><see cref="SqlTransaction"/>对象实例。</returns>
        public virtual SqlTransaction BeginTransaction(string transactionName)
        {
            return this.SqlConnection.BeginTransaction(transactionName);
        }

        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <param name="transactionName">事务名称。</param>
        /// <param name="isolation"><see cref="IsolationLevel"/>中的一个值。</param>
        /// <returns><see cref="SqlTransaction"/>对象实例。</returns>
        public virtual SqlTransaction BeginTransaction(string transactionName, IsolationLevel isolation)
        {
            return this.SqlConnection.BeginTransaction(isolation, transactionName);
        }
        #endregion

        #region Commit
        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <param name="transaction"><see cref="SqlTransaction"/>对象实例。</param>
        public virtual void Commit(SqlTransaction transaction)
        {
            this.Commit(transaction);
        }
        #endregion

        #region Rollback
        /// <summary>
        /// 使数据库事务回滚。
        /// </summary>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        public virtual void Rollback(SqlTransaction transaction)
        {
            this.Rollback(transaction);
        }
        #endregion

        #region CreateSqlCommand
        /// <summary>
        /// 创建数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public virtual SqlCommand CreateSqlCommand(string cmdText, CommandType cmdType)
        {
            if (object.ReferenceEquals(this.SqlConnection, null)) this.InitializeConnection();
            return new SqlCommand(cmdText, this.SqlConnection) { CommandTimeout = this.CommandTimeoutSeconds, CommandType = cmdType };
        }

        /// <summary>
        /// 创建数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public virtual SqlCommand CreateSqlCommand(string cmdText)
        {
            return this.CreateSqlCommand(cmdText, CommandType.Text);
        }
        #endregion

        #region CreateCommand
        /// <summary>
        /// 创建数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public override DbCommand CreateCommand(string cmdText, CommandType cmdType)
        {
            return this.CreateSqlCommand(cmdText, cmdType);
        }

        /// <summary>
        /// 创建一个事务性数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <param name="transaction"><see cref="SqlTransaction"/>对象实例。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public virtual SqlCommand CreateCommand(string cmdText, CommandType cmdType, SqlTransaction transaction)
        {
            SqlCommand cmd = this.CreateSqlCommand(cmdText, cmdType);
            cmd.Transaction = transaction;
            return cmd;
        }

        /// <summary>
        /// 创建一个事务性数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="transaction"><see cref="SqlTransaction"/>对象实例。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public SqlCommand CreateCommand(string cmdText, SqlTransaction transaction)
        {
            return this.CreateCommand(cmdText, CommandType.Text, transaction);
        }
        #endregion

        #region CreateSqlStoredProcedure
        /// <summary>
        /// 创建一个存储过程命令。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public virtual SqlCommand CreateSqlStoredProcedure(string storedprocName)
        {
            return this.CreateSqlCommand(storedprocName, CommandType.StoredProcedure);
        }
        #endregion

        #region CreateStoredProcedure
        /// <summary>
        /// 创建一个事务性的存储过程命令。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <param name="transaction"><see cref="SqlTransaction"/>对象实例。</param>
        /// <returns><see cref="SqlCommand"/>对象实例。</returns>
        public virtual SqlCommand CreateStoredProcedure(string storedprocName, SqlTransaction transaction)
        {
            return this.CreateCommand(storedprocName, CommandType.StoredProcedure, transaction);
        }
        #endregion

        #region ExecuteFill
        /// <summary>
        /// 执行数据库查询命令，并填充数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        public virtual void ExecuteFill(SqlCommand selectCmd, DataSet dataSet)
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd))
            {
                try
                {
                    dataAdapter.Fill(dataSet);
                    this.RaiseCommandExecuteEvent(new DatabaseCommandExecuteEventArgs(dataSet, true) { ThrowOnError = true });
                }
                catch (Exception ex)
                {
                    DatabaseCommandExecuteEventArgs e = new DatabaseCommandExecuteEventArgs(ex, false) { ThrowOnError = true };
                    this.RaiseCommandExecuteEvent(e);
                    if (e.ThrowOnError) throw ex;
                }
            }
        }

        /// <summary>
        /// 执行数据库查询命令，并填充数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        public override void ExecuteFill(DbCommand selectCmd, DataSet dataSet)
        {
            this.ExecuteFill(selectCmd as SqlCommand, dataSet);
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 执行数据库查询命令，并返回数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <returns><see cref="DataSet"/>对象实例。</returns>
        public virtual DataSet ExecuteDataSet(SqlCommand selectCmd)
        {
            return this.ExecuteDataSet(selectCmd);
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行数据库查询命令，并返回<see cref="SqlDataReader"/>对象实例。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="behavior"><see cref="CommandBehavior"/>中的一个值。</param>
        /// <returns><see cref="SqlDataReader"/>对象实例。</returns>
        public virtual SqlDataReader ExecuteReader(SqlCommand selectCmd, CommandBehavior behavior = CommandBehavior.Default)
        {
            return this.ExecuteReader(selectCmd, behavior) as SqlDataReader;
        }
        #endregion

        #region ExecuteAnalysis
        /// <summary>
        /// 逐个分析<paramref name="dataReader"/>中的数据结果。
        /// </summary>
        /// <param name="dataReader"><see cref="SqlDataReader"/>对象实例。</param>
        /// <param name="method"><see cref="DataReaderAnalyzer"/>委托类型。</param>
        public virtual void ExecuteAnalysis(SqlDataReader dataReader, DataReaderAnalyzer method)
        {
            this.ExecuteAnalysis(dataReader, method);
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库命令，返回影响行数。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>映像行数。</returns>
        public virtual int ExecuteNonQuery(SqlCommand cmd)
        {
            return this.ExecuteNonQuery(cmd);
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行数据库命令，并返回标量。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>未知对象实例。</returns>
        public virtual object ExecuteScalar(SqlCommand cmd)
        {
            return this.ExecuteScalar(cmd);
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */