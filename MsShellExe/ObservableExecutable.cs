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
    {
        public static IObservable<Unit> Main()
        {
            IObservable<bool> b = Observable.Return(true);
            var _0 = _Console.WriteLine(b);
            IObservable<string> s = Observable.Return("Hi 1234 { } = . ; world");
            var _1 = _Console.WriteLine(s);
            IObservable<int> x = Observable.Return(12345);
            var _2 = _Console.WriteLine(x);
            var _3 = _Console.Write(Observable.Return("Enter some text: "));
            IObservable<string> input = _Console.ReadLine();
            var _4 = _Console.WriteLine(input);
            var _5 = ObservableExt.Range(Observable.Return(0), Observable.Return(10), i =>
                                                                                      {
                                                                                          var _6 = _Console.WriteLine(Observable.Return(true));
                                                                                          return ObservableEx.ForkJoin(_6).ToVoid();
                                                                                      }
                );
            var _7 = ObservableExt.If(Observable.Return(true), () =>
                                                               {
                                                                   var _9 = _Console.WriteLine(Observable.Return("This is true..."));
                                                                   return ObservableEx.ForkJoin(_9).ToVoid();
                                                               }
                                      , () =>
                                        {
                                            var _8 = _Console.WriteLine(Observable.Return("This is false..."));
                                            return ObservableEx.ForkJoin(_8).ToVoid();
                                        }
                );
            IObservable<string> name = _Console.ReadLine();
            var _10 = _Console.Write(Observable.Return("Please Enter Your Name: ")).ContinueWith(
                _Console.Write(Observable.Return("Hello ")).ContinueWith(
                    _Console.WriteLine(name)));
            return ObservableEx.ForkJoin(_0, _1, _2, _3, _4, _5, _7, _10).ToVoid();
        }

    }
}