#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-05 14:22:55
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
using System.Diagnostics;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons
{
    /// <summary>
    /// <para>
    /// 用于标记重要的源代码通知信息。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="ImportantNoticeAttribute"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="ImportantNoticeAttribute"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons"/>
    /// <remarks>
    /// Can not inherit from <see cref="ImportantNoticeAttribute"/> !
    /// </remarks>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public sealed class ImportantNoticeAttribute : Attribute
    {
        private string _message;
        static private bool _traceListenerIsAdded = false;

        #region TraceListenerIsAdded
        /// <summary>
        /// 是否已经添加了默认监听器。
        /// </summary>
        static private bool TraceListenerIsAdded
        {
            get { return _traceListenerIsAdded; }
            set { _traceListenerIsAdded = value; }
        }
        #endregion

        #region Message
        /// <summary>
        /// 重要源代码通知信息。
        /// </summary>
        /// <value>设置或获取重要源代码通知信息。</value>
        public string Message
        {
            get { return _message; }
            private set { _message = value; }
        }
        #endregion

        #region ImportantNoticeAttribute Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="ImportantNoticeAttribute" />对象实例。
        /// </para>
        /// </summary>
        /// <param name="message">重要源代码通知信息。</param>
        public ImportantNoticeAttribute(string message)
        {
            if (!ImportantNoticeAttribute.TraceListenerIsAdded)
            {
                Trace.Listeners.Add(new DefaultTraceListener());
                ImportantNoticeAttribute.TraceListenerIsAdded = true;
            }
            Trace.Write(message);
            this.Message = message;
        }

        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */