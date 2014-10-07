using System;
using System.Reactive.Linq;

namespace MS.System
{
    public class _Int32 : _Object<int>
    {
        public _Int32(int value)
            : base(value)
        {
        }

        public _Int32(IObservable<int> source)
            : base(source)
        {
        }

        public static _Int32 operator +(_Int32 x, _Int32 y)
        {
            return x.Zip(y, (left, right) => left + right).AsInt32();
        }

        public static _Int32 operator -(_Int32 x, _Int32 y)
        {
            return x.Zip(y, (left, right) => left - right).AsInt32();
        }

        public static _Int32 operator *(_Int32 x, _Int32 y)
        {
            return x.Zip(y, (left, right) => left * right).AsInt32();
        }

        public static _Int32 operator /(_Int32 x, _Int32 y)
        {
            return x.Zip(y, (left, right) => left / right).AsInt32();
        }

        public static _Int32 operator %(_Int32 x, _Int32 y)
        {
            return x.Zip(y, (left, right) => left % right).AsInt32();
        }

        public static implicit operator _Int32(int value)
        {
            return new _Int32(value);
        }

        public static implicit operator _String(_Int32 value)
        {
            return new _String(value.Select(v => v.ToString()));
        }
    }
}
