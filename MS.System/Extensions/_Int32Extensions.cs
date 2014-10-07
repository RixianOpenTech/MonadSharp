using System;
using System.Globalization;
using System.Reactive.Linq;

namespace MS.System
{
    public static class _Int32Extensions
    {
        public static _Int32 AsInt32(this IObservable<int> source)
        {
            return source as _Int32 ?? new _Int32(source);
        }

        public static IObservable<Int32> Add(this IObservable<Int32> x, IObservable<Int32> y)
        {
            return x.AsInt32() % y.AsInt32();
            //return x.Zip(y, (left, right) => left + right);
        }
        
        public static IObservable<Int32> Subtract(this IObservable<Int32> x, IObservable<Int32> y)
        {
            return x.Zip(y, (left, right) => left - right);
        }
        
        public static IObservable<Int32> Multiply(this IObservable<Int32> x, IObservable<Int32> y)
        {
            return x.Zip(y, (left, right) => left * right);
        }
        
        public static IObservable<Int32> Divide(this IObservable<Int32> x, IObservable<Int32> y)
        {
            return x.Zip(y, (left, right) => left / right);
        }

        public static IObservable<Int32> Mod(this IObservable<Int32> x, IObservable<Int32> y)
        {
            return x.Zip(y, (left, right) => left % right);
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int32> source, IObservable<Int32> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int32> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int32> source, IObservable<Int32> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int32> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<string> ToString(this IObservable<Int32> source, IObservable<IFormatProvider> provider)
        {
            return source.Zip(provider, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int32> source, IObservable<string> format)
        {
            return source.Zip(format, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int32> source, IObservable<string> format, IObservable<IFormatProvider> provider)
        {
            return source.Zip(format, provider, (i, f, p) => i.ToString(f, p));
        }

        public static _Int32 Parse(IObservable<string> s)
        {
            return s.Select(int.Parse).AsInt32();
        }

        public static IObservable<Int32> Parse(IObservable<string> s, IObservable<NumberStyles> style)
        {
            return s.Zip(style, int.Parse);
        }

        public static IObservable<Int32> Parse(IObservable<string> s, IObservable<NumberStyles> style, IObservable<IFormatProvider> provider)
        {
            return s.Zip(style, provider, int.Parse);
        }
    }
}
