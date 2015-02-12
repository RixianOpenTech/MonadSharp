using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MS.Core
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

        public static IObservable<Unit> Sequence(IEnumerable<IObservable<Unit>> observables)
        {
            return observables.Aggregate((left, right) => left.ContinueWith(right));
        }

        public static IObservable<TResult> ContinueWith<TSource, TResult>(this IObservable<TSource> source, IObservable<TResult> other)
        {
            return source.SelectMany(_ => other);
        }

        public static IObservable<Unit> ToUnit<T>(this IObservable<T> source)
        {
            return source.Ignore(Unit.Default);
        }

        public static IObservable<TOut> Cast<TIn, TOut>(this IObservable<TIn> source)
        {
            return source.Select(tin => tin is TOut ? (TOut)(object) tin : default(TOut));
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

        public static IObservable<TResult> ForAsync<TSource, TResult>(IObservable<TSource> source, Func<TSource, IObservable<TResult>> resultSelector)
        {
            return source.Select(resultSelector).Flatten();
        }

        public static IObservable<TResult> If<TResult>(
            this IObservable<bool> source,
            IObservable<TResult> ifBranch,
            IObservable<TResult> elseBranch)
        {
            return source.Select(value => Observable.If(() => value, ifBranch, elseBranch)).Flatten();
        }

        public static IObservable<TResult> Generate<TState, TResult>(
            this IObservable<TState> source,
            Func<TState, bool> condition,
            Func<TState, TState> iterate,
            Func<TState, TResult> resultSelector)
        {
            return source.Select(state => Observable.Generate<TState, TResult>(state, condition, iterate, resultSelector)).Flatten();
        }

        public static IObservable<IObservable<int>> Range(
            IObservable<int> start,
            IObservable<int> end)
        {
            return start.Zip(end, Observable.Range);
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
                                            var currentDisposable = new CompositeDisposable(published.Subscribe((IObserver<T>)observer),
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


        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   sources:
        //     Observable sources.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements in the source sequences.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     sources or action is null.
        public static IObservable<Unit> ZipExecute<TSource>(
            this IEnumerable<IObservable<TSource>> sources,
            Action<IList<TSource>> action)
        {
            return Observable.Zip(sources,
                                  (sourcesLambda) =>
                                  {
                                      action(sourcesLambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges an observable sequence and an enumerable sequence into one observable
        //     sequence by using the selector function.
        //
        // Parameters:
        //   first:
        //     First observable source.
        //
        //   second:
        //     Second enumerable source.
        //
        //   action:
        //     Function to invoke for each consecutive pair of elements from the first and
        //     second source.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first observable source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second enumerable source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of pairwise combining the elements
        //     of the first and second source using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     first or second or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2>(
            this IObservable<TSource1> first,
            IEnumerable<TSource2> second,
            Action<TSource1, TSource2> action)
        {
            return Observable.Zip(first,
                                  second,
                                  (firstLambda, secondLambda) =>
                                  {
                                      action(firstLambda, secondLambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges two observable sequences into one observable sequence by combining
        //     their elements in a pairwise fashion.
        //
        // Parameters:
        //   first:
        //     First observable source.
        //
        //   second:
        //     Second observable source.
        //
        //   action:
        //     Function to invoke for each consecutive pair of elements from the first and
        //     second source.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of pairwise combining the elements
        //     of the first and second source using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     first or second or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2>(
            this IObservable<TSource1> first,
            IObservable<TSource2> second,
            Action<TSource1, TSource2> action)
        {
            return Observable.Zip(first,
                                  second,

                                  (firstLambda,
                                      secondLambda) =>
                                  {
                                      action(firstLambda,
                                             secondLambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            Action<TSource1, TSource2, TSource3> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3, TSource4>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            Action<TSource1, TSource2, TSource3, TSource4> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or action is
        //     null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3, TSource4, TSource5>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or action
        //     is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or action is null.
        public static IObservable<Unit> ZipExecute<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   source12:
        //     Twelfth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   TSource12:
        //     The type of the elements in the twelfth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or source12 or action
        //     is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            IObservable<TSource12> source12,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,
                                  source12,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda,
                                      source12Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda,
                                             source12Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   source12:
        //     Twelfth observable source.
        //
        //   source13:
        //     Thirteenth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   TSource12:
        //     The type of the elements in the twelfth source sequence.
        //
        //   TSource13:
        //     The type of the elements in the thirteenth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or source12 or source13 or
        //     action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            IObservable<TSource12> source12,
            IObservable<TSource13> source13,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,
                                  source12,
                                  source13,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda,
                                      source12Lambda,
                                      source13Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda,
                                             source12Lambda,
                                             source13Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   source12:
        //     Twelfth observable source.
        //
        //   source13:
        //     Thirteenth observable source.
        //
        //   source14:
        //     Fourteenth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   TSource12:
        //     The type of the elements in the twelfth source sequence.
        //
        //   TSource13:
        //     The type of the elements in the thirteenth source sequence.
        //
        //   TSource14:
        //     The type of the elements in the fourteenth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or source12 or source13 or
        //     source14 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13,
             TSource14>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            IObservable<TSource12> source12,
            IObservable<TSource13> source13,
            IObservable<TSource14> source14,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,
                                  source12,
                                  source13,
                                  source14,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda,
                                      source12Lambda,
                                      source13Lambda,
                                      source14Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda,
                                             source12Lambda,
                                             source13Lambda,
                                             source14Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   source12:
        //     Twelfth observable source.
        //
        //   source13:
        //     Thirteenth observable source.
        //
        //   source14:
        //     Fourteenth observable source.
        //
        //   source15:
        //     Fifteenth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   TSource12:
        //     The type of the elements in the twelfth source sequence.
        //
        //   TSource13:
        //     The type of the elements in the thirteenth source sequence.
        //
        //   TSource14:
        //     The type of the elements in the fourteenth source sequence.
        //
        //   TSource15:
        //     The type of the elements in the fifteenth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or source12 or source13 or
        //     source14 or source15 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13,
             TSource14, TSource15>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            IObservable<TSource12> source12,
            IObservable<TSource13> source13,
            IObservable<TSource14> source14,
            IObservable<TSource15> source15,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,
                                  source12,
                                  source13,
                                  source14,
                                  source15,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda,
                                      source12Lambda,
                                      source13Lambda,
                                      source14Lambda,
                                      source15Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda,
                                             source12Lambda,
                                             source13Lambda,
                                             source14Lambda,
                                             source15Lambda);
                                      return Unit.Default;
                                  });
        }

        //
        // Summary:
        //     Merges the specified observable sequences into one observable sequence by
        //     using the selector function whenever all of the observable sequences have
        //     produced an element at a corresponding index.
        //
        // Parameters:
        //   source1:
        //     First observable source.
        //
        //   source2:
        //     Second observable source.
        //
        //   source3:
        //     Third observable source.
        //
        //   source4:
        //     Fourth observable source.
        //
        //   source5:
        //     Fifth observable source.
        //
        //   source6:
        //     Sixth observable source.
        //
        //   source7:
        //     Seventh observable source.
        //
        //   source8:
        //     Eighth observable source.
        //
        //   source9:
        //     Ninth observable source.
        //
        //   source10:
        //     Tenth observable source.
        //
        //   source11:
        //     Eleventh observable source.
        //
        //   source12:
        //     Twelfth observable source.
        //
        //   source13:
        //     Thirteenth observable source.
        //
        //   source14:
        //     Fourteenth observable source.
        //
        //   source15:
        //     Fifteenth observable source.
        //
        //   source16:
        //     Sixteenth observable source.
        //
        //   action:
        //     Function to invoke for each series of elements at corresponding indexes in
        //     the sources.
        //
        // Type parameters:
        //   TSource1:
        //     The type of the elements in the first source sequence.
        //
        //   TSource2:
        //     The type of the elements in the second source sequence.
        //
        //   TSource3:
        //     The type of the elements in the third source sequence.
        //
        //   TSource4:
        //     The type of the elements in the fourth source sequence.
        //
        //   TSource5:
        //     The type of the elements in the fifth source sequence.
        //
        //   TSource6:
        //     The type of the elements in the sixth source sequence.
        //
        //   TSource7:
        //     The type of the elements in the seventh source sequence.
        //
        //   TSource8:
        //     The type of the elements in the eighth source sequence.
        //
        //   TSource9:
        //     The type of the elements in the ninth source sequence.
        //
        //   TSource10:
        //     The type of the elements in the tenth source sequence.
        //
        //   TSource11:
        //     The type of the elements in the eleventh source sequence.
        //
        //   TSource12:
        //     The type of the elements in the twelfth source sequence.
        //
        //   TSource13:
        //     The type of the elements in the thirteenth source sequence.
        //
        //   TSource14:
        //     The type of the elements in the fourteenth source sequence.
        //
        //   TSource15:
        //     The type of the elements in the fifteenth source sequence.
        //
        //   TSource16:
        //     The type of the elements in the sixteenth source sequence.
        //
        //   Unit:
        //     The type of the elements in the result sequence, returned by the selector
        //     function.
        //
        // Returns:
        //     An observable sequence containing the result of combining elements of the
        //     sources using the specified result selector function.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source1 or source2 or source3 or source4 or source5 or source6 or source7
        //     or source8 or source9 or source10 or source11 or source12 or source13 or
        //     source14 or source15 or source16 or action is null.
        public static IObservable<Unit> ZipExecute
            <TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13,
             TSource14, TSource15, TSource16>(
            this IObservable<TSource1> source1,
            IObservable<TSource2> source2,
            IObservable<TSource3> source3,
            IObservable<TSource4> source4,
            IObservable<TSource5> source5,
            IObservable<TSource6> source6,
            IObservable<TSource7> source7,
            IObservable<TSource8> source8,
            IObservable<TSource9> source9,
            IObservable<TSource10> source10,
            IObservable<TSource11> source11,
            IObservable<TSource12> source12,
            IObservable<TSource13> source13,
            IObservable<TSource14> source14,
            IObservable<TSource15> source15,
            IObservable<TSource16> source16,
            Action<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16> action)
        {
            return Observable.Zip(source1,
                                  source2,
                                  source3,
                                  source4,
                                  source5,
                                  source6,
                                  source7,
                                  source8,
                                  source9,
                                  source10,
                                  source11,
                                  source12,
                                  source13,
                                  source14,
                                  source15,
                                  source16,

                                  (source1Lambda,
                                      source2Lambda,
                                      source3Lambda,
                                      source4Lambda,
                                      source5Lambda,
                                      source6Lambda,
                                      source7Lambda,
                                      source8Lambda,
                                      source9Lambda,
                                      source10Lambda,
                                      source11Lambda,
                                      source12Lambda,
                                      source13Lambda,
                                      source14Lambda,
                                      source15Lambda,
                                      source16Lambda) =>
                                  {
                                      action(source1Lambda,
                                             source2Lambda,
                                             source3Lambda,
                                             source4Lambda,
                                             source5Lambda,
                                             source6Lambda,
                                             source7Lambda,
                                             source8Lambda,
                                             source9Lambda,
                                             source10Lambda,
                                             source11Lambda,
                                             source12Lambda,
                                             source13Lambda,
                                             source14Lambda,
                                             source15Lambda,
                                             source16Lambda);
                                      return Unit.Default;
                                  });
        }
    }
}
