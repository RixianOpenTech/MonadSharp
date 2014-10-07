using System;
using System.Reactive;

namespace MS.System
{
    public class _Void : _Object<Unit>
    {
        public static _Void Default = new _Void();
        public _Void()
            : this(Unit.Default)
        {    
        }

        public _Void(Unit value)
            : base(value)
        {
        }

        public _Void(IObservable<Unit> source)
            : base(source)
        {
        }
    }
}
