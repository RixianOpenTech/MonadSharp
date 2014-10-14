using System;
using System.Reactive.Linq;
using MsSystem;

namespace Testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            //var x = Observable.Return(2);
            //var y = Observable.Return(5);
            //var z = x * y;
            //Console.WriteLine(z);
            //Console.ReadLine();

            //TestValues();
            Car car = new Car();
            car.Speed.Do(s => Console.WriteLine("Speed: {0}", s)).Subscribe();
            var r = from c1 in car.Accelerate()
                    from c2 in car.Accelerate()
                    from c3 in car.Accelerate()
                    from c4 in car.Accelerate()
                    from c5 in car.Accelerate()
                    from c6 in car.Accelerate()
                    select c6;
            r.Subscribe();

            _Console.WriteLine(Euler.Problem1()).Subscribe();
            var p2 = Euler.Problem2().Select(result => result.ToString());
            _Console.WriteLine(p2).Subscribe();
            var p3 = Euler.Problem3().Select(result => result.ToString());
            _Console.WriteLine(p3).Subscribe();

            Console.ReadLine();
        }
    }
}
