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
            var programText = string.Format("{0}{1}{2}", msc.Properties.Settings.Default.ProgramShellStart, emitted, msc.Properties.Settings.Default.ProgramShellEnd);
            File.WriteAllText(@"C:\Develop\Rixian\MonadSharp\MsShellExe\ObservableExecutable.cs", programText);
            var msBuildPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0","MSBuildToolsPath",string.Empty);

            var startInfo = new ProcessStartInfo(
                string.Format("{0}msbuild.exe", msBuildPath),
                @"C:\Develop\Rixian\MonadSharp\MsShellExe\MsShellExe.csproj")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            var build = new Process()
            {
                StartInfo = startInfo
            };
            build.Start();
            while (!build.StandardOutput.EndOfStream)
            {
                Console.WriteLine(build.StandardOutput.ReadLine());
            }

            build.WaitForExit();
            Console.WriteLine("Done building!");
        }
    }
}
