using System;

namespace MS.System
{
    public class _DateTimeOffset : _Object<DateTimeOffset>
    {
        public _DateTimeOffset(DateTimeOffset value)
            : base(value)
        {
        }

        public _DateTimeOffset(IObservable<DateTimeOffset> source)
            : base(source)
        {
        }
    }
}
