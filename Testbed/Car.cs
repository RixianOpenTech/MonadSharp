using System;
using System.Reactive;
using System.Reactive.Linq;
using MsSystem;

namespace Testbed
{
    public class Car
    {
        public Car()
        {
            this.Speed = Observable.Return(default(int));
        }

        public IObservable<int> Speed { get; private set; }

        public IObservable<Unit> Accelerate()
        {
            return Observable.Create<Unit>(observer =>
                                           {
                                               this.Speed = this.Speed.Add(Observable.Return(10));
                                               return Observable.Return(Unit.Default).Subscribe(observer);
                                           });
        }

        public IObservable<string> ToObservableString()
        {
            return Observable.Create<string>(observer => this.Speed.Select(s => s.ToString())
                                                             .Subscribe(observer));
        }

        public IObservable<int> GetSpeed()
        {
            return Observable.Create<int>(observer => this.Speed.Subscribe(observer)); 
        }
    }
}
