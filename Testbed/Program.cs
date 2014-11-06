using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Markup;
using MS.Core;
using MsSystem;

namespace Testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = Observable.Return(10);
            var y = Observable.Return(15);
            var point = new Point();
            _Console.WriteLine(point.ToObservableString()).ContinueWith(
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
            //.Subscribe();


            var car = new Car();
            car.Accelerate().ContinueWith(
            _Console.WriteLine(car.GetSpeed()).ContinueWith(
            car.Accelerate().ContinueWith(
            _Console.WriteLine(car.GetSpeed()))));
            //.Subscribe();

            Sample.Work().Subscribe();
            
            Console.ReadLine();
        }
    }
}
