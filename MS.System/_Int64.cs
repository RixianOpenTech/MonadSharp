//using System;
//using System.Reactive.Linq;

//namespace MsSystem
//{
//    public class _Int64 : IObservable<object><Int64>
//    {
//        public _Int64(long value)
//            : base(value)
//        {
//        }

//        public _Int64(IObservable<long> source)
//            : base(source)
//        {
//        }

//        public static _Int64 operator +(_Int64 x, _Int64 y)
//        {
//            return new _Int64(x.Zip(y, (left, right) => left + right));
//        }

//        public static _Int64 operator -(_Int64 x, _Int64 y)
//        {
//            return new _Int64(x.Zip(y, (left, right) => left - right));
//        }

//        public static _Int64 operator *(_Int64 x, _Int64 y)
//        {
//            return new _Int64(x.Zip(y, (left, right) => left * right));
//        }

//        public static _Int64 operator /(_Int64 x, _Int64 y)
//        {
//            return new _Int64(x.Zip(y, (left, right) => left / right));
//        }

//        public static _Int64 operator %(_Int64 x, _Int64 y)
//        {
//            return new _Int64(x.Zip(y, (left, right) => left % right));
//        }

//        public static implicit operator _Int64(int value)
//        {
//            return new _Int64(value);
//        }

//        public static implicit operator IObservable<string>(_Int64 value)
//        {
//            return new IObservable<string>(value.Select(v => v.ToString()));
//        }
//    }
//}
