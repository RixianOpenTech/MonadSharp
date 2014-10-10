using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.System;

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
            car.Accelerate();
            car.Accelerate();
            car.Accelerate();
            car.Accelerate();
            car.Accelerate();
            car.Accelerate();

            _Console.WriteLine(Euler.Problem1()).Subscribe();
            _Object p2 = Euler.Problem2();
            _Console.WriteLine(p2).Subscribe();

            Console.ReadLine();
        }

        private static void TestValues()
        {
            _String text = "foo";
            var write = text.Do(t => Console.WriteLine("Text: {0}", t)).AsString();
            var upper = text.ToUpper().Do(t => Console.WriteLine("Upper: {0}", t)).AsString();
            write.Subscribe();
            upper.Subscribe();
            string input;
            while ((input = Console.ReadLine()) != "q")
                text.SetValue(Observable.Return(input));
        }
    }
}
