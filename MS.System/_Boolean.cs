using System;

namespace MS.System
{
    public class _Boolean : _Object<bool>
    {
        public _Boolean(bool value)
            : base(value)
        {
        }

        public _Boolean(IObservable<bool> source)
            : base(source)
        {
        }

        public static implicit operator _Boolean(bool value)
        {
            return new _Boolean(value);
        }
    }
}