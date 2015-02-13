using MsSystem;
using MsSystem.Extensions;
using System;
using System.Reactive;
using System.Reactive.Linq;
using MS.Core;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {public static IObservable<Unit> Main()
{
var _1 = _Console.Write(Observable.Return("Please Enter Your Name: "));
IObservable<string> name = _Console.ReadLine();
var _2 = _Console.Write(Observable.Return("Hello "));
var _3 = _Console.WriteLine(name);
return ObservableEx.ForkJoin(_1, _2, _3).ToVoid();
}

    }
}