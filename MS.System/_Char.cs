using System;

namespace MS.System
{
    public class _Char : _Object<Char>
    {
        public _Char(Char value)
            : base(value)
        {
        }

        public _Char(IObservable<Char> source)
            : base(source)
        {
        }

        public static implicit operator _Char(Char value)
        {
            return new _Char(value);
        }
    }
}