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

            var observables = new List<IObservable<Unit>>();
            observables.Add(Observable.Return(5).ToUnit());
            observables.Add(Observable.Return("Foo").ToUnit());
            observables.Add(Observable.Return(5.4).ToUnit());

            var jss = new JsonSerializerSettings();
            var dcr = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            dcr.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
            jss.ContractResolver = dcr;
            Debug.WriteLine(JsonConvert.SerializeObject(program, Formatting.Indented, jss));
            
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
