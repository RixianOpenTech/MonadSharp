using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
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
        public static IObservable<Unit> Work()
        {
            IObservable<int> x = Observable.Range(7, 10);
            IObservable<int> y = Observable.Range(13, 10);
            IObservable<int> ifBlock = x.Add(y);
            IObservable<int> elseBlock = y.Subtract(x);
            var result = x.If(xVal => xVal < 10, ifBlock, elseBlock);
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
    }
}
