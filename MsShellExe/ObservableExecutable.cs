using MsSystem;
using MsSystem.Extensions;
using System;
using System.Reactive;
using System.Reactive.Linq;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {public static IObservable<Unit> Main()
{
IObservable<string> s = Observable.Return("Hi my name is Samuel :D");
IObservable<string> ss = Observable.Return("This test is Working!!!!!!!!!");
var _0 = _Console.WriteLine(s);
var _1 = _Console.WriteLine(ss);
return ObservableEx.ForkJoin(_0, _1).ToVoid();
}

    }
}