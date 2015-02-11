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
IObservable<int> i = Observable.Return(42);
var _0 = _Console.Write(Observable.Return("The answer to life the universe and everything: "));
var _1 = _Console.WriteLine(i);
var _2 = _Console.WriteLine();
IObservable<string> s1 = Observable.Return("foo");
var _3 = _Console.WriteLine(s1);
IObservable<string> input = _Console.ReadLine();
var _4 = _Console.WriteLine(Observable.Return("You wrote:"));
var _5 = _Console.WriteLine(input);
return ObservableEx.ForkJoin(_0, _1, _2, _3, _4, _5).ToVoid();
}

    }
}