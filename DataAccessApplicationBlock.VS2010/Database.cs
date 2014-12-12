#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 14:42:50
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 提供了数据库访问的基本方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="Database"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="Database"/> is an abstract type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="Database"/> is an abstract type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    public abstract class Database : IDatabaseProvider, IDatabaseConnection, IDatabaseTransaction, IDatabaseCommand, IDatabaseParameter, IDisposable
    {
        private int _timeout;
        private string _defaultSchemaName;
        private string _connectionString;
        #region BaseConnection
        /// <summary>
        /// 基类中的数据库连接对象。
        /// </summary>
        protected DbConnection BaseConnection;
        #endregion

        #region Database Constructors

        /// <summary>
        /// 用于初始化一个<see cref="Database" />对象实例。
        /// </summary>
        /// <param name="connectionString">数据库连接串。</param>
        protected Database(string connectionString)
        {
            this._connectionString = connectionString;
            this._timeout = 0;
            this._defaultSchemaName = "dbo";
            this.InitializeConnection();
        }

        /// <summary>
        /// 用于初始化一个<see cref="Database" />对象实例。
        /// </summary>
        /// <param name="init">初始化对象。</param>
        protected Database(DatabaseInitializer init)
            : this(init.ConnectionString)
        {
            this._timeout = init.CommandTimeoutSeconds;
            this._defaultSchemaName = init.DefaultSchemaName;
        }

        #endregion

        #region CommandTimeoutSeconds
        /// <summary>
        /// 数据库命令执行超时(秒)。
        /// </summary>
        /// <value>设置或获取数据库命令执行超时(秒)。</value>
        public virtual int CommandTimeoutSeconds
        {
            get
            {
                return this._timeout;
            }
            set
            {
                this._timeout = value;
            }
        }
        #endregion

        #region SchemaName
        /// <summary>
        /// 默认的数据库架构名称。
        /// </summary>
        /// <value>设置或获取默认的数据库架构名称。</value>
        public virtual string SchemaName
        {
            get
            {
                return this._defaultSchemaName;
            }
            set
            {
                this._defaultSchemaName = value;
            }
        }
        #endregion

        #region Connection
        /// <summary>
        /// 数据库连接对象实例。
        /// </summary>
        /// <value>获取数据库连接对象实例。</value>
        public virtual DbConnection Connection
        {
            get { return this.BaseConnection; }
        }
        #endregion

        #region InitializeConnection
        /// <summary>
        /// 初始化数据库连接对象。
        /// </summary>
        protected abstract void InitializeConnection();
        #endregion

        #region ConnectionString
        /// <summary>
        /// 数据库连接串。
        /// </summary>
        /// <value>获取数据库连接串。</value>
        public virtual string ConnectionString
        {
            get { return this._connectionString; }
        }
        #endregion

        #region RaiseConnectionErrorEvent
        /// <summary>
        /// 用于引发数据库连接错误事件。
        /// </summary>
        /// <param name="methodName">方法名称。</param>
        /// <param name="error"><see cref="Exception"/>对象实例。</param>
        protected virtual void RaiseConnectionErrorEvent(string methodName, Exception error)
        {
            if (!object.ReferenceEquals(this.ConnectionError, null))
            {
                this.ConnectionError(this, new DatabaseConnectionErrorEventArgs(methodName, this.BaseConnection, error));
            }
        }
        #endregion

        #region Open
        /// <summary>
        /// 打开数据库连接。
        /// </summary>
        public virtual void Open()
        {
            try
            {
                if (!object.ReferenceEquals(this.BaseConnection, null))
                    this.InitializeConnection();
                this.BaseConnection.Open();
            }
            catch (Exception ex)
            {
                this.RaiseConnectionErrorEvent("Open", ex);
                throw ex;
            }
        }
        #endregion

        #region Close
        /// <summary>
        /// 关闭数据库连接。
        /// </summary>
        public virtual void Close()
        {
            try
            {
                if (!object.ReferenceEquals(this.BaseConnection, null)) this.BaseConnection.Close();
            }
            catch (Exception ex)
            {
                this.RaiseConnectionErrorEvent("Close", ex);
                throw ex;
            }
        }
        #endregion

        #region Event ConnectionError
        /// <summary>
        /// 数据库连接异常事件。
        /// </summary>
        public event DatabaseConnectionErrorEventHandler ConnectionError;
        #endregion

        #region ParameterNamePrefix
        /// <summary>
        /// 数据库参数前缀。
        /// </summary>
        /// <value>获取数据库参数前缀。</value>
        public virtual string ParameterNamePrefix
        {
            get { return "@"; }
        }
        #endregion

        #region BuildParameterName
        /// <summary>
        /// 构建数据库参数名称。
        /// </summary>
        /// <param name="paraName">参数名称。</param>
        /// <returns>参数名称。</returns>
        protected virtual string BuildParameterName(string paraName)
        {
            if (!paraName.StartsWith(this.ParameterNamePrefix))
                return string.Format("{0}{1}", this.ParameterNamePrefix, paraName);
            else return paraName;
        }
        #endregion

        #region CreateParameter
        /// <summary>
        /// 创建数据库参数。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="direction"><see cref="ParameterDirection"/>中的一个值。</param>
        /// <param name="dbType"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="DbParameter"/>对象实例。</returns>
        public abstract DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, DbType dbType = DbType.Object);
        #endregion

        #region AddParameters
        /// <summary>
        /// 添加参数到<paramref name="cmd"/>命令中。
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/>对象实例。</param>
        /// <param name="parameters"><see cref="DbParameter"/>[]数组。</param>
        public virtual void AddParameters(DbCommand cmd, params DbParameter[] parameters)
        {
            if (!object.ReferenceEquals(parameters, null) && parameters.Length > 0)
            {
                foreach (DbParameter item in parameters) cmd.Parameters.Add(item);
            }
        }
        #endregion

        #region BeginTransaction
        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <returns><see cref="DbTransaction"/>对象实例。</returns>
        public virtual DbTransaction BeginTransaction()
        {
            return this.BaseConnection.BeginTransaction();
        }

        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <param name="isolation"><see cref="IsolationLevel"/>中的一个值。</param>
        /// <returns><see cref="DbTransaction"/>对象实例。</returns>
        public virtual DbTransaction BeginTransaction(IsolationLevel isolation)
        {
            return this.BaseConnection.BeginTransaction(isolation);
        }
        #endregion

        #region Commit
        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        public virtual void Commit(DbTransaction transaction)
        {
            transaction.Commit();
        }
        #endregion

        #region Rollback
        /// <summary>
        /// 使数据库事务回滚。
        /// </summary>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        public virtual void Rollback(DbTransaction transaction)
        {
            transaction.Rollback();
        }
        #endregion

        #region CreateCommand
        /// <summary>
        /// 创建数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public abstract DbCommand CreateCommand(string cmdText, CommandType cmdType);

        /// <summary>
        /// 创建数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public virtual DbCommand CreateCommand(string cmdText)
        {
            return this.CreateCommand(cmdText, CommandType.Text);
        }

        /// <summary>
        /// 创建一个事务性数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="cmdType"><see cref="CommandType"/>中的一个值。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public virtual DbCommand CreateCommand(string cmdText, CommandType cmdType, DbTransaction transaction)
        {
            DbCommand cmd = this.CreateCommand(cmdText, cmdType);
            cmd.Transaction = transaction;
            return cmd;
        }

        /// <summary>
        /// 创建一个事务性数据库命令。
        /// </summary>
        /// <param name="cmdText">数据库命令。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public virtual DbCommand CreateCommand(string cmdText, DbTransaction transaction)
        {
            return this.CreateCommand(cmdText, CommandType.Text, transaction);
        }
        #endregion

        #region CreateStoredProcedure
        /// <summary>
        /// 创建一个存储过程命令。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public virtual DbCommand CreateStoredProcedure(string storedprocName)
        {
            return this.CreateCommand(storedprocName, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 创建一个事务性的存储过程命令。
        /// </summary>
        /// <param name="storedprocName">存储过程名称。</param>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        /// <returns><see cref="DbCommand"/>对象实例。</returns>
        public virtual DbCommand CreateStoredProcedure(string storedprocName, DbTransaction transaction)
        {
            return this.CreateCommand(storedprocName, CommandType.StoredProcedure, transaction);
        }
        #endregion

        #region RaiseCommandExecuteEvent
        /// <summary>
        /// 用于引发数据库命令执行事件。
        /// </summary>
        /// <param name="e"><see cref="DatabaseCommandExecuteEventArgs"/>对象实例。</param>
        protected virtual void RaiseCommandExecuteEvent(DatabaseCommandExecuteEventArgs e)
        {
            if (!object.ReferenceEquals(this.AfterExecuted, null)) this.AfterExecuted(this, e);
        }
        #endregion

        #region ExecuteFill
        /// <summary>
        /// 执行数据库查询命令，并填充数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        public abstract void ExecuteFill(DbCommand selectCmd, DataSet dataSet);

        /// <summary>
        /// 执行数据库查询命令，并填充数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="dataSet"><see cref="DataSet"/>对象实例。</param>
        public virtual void ExecuteFill(string selectCmd, DataSet dataSet)
        {
            this.ExecuteFill(this.CreateCommand(selectCmd), dataSet);
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 执行数据库查询命令，并返回数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <returns><see cref="DataSet"/>对象实例。</returns>
        public virtual DataSet ExecuteDataSet(DbCommand selectCmd)
        {
            DataSet dataSet = new DataSet("SourceProStudio.Practices.FoundationLibrary.Data.ResultSet");
            this.ExecuteFill(selectCmd, dataSet);
            return dataSet;
        }

        /// <summary>
        /// 执行数据库查询命令，并返回数据集。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <returns><see cref="DataSet"/>对象实例。</returns>
        public virtual DataSet ExecuteDataSet(string selectCmd)
        {
            return this.ExecuteDataSet(this.CreateCommand(selectCmd));
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行数据库查询命令，并返回<see cref="DbDataReader"/>对象实例。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="behavior"><see cref="CommandBehavior"/>中的一个值。</param>
        /// <returns><see cref="DbDataReader"/>对象实例。</returns>
        public virtual DbDataReader ExecuteReader(DbCommand selectCmd, CommandBehavior behavior = CommandBehavior.Default)
        {
            DbDataReader dataReader = null;
            try
            {
                dataReader = selectCmd.ExecuteReader(behavior);
                this.RaiseCommandExecuteEvent(new DatabaseCommandExecuteEventArgs(dataReader, true) { ThrowOnError = true });
            }
            catch (Exception ex)
            {
                DatabaseCommandExecuteEventArgs e = new DatabaseCommandExecuteEventArgs(ex, false) { ThrowOnError = true };
                this.RaiseCommandExecuteEvent(e);
                if (e.ThrowOnError) throw ex;
                dataReader = null;
            }
            return dataReader;
        }

        /// <summary>
        /// 执行数据库查询命令，并返回<see cref="DbDataReader"/>对象实例。
        /// </summary>
        /// <param name="selectCmd">数据库查询命令。</param>
        /// <param name="behavior"><see cref="CommandBehavior"/>中的一个值。</param>
        /// <returns><see cref="DbDataReader"/>对象实例。</returns>
        public virtual DbDataReader ExecuteReader(string selectCmd, CommandBehavior behavior = CommandBehavior.Default)
        {
            return this.ExecuteReader(this.CreateCommand(selectCmd), behavior);
        }
        #endregion

        #region ExecuteAnalysis
        /// <summary>
        /// 逐个分析<paramref name="dataReader"/>中的数据结果。
        /// </summary>
        /// <param name="dataReader"><see cref="DbDataReader"/>对象实例。</param>
        /// <param name="method"><see cref="DataReaderAnalyzer"/>委托类型。</param>
        public virtual void ExecuteAnalysis(DbDataReader dataReader, DataReaderAnalyzer method)
        {
            if (!object.ReferenceEquals(method, null))
            {
                int resultIndex = 0;
                do
                {
                    while (dataReader.Read())
                    {
                        method(resultIndex, dataReader);
                    }
                }
                while (dataReader.NextResult());
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库命令，返回影响行数。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>映像行数。</returns>
        public virtual int ExecuteNonQuery(DbCommand cmd)
        {
            int rowCount = -1;
            try
            {
                rowCount = cmd.ExecuteNonQuery();
                this.RaiseCommandExecuteEvent(new DatabaseCommandExecuteEventArgs(rowCount, true) { ThrowOnError = true });
            }
            catch (Exception ex)
            {
                DatabaseCommandExecuteEventArgs e = new DatabaseCommandExecuteEventArgs(ex, false) { ThrowOnError = true };
                this.RaiseCommandExecuteEvent(e);
                if (e.ThrowOnError) throw ex;
                rowCount = -1;
            }
            return rowCount;
        }

        /// <summary>
        /// 执行数据库命令，返回影响行数。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>映像行数。</returns>
        public virtual int ExecuteNonQuery(string cmd)
        {
            return this.ExecuteNonQuery(this.CreateCommand(cmd));
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行数据库命令，并返回标量。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>未知对象实例。</returns>
        public virtual object ExecuteScalar(DbCommand cmd)
        {
            object scalar = null;
            try
            {
                scalar = cmd.ExecuteScalar();
                this.RaiseCommandExecuteEvent(new DatabaseCommandExecuteEventArgs(scalar, true) { ThrowOnError = true });
            }
            catch (Exception ex)
            {
                DatabaseCommandExecuteEventArgs e = new DatabaseCommandExecuteEventArgs(ex, false) { ThrowOnError = true };
                this.RaiseCommandExecuteEvent(e);
                if (e.ThrowOnError) throw ex;
                scalar = null;
            }
            return scalar;
        }

        /// <summary>
        /// 执行数据库命令，并返回标量。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>未知对象实例。</returns>
        public virtual object ExecuteScalar(string cmd)
        {
            return this.ExecuteScalar(this.CreateCommand(cmd));
        }
        #endregion

        #region Event AfterExecuted
        /// <summary>
        /// 数据库命令执行事件。
        /// </summary>
        public event DatabaseCommandExecuteEventHandler AfterExecuted;
        #endregion

        #region Dispose
        /// <summary>
        /// 用于释放此对象。
        /// </summary>
        public virtual void Dispose()
        {
            try
            {
                if (!object.ReferenceEquals(this.BaseConnection, null))
                {
                    if (this.BaseConnection.State != ConnectionState.Closed)
                        this.Close();
                    this.BaseConnection.Dispose();
                }
            }
            catch { }
        }
        #endregion

        #region CreateOutputParameter
        /// <summary>
        /// 创建一个用于输出的<see cref="DbParameter"/>对象实例。
        /// </summary>
        /// <param name="name">数据库参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="dbType"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="DbParameter"/>对象实例。</returns>
        public virtual DbParameter CreateOutputParameter(string name, object value, DbType dbType = DbType.Object)
        {
            DbParameter parameter = this.CreateParameter(name, value, ParameterDirection.Output, dbType);
            return parameter;
        }

        /// <summary>
        /// 创建一个用于输出的<see cref="DbParameter"/>对象实例。
        /// </summary>
        /// <param name="name">数据库参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="size">参数长度。</param>
        /// <param name="dbType"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="DbParameter"/>对象实例。</returns>
        public virtual DbParameter CreateOutputParameter(string name, object value, int size, DbType dbType = DbType.Object)
        {
            DbParameter parameter = this.CreateOutputParameter(name, value, dbType);
            parameter.Size = size;
            return parameter;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */