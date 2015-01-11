using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Compiler;

namespace SampleProgramRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = new SampleProgram();
            sample.Main().Wait();
        }
    }
}
