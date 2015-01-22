using Microsoft.Win32;
using MonadSharp.Compiler.Emitter;
using MonadSharp.Compiler.Lexer;
using MonadSharp.Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msc
{
    class Program
    {
        static void Main(string[] args)
        {
            var msProgramFile = args[0];
            var msProgram = File.ReadAllText(msProgramFile);
            var lexed = MonadSharpLexer.Lex(msProgram);
            var parsed = MonadSharpParser.Parse(lexed);
            var emitted = MonadSharpEmitter.Emit(parsed);
            var msBuildPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0","MSBuildToolsPath",string.Empty);
            var build = Process.Start(string.Format("{0}msbuild.exe {2}",msBuildPath, @"C:\Develop\Git\MonadSharp\MsShellExe\MsShellExe.csproj"));
            build.WaitForExit();
            Console.WriteLine("Done building!");
        }
    }
}
