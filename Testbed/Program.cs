using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Markup;
using MS.Core;
using MsSystem;

namespace Testbed
{
    public class GenericType
    {
        public GenericType(Type type, object value)
        {
            this.Type = type;
            this.Value = value;
        }

        public Type Type { get; set; }
        public object Value { get; set; }
    }

    public class Context<T> : Dictionary<string, GenericType>
    {
        public T Value { get; set; }

        public Context(T value)
        {
            this.Value = value;
        }

        public Context(T value, params Tuple<string, GenericType>[] contextValues)
            : this(value)
        {
            foreach (var contextValue in contextValues)
            {
                this.Add(contextValue.Item1, contextValue.Item2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = Observable.Return(5);
            var ifBranch = Ex.ForAsync(Observable.Range(0, 10), i => _Console.WriteLine(Observable.Return(i)));
            var elseBranch = Ex.ForAsync(Observable.Range(15, 5), i => _Console.WriteLine(Observable.Return(i)));
            var ifStatement = x.If(xVal => xVal < 10, ifBranch, elseBranch);
            x = Observable.Return(10);
            ifStatement.Subscribe();
            ifStatement.Subscribe();

            //Sample.Work().Subscribe();
            //var x = Observable.Return(new Context<int>(2));
            //var y = Observable.Return(new Context<int>(5, new[] {Tuple.Create("x", new GenericType(x.GetType(), x))}));
            
            //var z = x * y;
            //Console.WriteLine(z);
            //Console.ReadLine();

            //TestValues();
            //Car car = new Car();
            //car.Speed.Do(s => Console.WriteLine("Speed: {0}", s)).Subscribe();
            //var r = from c1 in car.Accelerate()
            //        from c2 in car.Accelerate()
            //        from c3 in car.Accelerate()
            //        from c4 in car.Accelerate()
            //        from c5 in car.Accelerate()
            //        from c6 in car.Accelerate()
            //        select c6;
            //r.Subscribe();

            //_Console.WriteLine(Euler.Problem1()).Subscribe();
            //var p2 = Euler.Problem2().Select(result => result.ToString());
            //_Console.WriteLine(p2).Subscribe();
            //var p3 = Euler.Problem3().Select(result => result.ToString());
            //_Console.WriteLine(p3).Subscribe();
            
            Console.ReadLine();
        }
    }
}
