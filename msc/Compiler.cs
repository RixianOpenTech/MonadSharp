using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using msc.Properties;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using MonadSharp.Compiler.Emitter;
using MonadSharp.Compiler.Lexer;
using MonadSharp.Compiler.Parser;
using System.Diagnostics;

namespace msc
{
    public static class Compiler
    {
        public static bool Compile(string msProgramFile, string outputFilename = null)
        {
            return CompileText(File.ReadAllText(msProgramFile), outputFilename);
        }

        public static bool CompileText(string msProgramText, string outputFilename = null)
        {
            CustomWorkspace w = new CustomWorkspace();
            var p = w.AddProject("MsBootstrapper", LanguageNames.CSharp);
            p = p.WithCompilationOptions(new CSharpCompilationOptions(OutputKind.ConsoleApplication));
            var projectFile = p.AddDocument("Program.cs", Settings.Default.MainProgramCode);
            p = projectFile.Project;

            var currentAssembly = typeof(Program).Assembly;
            var assemblyNames = currentAssembly.GetManifestResourceNames().Where(s => s.StartsWith("msc.ExternalAssemblies.System.Reactive") && s.EndsWith(".dll"));
            foreach (var assemblyName in assemblyNames)
            {
                var asmStream = currentAssembly.GetManifestResourceStream(assemblyName);
                p = p.AddMetadataReference(MetadataReference.CreateFromStream(asmStream));
            }

            p = p.AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(object).Assembly));
            p = p.AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(MsSystem._Console).Assembly));
            p = p.AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(Enumerable).Assembly));
            p = p.AddMetadataReference(MetadataReference.CreateFromAssembly(typeof(MS.Core.ObservableExt).Assembly));
            p = p.AddMetadataReference(MetadataReference.CreateFromAssembly(Assembly.Load(new AssemblyName("System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"))));

            var lexed = MonadSharpLexer.Lex(msProgramText);
            var parsed = MonadSharpParser.Parse(lexed);
            var emitted = MonadSharpEmitter.Emit(parsed);
            var programText = string.Format("{0}{1}{2}", Settings.Default.ProgramShellStart, emitted, Settings.Default.ProgramShellEnd);

            var programFile = p.AddDocument("ObservableExecutable.cs", programText);
            p = programFile.Project;
            var compiled = p.GetCompilationAsync().Result;
            var res = compiled.Emit(outputFilename ?? "shell.exe");

            if (!res.Success)
            {
                foreach (var diagnostic in res.Diagnostics)
                {
                    Debug.WriteLine(diagnostic.Location.GetMappedLineSpan().StartLinePosition.Line.ToString() + " " + diagnostic.GetMessage());
                }
            }

            return res.Success;
        }
    }
}
