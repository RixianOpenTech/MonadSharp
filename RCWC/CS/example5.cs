using System;

namespace TestProgram
{
	class Program
	{
		static void Main()
		{
		    SayHello();
		}
		
		static void SayHello()
		{
		    Console.Write("Please Enter Your Name: ");
		    string name = Console.ReadLine();
		    Console.Write("Hello ");
		    Console.WriteLine(name);
		}
	}
}