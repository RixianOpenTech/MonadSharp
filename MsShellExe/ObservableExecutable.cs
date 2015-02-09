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
IObservable<string> input = _Console.ReadLine();
var _0 = _Console.WriteLine(input);
return ObservableEx.ForkJoin(_0).ToVoid();
}

    }
}