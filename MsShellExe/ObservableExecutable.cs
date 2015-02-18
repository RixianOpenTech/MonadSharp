using MsSystem;
using MsSystem.Extensions;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using MS.Core;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {
        public static IObservable<Unit> Main()
        {
            var b = Observable.Return(true);
            var _0 = _Console.Write(Observable.Return("bool: "));
            var _1 = _Console.WriteLine(b);
            var s = Observable.Return("Hi 1234 { } = . ; world");
            var _2 = _Console.Write(Observable.Return("string: "));
            var _3 = _Console.WriteLine(s);
            var x = Observable.Return(12345);
            var _4 = _Console.Write(Observable.Return("int: "));
            var _5 = _Console.WriteLine(x);
            var u = _Console.Write(Observable.Return("unit: "));
            var _6 = _Console.WriteLine(u);
            var _7 = _Console.Write(Observable.Return("Enter some text: "));
            var input = _Console.ReadLine();
            var _8 = _Console.WriteLine(input);
            var _9 = RunThosePrograms();
            var _10 = SayHello();
            return ObservableEx.ForkJoin(_0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10).ToVoid();
        }


        public static IObservable<Unit> RunThosePrograms()
        {
            ThisProgram().Wait();
            ThatProgram().Wait();
            return Observable.Return(Unit.Default);
        }


        public static IObservable<Unit> ThisProgram()
        {
            var _0 = ObservableExt.Range(Observable.Return(0), Observable.Return(10), x =>
            {
                var _1 = Print(Observable.Return(true));
                return ObservableEx.ForkJoin(_1).ToVoid();
            }
            );
            return ObservableEx.ForkJoin(_0).ToVoid();
        }


        public static IObservable<Unit> ThatProgram()
        {
            var _0 = ObservableExt.Range(Observable.Return(0), Observable.Return(5), x =>
            {
                var _1 = Print(Observable.Return(false));
                return ObservableEx.ForkJoin(_1).ToVoid();
            }
            );
            return ObservableEx.ForkJoin(_0).ToVoid();
        }


        public static IObservable<Unit> Print(IObservable<bool> thisProgram)
        {
            var _0 = ObservableExt.If(thisProgram, () =>
            {
                var _2 = _Console.WriteLine(Observable.Return("Hello from this program."));
                return ObservableEx.ForkJoin(_2).ToVoid();
            }
            , () =>
            {
                var _1 = _Console.WriteLine(Observable.Return("Hello from that program."));
                return ObservableEx.ForkJoin(_1).ToVoid();
            }
            );
            return ObservableEx.ForkJoin(_0).ToVoid();
        }


        public static IObservable<Unit> SayHello()
        {
            _Console.Write(Observable.Return("Please Enter Your Name: ")).Wait();
            var name = _Console.ReadLine();
            name.Wait();
            _Console.Write(Observable.Return("Hello ")).Wait();
            _Console.WriteLine(name).Wait();
            return Observable.Return(Unit.Default);
        }


    }
}