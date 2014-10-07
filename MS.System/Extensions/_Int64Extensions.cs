using System;
using System.Globalization;
using System.Reactive.Linq;

namespace MS.System.Extensions
{
    public static class _Int64Extensions
    {
        public static _Int64 AsInt64(this IObservable<Int64> source)
        {
            return source as _Int64 ?? new _Int64(source);
        }

        public static IObservable<Int64> Add(this IObservable<Int64> x, IObservable<Int64> y)
        {
            return x.AsInt64() % y.AsInt64();
            //return x.Zip(y, (left, right) => left + right);
        }
        
        public static IObservable<Int64> Subtract(this IObservable<Int64> x, IObservable<Int64> y)
        {
            return x.Zip(y, (left, right) => left - right);
        }
        
        public static IObservable<Int64> Multiply(this IObservable<Int64> x, IObservable<Int64> y)
        {
            return x.Zip(y, (left, right) => left * right);
        }
        
        public static IObservable<Int64> Divide(this IObservable<Int64> x, IObservable<Int64> y)
        {
            return x.Zip(y, (left, right) => left / right);
        }

        public static IObservable<Int64> Mod(this IObservable<Int64> x, IObservable<Int64> y)
        {
            return x.Zip(y, (left, right) => left % right);
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int64> source, IObservable<Int64> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int64> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int64> source, IObservable<Int64> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int64> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<string> ToString(this IObservable<Int64> source, IObservable<IFormatProvider> provider)
        {
            return source.Zip(provider, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int64> source, IObservable<string> format)
        {
            return source.Zip(format, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int64> source, IObservable<string> format, IObservable<IFormatProvider> provider)
        {
            return source.Zip(format, provider, (i, f, p) => i.ToString(f, p));
        }

        public static _Int64 Parse(IObservable<string> s)
        {
            return s.Select(Int64.Parse).AsInt64();
        }

        public static IObservable<Int64> Parse(IObservable<string> s, IObservable<NumberStyles> style)
        {
            return s.Zip(style, Int64.Parse);
        }

        public static IObservable<Int64> Parse(IObservable<string> s, IObservable<NumberStyles> style, IObservable<IFormatProvider> provider)
        {
            return s.Zip(style, provider, Int64.Parse);
        }
    }
}
