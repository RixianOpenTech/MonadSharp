using MsSystem;
using MsSystem.Extensions;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MS.Core;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {
        public static IObservable<Unit> Main()
        {
            IObservable<string> s1 = Observable.Return("foo");
            IObservable<int> i = Observable.Return(42);
            AsyncSubject<string> input = new AsyncSubject<string>();
            var _0 = _Console.Write(Observable.Return("The answer to life the universe and everything: "));
            var _1 = _Console.WriteLine(i).ContinueWith(
            _Console.WriteLine().ContinueWith(
            _Console.WriteLine(s1).ContinueWith(
            Observable.Create<Unit>(observer =>
            {
                var disposable = _Console.ReadLine().Subscribe(s =>
                {
                    input.OnNext(s);
                    input.OnCompleted();
                });
                observer.OnNext(Unit.Default);
                observer.OnCompleted();
                return disposable;
            }).ContinueWith(
            _Console.WriteLine(Observable.Return("You wrote:")).ContinueWith(
            _Console.WriteLine(input))))));
            return ObservableEx.ForkJoin(_0, _1).ToVoid();
        }
    }
}