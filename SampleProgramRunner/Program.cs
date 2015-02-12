using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Compiler;
using System.Reactive;
using MsSystem;
using MS.Core;

namespace SampleProgramRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            var sample = new SampleProgram();
            //sample.Main().Wait();
            MainX().Wait();
        }
        static IObservable<Unit> MainX()
        {
            var _0 = _Console.WriteLine(Observable.Return("poop"));
            var _1 = _Console.WriteLine(Observable.Return("This is a test..."));
            return ObservableEx.ForkJoin(_0, _1).ToUnit();
        }
    }
}
