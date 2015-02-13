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
var _1 = ObservableExt.Range(Observable.Return(0), Observable.Return(10), x => {
var _3 = _Console.Write(Observable.Return("Your number is: "));
var _4 = _Console.WriteLine(x);
return ObservableEx.ForkJoin(_3, _4).ToVoid();
}
);
return ObservableEx.ForkJoin(_1).ToVoid();
}

    }
}