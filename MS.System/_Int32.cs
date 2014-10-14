//using System;
//using System.Reactive.Linq;

//namespace MsSystem
//{
//    public class IObservable<int> : IObservable<object><int>
//    {
//        public IObservable<int>(int value)
//            : base(value)
//        {
//        }

//        public IObservable<int>(IObservable<int> source)
//            : base(source)
//        {
//        }

//        public static IObservable<int> operator +(IObservable<int> x, IObservable<int> y)
//        {
//            return x.Zip(y, (left, right) => left + right);
//        }

//        public static IObservable<int> operator -(IObservable<int> x, IObservable<int> y)
//        {
//            return x.Zip(y, (left, right) => left - right);
//        }

//        public static IObservable<int> operator *(IObservable<int> x, IObservable<int> y)
//        {
//            return x.Zip(y, (left, right) => left * right);
//        }

//        public static IObservable<int> operator /(IObservable<int> x, IObservable<int> y)
//        {
//            return x.Zip(y, (left, right) => left / right);
//        }

//        public static IObservable<int> operator %(IObservable<int> x, IObservable<int> y)
//        {
//            return x.Zip(y, (left, right) => left % right);
//        }

//        public static implicit operator IObservable<int>(int value)
//        {
//            return new IObservable<int>(value);
//        }

//        public static implicit operator IObservable<string>(IObservable<int> value)
//        {
//            return new IObservable<string>(value.Select(v => v.ToString()));
//        }
//    }
//}
