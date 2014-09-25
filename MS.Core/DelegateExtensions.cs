using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace MS.Core
{
    public static class DelegateExtensions
    {
        public static IObservable<Unit> ToObservable(Action function)
        {
            return Observable.Create<Unit>(observer =>
                                           {
                                               var observable = Task.Run(function).ToObservable();
                                               return observable.Subscribe(observer);
                                           });
        }

        public static IObservable<Unit> ToObservable(Func<Task> function)
        {
            return Observable.Create<Unit>(observer =>
                                           {
                                               var observable = Task.Run(function).ToObservable();
                                               return observable.Subscribe(observer);
                                           });
        }
    }
}