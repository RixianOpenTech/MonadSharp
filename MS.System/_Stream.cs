using System;
using System.IO;

namespace MS.System
{
    public class _Stream : _Object<Stream>
    {
        public _Stream(Stream value)
            : base(value)
        {
        }

        public _Stream(IObservable<Stream> source)
            : base(source)
        {
        }
    }
}
