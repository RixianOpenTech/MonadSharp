using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MsSystem;

namespace Testbed
{
    public class Point
    {
        public Point()
        {
            X = Observable.Return(default(int));
            Y = Observable.Return(default(int));
        }

        public IObservable<int> X { get; set; }
        public IObservable<int> Y { get; set; }

        public IObservable<Unit> Translate(IObservable<int> x, IObservable<int> y)
        {
            X = X.Add(x);
            Y = Y.Add(y);
            return Observable.Return(Unit.Default);
        }
    }
}
