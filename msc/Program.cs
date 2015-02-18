using Microsoft.Win32;
using MonadSharp.Compiler.Emitter;
using MonadSharp.Compiler.Lexer;
using MonadSharp.Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using msc.Properties;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace msc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool result = Compiler.Compile(args[0], args.Length == 2 ? args[1] : "shell.exe");
            if (result)
            {
                Console.WriteLine("Done building!");
            }
            else
            {
                Console.WriteLine("Build failed...");
            }
        }
    }
}
