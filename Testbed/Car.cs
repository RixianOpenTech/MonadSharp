using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.System;

namespace Testbed
{
    public class Car
    {
        public Car()
        {
            Speed = 0;
        }

        public _Int32 Speed { get; set; }

        public _Void Accelerate()
        {
            Speed.SetValue(Speed + 10);
            return _Void.Default;
        }
    }
}
