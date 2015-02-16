using MsSystem;
using MsSystem.Extensions;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using MS.Core;

#pragma warning disable 0028

namespace MsShellExe
{
    public static class ObservableExecutable
    {
        public static IObservable<Unit> Main()
        {
            var b = true;
            Console.WriteLine(b);
            var s = "Hi 1234 { } = . ; world";
            Console.WriteLine(s);
            var x = 12345;
            Console.WriteLine(x);
            Console.Write("Enter some text: ");
            var input = Console.ReadLine();
            Console.WriteLine(input);
            foreach (var i in Enumerable.Range(0, 10))
            {
                Console.WriteLine(true);
            }

            if (true)
            {
                Console.WriteLine("This is true...");
            }
            else
            {
                Console.WriteLine("This is false...");
            }

            Console.Write("Please Enter Your Name: ");
            var name = Console.ReadLine();
            Console.Write("Hello ");
            Console.WriteLine(name);
            return Observable.Return(Unit.Default);
        }

    }
}