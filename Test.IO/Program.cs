using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.IO;

namespace SourcePro.Csharp.Units
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("基础库的安装路径：{0}", FoundationLibraryInstallationDirectoryInfo.InstallationDirectory.FullName);
        }
    }
}
