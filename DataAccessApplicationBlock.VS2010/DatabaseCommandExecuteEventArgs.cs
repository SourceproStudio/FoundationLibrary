#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-11 11:45:57
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data
{
    /// <summary>
    /// <para>
    /// 数据库命令执行事件参数。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DatabaseCommandExecuteEventArgs"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data"/>
    /// <seealso cref="EventArgs"/>
    [Serializable]
    public class DatabaseCommandExecuteEventArgs : EventArgs
    {
        private bool _isSuccessful;
        private object _result;
        private bool _throwOnError;

        #region IsSuccessful
        /// <summary>
        /// 是否执行成功。
        /// </summary>
        /// <value>获取是否执行成功。</value>
        public virtual bool IsSuccessful
        {
            get { return _isSuccessful; }
            protected set { _isSuccessful = value; }
        }
        #endregion

        #region Result
        /// <summary>
        /// 执行结果。
        /// </summary>
        /// <value>
        /// <para>获取执行结果。</para>
        /// <para>如果执行失败则为<see cref="Exception"/>。</para>
        /// </value>
        public virtual object Result
        {
            get { return _result; }
            protected set { _result = value; }
        }
        #endregion

        #region ThrowOnError
        /// <summary>
        /// 是否需要抛出异常。
        /// </summary>
        /// <value>设置或获取当执行失败时，是否抛出异常。</value>
        public virtual bool ThrowOnError
        {
            get { return _throwOnError; }
            set { _throwOnError = value; }
        }
        #endregion

        #region DatabaseCommandExecuteEventArgs Constructors

        /// <summary>
        /// 用于初始化一个<see cref="DatabaseCommandExecuteEventArgs" />对象实例。
        /// </summary>
        /// <param name="result">数据库命令执行结果。</param>
        /// <param name="successful">数据库命令执行结果。</param>
        public DatabaseCommandExecuteEventArgs(object result, bool successful = true)
        {
            this.Result = result;
            this.IsSuccessful = successful;
            this.ThrowOnError = true;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */