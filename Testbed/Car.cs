using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Testbed
{
    public class Car
    {
        public Car()
        {
            Speed = new BehaviorSubject<int>(0);
        }

        public BehaviorSubject<int> Speed { get; set; }

        public IObservable<Unit> Accelerate()
        {
            return Observable.Return(Unit.Default).Do(_ => this.Speed.OnNext(this.Speed.Value + 10));
        }
    }
}
