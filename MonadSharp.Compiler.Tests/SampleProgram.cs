using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;

namespace MonadSharp.Compiler
{
    public class SampleProgram
    {
        Unit Main()
        {
            bool b = true;
            Console.WriteLine(b);

            string s = "Hi 1234 { } = . ; world";
            Console.WriteLine(s);

            int x = 12345;
            Console.WriteLine(x);

            Unit u = Unit.Default;
            Console.WriteLine(u);

            ThisProgram();
            ThatProgram();

            return Unit.Default;
        }

        Unit ThisProgram()
        {
            int x = 0;
            while (x < 5)
            {
                Print(true);
                x = x + 1;
            }

            return Unit.Default;
        }

        Unit ThatProgram()
        {
            int x = 0;
            while (x < 5)
            {
                Print(false);
                x = x + 1;
            }

            return Unit.Default;
        }

        Unit Print(bool thisProgram)
        {
            if (thisProgram)
            {
                Console.WriteLine("Hello from this program.");
            }
            else
            {
                Console.WriteLine("Hello from that program.");
            }

            return Unit.Default;
        }

        Unit SayHello()
        {
            Console.Write("Please Enter Your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);

            return Unit.Default;
        }
    }
}
