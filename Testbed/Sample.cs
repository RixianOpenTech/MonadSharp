using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using MS.Core;
using MsSystem;
using MsSystem.Extensions;

namespace Testbed
{
    public class Sample
    {
        //How do we define an observable that has a shared subscription?

        public static IObservable<Unit> Work()
        {
            IObservable<int> x = Observable.Range(1, 3);
            var y = Observable.Range(20, 10).SubscribeOnce();
            IObservable<int> ifBlock = y;//.Add(y);
            IObservable<int> elseBlock = x;//.Subtract(x);
            var result = x.If(xVal => xVal < 5, ifBlock, elseBlock);
            return _Console.WriteLine(result);
        }
    }

    public static class Ex
    {
        public static IObservable<TResult> If<TSource, TResult>(
            this IObservable<TSource> source,
            Func<TSource, bool> conditional,
            IObservable<TResult> ifBranch,
            IObservable<TResult> elseBranch)
        {
            return source.Select(value =>
                                 {
                                     var result = conditional(value);
                                     return Observable.If(() => result, ifBranch, elseBranch);
                                 }).Flatten();
        }

        public static IObservable<T> SubscribeOnce<T>(this IObservable<T> source)
        {
            var published = source.Publish();
            IDisposable publishedConnection = null;
            var gate = new object();
            var disposable = new RefCountDisposable(Disposable.Create(() =>
                                                                      {
                                                                          if (publishedConnection != null)
                                                                              publishedConnection.Dispose();
                                                                      }));
            return Observable.Create<T>(observer =>
                                        {
                                            var currentDisposable = new CompositeDisposable(published.Subscribe(observer),
                                                                                            disposable.GetDisposable());
                                            lock (gate)
                                            {
                                                if (publishedConnection == null)
                                                {
                                                    publishedConnection = published.Connect();
                                                }
                                            }

                                            return currentDisposable;
                                        });
        }
    }
}
