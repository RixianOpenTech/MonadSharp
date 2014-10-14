//using System;
//using System.Reactive.Linq;

//namespace MsSystem
//{
//    public class _Int16 : IObservable<object><Int16>
//    {
//        public _Int16(short value)
//            : base(value)
//        {
//        }

//        public _Int16(IObservable<short> source)
//            : base(source)
//        {
//        }

//        public static IObservable<int> operator +(_Int16 x, _Int16 y)
//        {
//            return x.Zip(y, (left, right) => left + right);
//        }

//        public static IObservable<int> operator -(_Int16 x, _Int16 y)
//        {
//            return x.Zip(y, (left, right) => left - right);
//        }

//        public static IObservable<int> operator *(_Int16 x, _Int16 y)
//        {
//            return x.Zip(y, (left, right) => left * right);
//        }

//        public static IObservable<int> operator /(_Int16 x, _Int16 y)
//        {
//            return x.Zip(y, (left, right) => left / right);
//        }

//        public static IObservable<int> operator %(_Int16 x, _Int16 y)
//        {
//            return x.Zip(y, (left, right) => left % right);
//        }

//        public static implicit operator _Int16(short value)
//        {
//            return new _Int16(value);
//        }

//        public static implicit operator IObservable<string>(_Int16 value)
//        {
//            return new IObservable<string>(value.Select(v => v.ToString()));
//        }
//    }
//}
