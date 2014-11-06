using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Core;
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
            return Observable.Create<Unit>(observer =>
                                           {
                                               X = X.Add(x);
                                               Y = Y.Add(y);
                                               return Observable.Return(Unit.Default).Subscribe(observer);
                                           });
        }

        public IObservable<string> ToObservableString()
        {
            return Observable.Create<string>(observer =>
                                             {
                                                 var xType = X.Select(xVal => xVal%2 == 0)
                                                              .If(Observable.Return(" Even"),
                                                                  Observable.Return(" Odd"));
                                                 var yType = Y.Select(yVal => yVal%2 == 0)
                                                              .If(Observable.Return(" Even"),
                                                                  Observable.Return(" Odd"));
                                                 return Observable.Zip(X, Y, xType, yType,
                                                                       (x, y, xT, yT) => string.Format("{0}{1}\n{2}{3}", x, xT, y, yT))
                                                                  .Subscribe(observer);
                                             });
        }
    }
}
