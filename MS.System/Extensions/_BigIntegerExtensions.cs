using System;
using System.Globalization;
using System.Numerics;
using System.Reactive.Linq;

namespace MS.System
{
    public static class _BigIntegerExtensions
    {
        public static _BigInteger AsBigInteger(this IObservable<BigInteger> source)
        {
            return source as _BigInteger ?? new _BigInteger(source);
        }

        public static IObservable<BigInteger> Add(this IObservable<BigInteger> x, IObservable<BigInteger> y)
        {
            return x.Zip(y, (left, right) => left + right);
        }
        
        public static IObservable<BigInteger> Subtract(this IObservable<BigInteger> x, IObservable<BigInteger> y)
        {
            return x.Zip(y, (left, right) => left - right);
        }
        
        public static IObservable<BigInteger> Multiply(this IObservable<BigInteger> x, IObservable<BigInteger> y)
        {
            return x.Zip(y, (left, right) => left * right);
        }
        
        public static IObservable<BigInteger> Divide(this IObservable<BigInteger> x, IObservable<BigInteger> y)
        {
            return x.Zip(y, (left, right) => left / right);
        }

        public static IObservable<BigInteger> Mod(this IObservable<BigInteger> x, IObservable<BigInteger> y)
        {
            return x.Zip(y, (left, right) => left % right);
        }

        public static IObservable<Int32> CompareTo(this IObservable<BigInteger> source, IObservable<BigInteger> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<Int32> CompareTo(this IObservable<BigInteger> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.CompareTo(right));
        }

        public static IObservable<bool> Equals(this IObservable<BigInteger> source, IObservable<BigInteger> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<bool> Equals(this IObservable<BigInteger> source, IObservable<Object> value)
        {
            return source.Zip(value, (left, right) => left.Equals(right));
        }

        public static IObservable<string> ToString(this IObservable<BigInteger> source, IObservable<IFormatProvider> provider)
        {
            return source.Zip(provider, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<BigInteger> source, IObservable<string> format)
        {
            return source.Zip(format, (left, right) => left.ToString(right));
        }

        public static IObservable<string> ToString(this IObservable<BigInteger> source, IObservable<string> format, IObservable<IFormatProvider> provider)
        {
            return source.Zip(format, provider, (i, f, p) => i.ToString(f, p));
        }

        public static _BigInteger Parse(IObservable<string> s)
        {
            return s.Select(BigInteger.Parse).AsBigInteger();
        }

        public static IObservable<BigInteger> Parse(IObservable<string> s, IObservable<NumberStyles> style)
        {
            return s.Zip(style, BigInteger.Parse);
        }

        public static IObservable<BigInteger> Parse(IObservable<string> s, IObservable<NumberStyles> style, IObservable<IFormatProvider> provider)
        {
            return s.Zip(style, provider, BigInteger.Parse);
        }
    }
}
