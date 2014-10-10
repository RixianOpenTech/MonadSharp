using System;
using System.Numerics;
using System.Reactive.Linq;

namespace MS.System
{
    public class _BigInteger : _Object<BigInteger>
    {
        public _BigInteger(BigInteger value)
            : base(value)
        {
        }

        public _BigInteger(IObservable<BigInteger> source)
            : base(source)
        {
        }

        public static _BigInteger operator +(_BigInteger x, _BigInteger y)
        {
            return x.Zip(y, (left, right) => left + right).AsBigInteger();
        }

        public static _BigInteger operator -(_BigInteger x, _BigInteger y)
        {
            return x.Zip(y, (left, right) => left - right).AsBigInteger();
        }

        public static _BigInteger operator *(_BigInteger x, _BigInteger y)
        {
            return x.Zip(y, (left, right) => left * right).AsBigInteger();
        }

        public static _BigInteger operator /(_BigInteger x, _BigInteger y)
        {
            return x.Zip(y, (left, right) => left / right).AsBigInteger();
        }

        public static _BigInteger operator %(_BigInteger x, _BigInteger y)
        {
            return x.Zip(y, (left, right) => left % right).AsBigInteger();
        }

        public static implicit operator _BigInteger(BigInteger value)
        {
            return new _BigInteger(value);
        }

        public static implicit operator _BigInteger(double value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(decimal value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(float value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(byte value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(int value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(long value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(sbyte value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(short value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(uint value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(ulong value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _BigInteger(ushort value)
        {
            return new _BigInteger(new BigInteger(value));
        }

        public static implicit operator _String(_BigInteger value)
        {
            return new _String(value.Select(v => v.ToString()));
        }

        public static implicit operator _Object(_BigInteger value)
        {
            return _Object.Create(value.Select(v => (object)v));
        }
    }
}
