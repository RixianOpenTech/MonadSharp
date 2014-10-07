using System;
using System.Linq;
using System.Reactive.Linq;

namespace MS.System
{
    public class _String : _Object<string>
    {
        public _String(string value)
            : base(value)
        {
        }

        public _String(IObservable<string> source)
            : base(source)
        {
        }

        public static _String Empty
        {
            get { return string.Empty; }
        }

        public static implicit operator _String(string value)
        {
            return new _String(value);
        }

        public static implicit operator _Object(_String value)
        {
            return new _Object(value);
        }
    }
}
