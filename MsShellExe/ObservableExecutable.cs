using MsSystem;
using MsSystem.Extensions;
using System;
using System.Reactive;
using System.Reactive.Linq;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {
        public static IObservable<Unit> Main()
        {
            IObservable<string> s1 = Observable.Return("foo");
            var _0 = _Console.WriteLine(s1);
            IObservable<string> input = _Console.ReadLine();
            IObservable<string> message = Observable.Return("You wrote:");
            var _1 = _Console.WriteLine(message);
            var _2 = _Console.WriteLine(input);
            return ObservableEx.ForkJoin(_0, _1, _2).ToVoid();
        }
    }
}