#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 11:01:08
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

using System.Data;
using System.Data.Common;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 定义了处理事务性数据库命令的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="IDatabaseTransaction"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="DbTransaction"/>
    /// <seealso cref="IsolationLevel"/>
    public interface IDatabaseTransaction
    {
        #region BeginTransaction
        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <returns><see cref="DbTransaction"/>对象实例。</returns>
        DbTransaction BeginTransaction();

        /// <summary>
        /// 启动一个数据库事务。
        /// </summary>
        /// <param name="isolation"><see cref="IsolationLevel"/>中的一个值。</param>
        /// <returns><see cref="DbTransaction"/>对象实例。</returns>
        DbTransaction BeginTransaction(IsolationLevel isolation);
        #endregion

        #region Commit
        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        void Commit(DbTransaction transaction);
        #endregion

        #region Rollback
        /// <summary>
        /// 使数据库事务回滚。
        /// </summary>
        /// <param name="transaction"><see cref="DbTransaction"/>对象实例。</param>
        void Rollback(DbTransaction transaction);
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */