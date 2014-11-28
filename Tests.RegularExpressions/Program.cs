using System;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions;
using SourcePro.Csharp.Practices.FoundationLibrary.Commons.RegularExpressions.MatchingImplements;

namespace SourcePro.Csharp.Units
{
    class Program
    {
        static void Main(string[] args)
        {
            string systemDir = @"%win dir%\system32";
            EnvironmentVariableRegexMatching match = new EnvironmentVariableRegexMatching("win dir");
            Console.WriteLine(match.Pattern);
            string windowsDir = Environment.GetEnvironmentVariable("windir", EnvironmentVariableTarget.Machine);
            systemDir = Regex<EnvironmentVariableRegexMatching>.Replace(match, systemDir, windowsDir);
            Console.WriteLine(systemDir);
            Console.ReadLine();
        }
    }
}
