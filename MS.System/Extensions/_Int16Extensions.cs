using System;
using System.Globalization;
using System.Reactive.Linq;

namespace MsSystem.Extensions
{
    public static class _Int16Extensions
    {
        public static IObservable<Int32> Add(this IObservable<Int16> x, IObservable<Int16> y)
        {
            return x.Zip(y, (left, right) => left + right);
        }

        public static IObservable<Int32> Subtract(this IObservable<Int16> x, IObservable<Int16> y)
        {
            return x.Zip(y, (left, right) => left - right);
        }

        public static IObservable<Int32> Multiply(this IObservable<Int16> x, IObservable<Int16> y)
        {
            return x.Zip(y, (left, right) => left * right);
        }

        public static IObservable<Int32> Divide(this IObservable<Int16> x, IObservable<Int16> y)
        {
            return x.Zip(y, (left, right) => left / right);
        }

        public static IObservable<Int32> Mod(this IObservable<Int16> x, IObservable<Int16> y)
        {
            return x.Zip(y, (left, right) => left % right);
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int16> source, IObservable<Int16> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<Int32> CompareTo(this IObservable<Int16> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int16> source, IObservable<Int16> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<bool> Equals(this IObservable<Int16> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<string> ToString(this IObservable<Int16> source, IObservable<IFormatProvider> provider)
        {
            return source.Zip(provider, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int16> source, IObservable<string> format)
        {
            return source.Zip(format, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<Int16> source, IObservable<string> format, IObservable<IFormatProvider> provider)
        {
            return source.Zip(format, provider, (i, f, p) => i.ToString(f, p));
        }

        public static IObservable<short> Parse(IObservable<string> s)
        {
            return s.Select(Int16.Parse);
        }

        public static IObservable<Int16> Parse(IObservable<string> s, IObservable<NumberStyles> style)
        {
            return s.Zip(style, Int16.Parse);
        }

        public static IObservable<Int16> Parse(IObservable<string> s, IObservable<NumberStyles> style, IObservable<IFormatProvider> provider)
        {
            return s.Zip(style, provider, Int16.Parse);
        }
    }
}
