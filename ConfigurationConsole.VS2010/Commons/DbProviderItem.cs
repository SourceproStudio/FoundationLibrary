#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-18 9:55:16
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
using Ctrl = System.Windows.Forms.ListBox;
using SourcePro.Csharp.Practices.FoundationLibrary.Data;

namespace SourcePro.Csharp.Lab.Commons
{
    /// <summary>
    /// <para>
    /// 提供了添加到<see cref="Ctrl"/>控件的条目属性。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Lab.Commons"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DbProviderItem"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// Can not inherit from <see cref="DbProviderItem"/> !
    /// </para>
    /// </summary>
    /// <seealso cref="SourcePro.Csharp.Lab.Commons"/>
    /// <remarks>
    /// Can not inherit from <see cref="DbProviderItem"/> !
    /// </remarks>
    public sealed class DbProviderItem
    {
        private Type _sourceType;
        private string _dbProviderName;

        #region SourceType
        public Type SourceType
        {
            get { return _sourceType; }
            set { _sourceType = value; }
        }
        #endregion

        #region DbProviderItem Constructors

        /// <summary>
        /// <para>
        /// 用于初始化一个<see cref="DbProviderItem" />对象实例。
        /// </para>
        /// </summary>
        public DbProviderItem()
        { }

        #endregion

        #region ToString
        public override string ToString()
        {
            return this.SourceType.AssemblyQualifiedName;
        }
        #endregion

        #region GetProviderName
        public string GetProviderName()
        {
            Attribute attr = Attribute.GetCustomAttribute(this.SourceType, typeof(DatabaseDescriptionAttribute));
            if (object.ReferenceEquals(attr, null)) return this.SourceType.Name;
            else return (attr as DatabaseDescriptionAttribute).DatabaseName;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */