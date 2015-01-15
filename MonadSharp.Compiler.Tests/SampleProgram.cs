using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using MsSystem;
using MS.Core;
using System.Threading;

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

            
            var _1 = _Console.WriteLine(b);
            var _2 = _Console.WriteLine(s);
            var _3 = _Console.WriteLine(x);
            var _4 = _Console.WriteLine(u.Select(unit => unit.ToString()));

            //var _5 = Serial(ThisProgram().ObserveOn(ThreadPoolScheduler.Instance), ThatProgram().ObserveOn(ThreadPoolScheduler.Instance), ThisProgram().ObserveOn(ThreadPoolScheduler.Instance));
            //var _5 = this.ThisProgram().ContinueWith(
            //    this.ThatProgram());

            return ObservableEx.ForkJoin(_1, _2, _3, _4, ThisProgram(),ThatProgram()).ToUnit();
            //return _Console.WriteLine(b).ContinueWith(
            //    _Console.WriteLine(s).ContinueWith(
            //        _Console.WriteLine(x).ContinueWith(
            //            _Console.WriteLine(u.Select(unit => unit.ToString())).ContinueWith(
            //                this.ThisProgram().ContinueWith(
            //                    this.ThatProgram())))));
        }

        public static IObservable<Unit> Serial(params IObservable<Unit>[] observables)
        {
            var lastObservable = observables[observables.Length - 1];
            for (int i = observables.Length - 2; i >= 0; i--)
            {
                lastObservable = observables[i].ContinueWith(lastObservable);
            }
            return lastObservable;
        }

        IObservable<Unit> ThisProgram()
        {
            return Observable.Range(0, 10).Select(Observable.Return).SelectMany(x => this.Print(Observable.Return(true).Do(_ => Thread.Sleep(TimeSpan.FromSeconds(0.5))))).LastAsync();
        }

        IObservable<Unit> ThatProgram()
        {
            return Observable.Range(0, 10).Select(Observable.Return).SelectMany(x => this.Print(Observable.Return(false).Do(_ => Thread.Sleep(TimeSpan.FromSeconds(0.5))))).LastAsync();
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
