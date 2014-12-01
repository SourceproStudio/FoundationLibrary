#region README

/*
 * README
 * 
 * Current Thread User : GUOCOLAND\wangyucai
 * Machine Name : GLCHQWYCWINW7
 * Visual Studio : Microsoft Visual Studio 2010 Ultimate Edition
 * Create Time : 2014-12-01 10:16:29
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

using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements;

namespace SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO
{
    /// <summary>
    /// <para>
    /// 提供了替换字符串中安装路径环境变量的方法。
    /// </para>
    /// <para>
    /// Namespace : <see cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// </para>
    /// <para>
    /// Type : <see cref="InstallationPathReplacement"/>
    /// </para>
    /// <para>
    /// The minimum .Net Framework version requirements : 4.0
    /// </para>
    /// <para>
    /// <see cref="InstallationPathReplacement"/> is a static type !
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="InstallationPathReplacement"/> is a static type !
    /// </remarks>
    /// <seealso cref="SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO"/>
    /// <seealso cref="EnvironmentVariableRegexMatching"/>
    /// <seealso cref="EnvironmentVariables"/>
    public static class InstallationPathReplacement
    {
        #region ReplaceEnvironmentVariable
        /// <summary>
        /// 替换<paramref name="path"/>中的安装路径环境变量（即%FLIB_PATH%值）。
        /// </summary>
        /// <param name="path">需要替换的路径。</param>
        /// <returns>
        /// <para>替换后的路径字符串。</para>
        /// <para>如果环境变量不存在，则返回<paramref name="path"/>。</para>
        /// <para>如果<paramref name="path"/>不能匹配%FLIB_PATH%模式，则返回<paramref name="path"/>。</para>
        /// </returns>
        static public string ReplaceEnvironmentVariable(string path)
        {
            EnvironmentVariableRegexMatching matching = new EnvironmentVariableRegexMatching(EnvironmentVariables.InstallationPathEnvironmentVariableName);
            if (Regex<EnvironmentVariableRegexMatching>.IsMatch(matching, path)&& EnvironmentVariables.VerifyInstallationPathEnvironmentVarExists())
                return Regex<EnvironmentVariableRegexMatching>.Replace(matching, path, EnvironmentVariables.InstallationPath.TrimEnd('\\'));
            else return path;
        }
        #endregion
    }
}

/*
 * Copyright © 2014 Wang Yucai. All rights reserved.
 */