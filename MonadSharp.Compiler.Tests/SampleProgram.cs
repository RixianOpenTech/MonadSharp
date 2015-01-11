using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using MsSystem;
using MS.Core;

namespace MonadSharp.Compiler
{
    public class SampleProgram
    {
        public IObservable<Unit> Main()
        {
            IObservable<bool> b = Observable.Return(true);
            IObservable<string> s = Observable.Return("Hi 1234 { } = . ; world");
            IObservable<int> x = Observable.Return(12345);
            IObservable<Unit> u = Observable.Return(Unit.Default);

            return _Console.WriteLine(b).ContinueWith(
                _Console.WriteLine(s).ContinueWith(
                    _Console.WriteLine(x).ContinueWith(
                        _Console.WriteLine(u.Select(unit => unit.ToString())).ContinueWith(
                            this.ThisProgram().ContinueWith(
                                this.ThatProgram())))));
        }

        IObservable<Unit> ThisProgram()
        {
            return Observable.Generate(0, x => x < 5, x => x + 1, x => Unit.Default).ObserveOn(NewThreadScheduler.Default)
                .SelectMany(_ => this.Print(Observable.Return(true))).LastAsync();
        }

        IObservable<Unit> ThatProgram()
        {
            return Observable.Generate(0, x => x < 5, x => x + 1, x => Unit.Default).ObserveOn(NewThreadScheduler.Default)
                .SelectMany(_ => this.Print(Observable.Return(false))).LastAsync();
        }

        IObservable<Unit> Print(IObservable<bool> thisProgram)
        {
            return thisProgram.SelectMany(b =>
                Observable.If(() => b,
                    _Console.WriteLine(Observable.Return("Hello from this program.")),
                    _Console.WriteLine(Observable.Return("Hello from that program."))));
        }

        private IObservable<Unit> SayHello()
        {
            IObservable<string> name = _Console.ReadLine();
            return _Console.Write(Observable.Return("Please Enter Your Name: ")).ContinueWith(
                _Console.WriteLine(Observable.Return("Hello ").Concat(name)));
        }
    }
}
