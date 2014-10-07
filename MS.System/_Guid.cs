using System;
using System.Reactive.Linq;

namespace MS.System
{
    public class _Guid : _Object<Guid>
    {
        public _Guid(Guid value)
            : base(value)
        {
        }

        public _Guid(IObservable<Guid> source)
            : base(source)
        {
        }
    }
}
