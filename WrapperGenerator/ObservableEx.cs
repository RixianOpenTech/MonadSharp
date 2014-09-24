using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MSharp.CoreBindings
{
    public static class ObservableExt
    {
        public static IObservable<T> Factory<T>(Func<T> valueFactory)
        {
            return Observable.Create<T>(observer => Observable.Return(valueFactory()).Subscribe(observer));
        }

        public static IObservable<TResult> LetMany<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector)
        {
            return source.SelectMany(value =>
            {
                var valueObservable = Observable.Return(value);
                return selector(valueObservable);
            });
        }
        public static IObservable<TResult> ContinueWith<TSource, TResult>(this IObservable<TSource> source, IObservable<TResult> other)
        {
            return source.SelectMany(_ => other);
        }

        public static IObservable<Unit> ToUnit<T>(this IObservable<T> source)
        {
            return source.Ignore(Unit.Default);
        }

        public static IObservable<T> Once<T>(this IObservable<T> source)
        {
            var subject = new AsyncSubject<T>();
            var gate = new object();
            var hasSubscription = false;
            return Observable.Create<T>(observer =>
                                        {
                                            lock (gate)
                                            {
                                                if (!hasSubscription)
                                                {
                                                    hasSubscription = true;
                                                    source.Subscribe(subject);
                                                }
                                            }
                                            return subject.Subscribe(observer);
                                        });
        }

        public static IObservable<T> Flatten<T>(this IObservable<IObservable<T>> source)
        {
            return source.SelectMany(o => o);
        }

        public static IObservable<TResult> Ignore<TSource, TResult>(this IObservable<TSource> source, TResult result)
        {
            return source.Select(_ => result);
        }

        public static IDisposable SubscribeShared<T>(this IObservable<T> source, params IObserver<T>[] observers)
        {
            var shared = source.Publish();

            var disposable = new CompositeDisposable();
            foreach (var observer in observers)
            {
                disposable.Add(shared.Subscribe(observer));
            }

            shared.Connect();
            return disposable;
        }
    }
}
