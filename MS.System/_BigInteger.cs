//using System;
//using System.Numerics;
//using System.Reactive.Linq;

//namespace MsSystem
//{
//    public class IObservable<BigInteger> : IObservable<object><BigInteger>
//    {
//        public IObservable<BigInteger>(BigInteger value)
//            : base(value)
//        {
//        }

//        public IObservable<BigInteger>(IObservable<BigInteger> source)
//            : base(source)
//        {
//        }

//        public static IObservable<BigInteger> operator +(IObservable<BigInteger> x, IObservable<BigInteger> y)
//        {
//            return x.Zip(y, (left, right) => left + right).AsBigInteger();
//        }

//        public static IObservable<BigInteger> operator -(IObservable<BigInteger> x, IObservable<BigInteger> y)
//        {
//            return x.Zip(y, (left, right) => left - right).AsBigInteger();
//        }

//        public static IObservable<BigInteger> operator *(IObservable<BigInteger> x, IObservable<BigInteger> y)
//        {
//            return x.Zip(y, (left, right) => left * right).AsBigInteger();
//        }

//        public static IObservable<BigInteger> operator /(IObservable<BigInteger> x, IObservable<BigInteger> y)
//        {
//            return x.Zip(y, (left, right) => left / right).AsBigInteger();
//        }

//        public static IObservable<BigInteger> operator %(IObservable<BigInteger> x, IObservable<BigInteger> y)
//        {
//            return x.Zip(y, (left, right) => left % right).AsBigInteger();
//        }

//        public static implicit operator IObservable<BigInteger>(BigInteger value)
//        {
//            return new IObservable<BigInteger>(value);
//        }

//        public static implicit operator IObservable<BigInteger>(double value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(decimal value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(float value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(byte value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(int value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(long value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(sbyte value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(short value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(uint value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(ulong value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<BigInteger>(ushort value)
//        {
//            return new IObservable<BigInteger>(new BigInteger(value));
//        }

//        public static implicit operator IObservable<string>(IObservable<BigInteger> value)
//        {
//            return new IObservable<string>(value.Select(v => v.ToString()));
//        }

//        public static implicit operator IObservable<object>(IObservable<BigInteger> value)
//        {
//            return IObservable<object>.Create(value.Select(v => (object)v));
//        }
//    }
//}
