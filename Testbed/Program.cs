using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Markup;
using MS.Core;
using MsSystem;
using Newtonsoft.Json;

namespace Testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = Observable.Return(10);
            var y = Observable.Return(15);
            var point = new Point();
            var program = _Console.WriteLine(point.ToObservableString()).ContinueWith(
            point.Translate(x, y).ContinueWith(
            _Console.WriteLine(point.ToObservableString()).ContinueWith(
            point.Translate(x, y).ContinueWith(
            _Console.WriteLine(point.ToObservableString()).ContinueWith(
            point.Translate(x, y).ContinueWith(
            _Console.WriteLine(point.ToObservableString()).ContinueWith(
            point.Translate(x, y).ContinueWith(
            _Console.WriteLine(point.ToObservableString()).ContinueWith(
            point.Translate(x, y).ContinueWith(
            _Console.WriteLine(point.ToObservableString())))))))))));
            
            Debug.WriteLine(JsonConvert.SerializeObject(program, Formatting.Indented));
            
            program.Subscribe();

            //Point point = new Point();
            //Console.WriteLine(point.ToString());
            //point.Translate(10, 15);
            //Console.WriteLine(point.ToString());
            //point.Translate(10, 15);
            //Console.WriteLine(point.ToString());
            //point.Translate(10, 15);
            //Console.WriteLine(point.ToString());
            //point.Translate(10, 15);
            //Console.WriteLine(point.ToString());
            //point.Translate(10, 15);


            var car = new Car();
            car.Accelerate().ContinueWith(
            _Console.WriteLine(car.GetSpeed()).ContinueWith(
            car.Accelerate().ContinueWith(
            _Console.WriteLine(car.GetSpeed()))));
            //.Subscribe();

            //Sample.Work().Subscribe();
            
            Console.ReadLine();
        }
    }
}
