#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-12 11:22:37
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

namespace SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient
{
    /// <summary>
    /// <para>
    /// 为<see cref="DbType"/>提供的扩展方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient"/>
    /// </para>
    /// <para>
    /// Type : <see cref="DbTypeExtensions"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="DbTypeExtensions"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="DbTypeExtensions"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Data.SqlClient"/>
    public static class DbTypeExtensions
    {
        #region ToSqlDbType
        /// <summary>
        /// 将指定的<see cref="DbType"/>值转换成对应的<see cref="SqlDbType"/>值。
        /// </summary>
        /// <param name="value"><see cref="DbType"/>中的一个值。</param>
        /// <returns><see cref="SqlDbType"/>中的一个值。</returns>
        /// <![CDATA[参考文献 : http://www.bmboo.com/?323.html]]>
        static public SqlDbType ToSqlDbType(this DbType value)
        {
            SqlDbType sqlValue = SqlDbType.Variant;
            switch (value)
            {
                case DbType.Boolean: sqlValue = SqlDbType.Bit; break;
                case DbType.Byte: sqlValue = SqlDbType.TinyInt; break;
                case DbType.Int16: sqlValue = SqlDbType.SmallInt; break;
                case DbType.Int32: sqlValue = SqlDbType.Int; break;
                case DbType.Int64: sqlValue = SqlDbType.BigInt; break;
                case DbType.Single: sqlValue = SqlDbType.Real; break;
                case DbType.Currency: sqlValue = SqlDbType.Money; break;
                case DbType.Decimal: sqlValue = SqlDbType.Decimal; break;
                case DbType.Double: sqlValue = SqlDbType.Float; break;
                case DbType.Guid: sqlValue = SqlDbType.UniqueIdentifier; break;
                case DbType.Binary: sqlValue = SqlDbType.Binary; break;
                case DbType.AnsiStringFixedLength: sqlValue = SqlDbType.Char; break;
                case DbType.AnsiString: sqlValue = SqlDbType.VarChar; break;
                case DbType.StringFixedLength: sqlValue = SqlDbType.NChar; break;
                case DbType.String: sqlValue = SqlDbType.NVarChar; break;
                case DbType.DateTime: sqlValue = SqlDbType.DateTime; break;
                case DbType.DateTime2: sqlValue = SqlDbType.DateTime2; break;
                case DbType.DateTimeOffset: sqlValue = SqlDbType.DateTimeOffset; break;
                case DbType.Date: sqlValue = SqlDbType.Date; break;
                case DbType.Time: sqlValue = SqlDbType.Time; break;
                case DbType.Xml: sqlValue = SqlDbType.Xml; break;
                default: sqlValue = SqlDbType.Variant; break;
            }
            return sqlValue;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */