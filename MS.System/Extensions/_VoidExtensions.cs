using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.System.Extensions
{
    public static class _VoidExtensions
    {
        public static _Void ToVoid<T>(this IObservable<T> observable)
        {
            return new _Void(observable.Select(_ => Unit.Default));
        }
    }
}
