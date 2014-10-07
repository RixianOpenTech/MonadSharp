using System;
using System.Reactive.Linq;

namespace MS.System
{
    public class _Int16 : _Object<Int16>
    {
        public _Int16(short value)
            : base(value)
        {
        }

        public _Int16(IObservable<short> source)
            : base(source)
        {
        }

        public static _Int32 operator +(_Int16 x, _Int16 y)
        {
            return x.Zip(y, (left, right) => left + right).AsInt32();
        }

        public static _Int32 operator -(_Int16 x, _Int16 y)
        {
            return x.Zip(y, (left, right) => left - right).AsInt32();
        }

        public static _Int32 operator *(_Int16 x, _Int16 y)
        {
            return x.Zip(y, (left, right) => left * right).AsInt32();
        }

        public static _Int32 operator /(_Int16 x, _Int16 y)
        {
            return x.Zip(y, (left, right) => left / right).AsInt32();
        }

        public static _Int32 operator %(_Int16 x, _Int16 y)
        {
            return x.Zip(y, (left, right) => left % right).AsInt32();
        }

        public static implicit operator _Int16(short value)
        {
            return new _Int16(value);
        }

        public static implicit operator _String(_Int16 value)
        {
            return new _String(value.Select(v => v.ToString()));
        }
    }
}
