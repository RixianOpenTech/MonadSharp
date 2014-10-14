using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSystem.Extensions
{
    public static class VoidExtensions
    {
        public static IObservable<Unit> ToVoid<T>(this IObservable<T> observable)
        {
            return observable.Select(_ => Unit.Default);
        }
    }
}
