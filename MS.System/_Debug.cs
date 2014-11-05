using System;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MS.Core;
using MsSystem.Extensions;

namespace MsSystem
{
    public static class _Debug
    {
        public static IObservable<Unit> WriteLine(IObservable<Object> value)
        {
            return value.Do(val => Debug.WriteLine(val)).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> value)
        {
            return value.Do(val => Debug.WriteLine(val)).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> format, IObservable<Object[]> arg)
        {
            return ObservableExt.ZipExecute(format, arg, (f, a) => Debug.WriteLine(f, a)).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> format, IObservable<string> category)
        {
            return ObservableExt.ZipExecute(format, category, (f, c) => Debug.Write(f,c)).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Object> value)
        {
            return value.Do(val => Debug.Write(val)).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> value)
        {
            return value.Do(val => Debug.Write(val)).ToVoid();
        }
    }
}
