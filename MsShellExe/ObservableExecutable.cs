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
var _0 = _Console.WriteLine(Observable.Return("poophead :)"));
var _1 = _Console.WriteLine(Observable.Return("This is a test..."));
return ObservableEx.ForkJoin(_0, _1).ToVoid();
}

    }
}