using System;

namespace TestProgram
{
	class Program
	{
		static void Main()
		{
		    PrintStuff();
		}
		
		static void PrintStuff()
		{
		    PrintDashes();
		    PrintStars();
		}
		
		static void PrintDashes()
		{
		    for(int x = 0; x < 10; x++)
		    {
		        Console.WriteLine("-");
		    }
		}
		
		static void PrintStars()
		{
		    for(int x = 0; x < 10; x++)
		    {
		        Console.WriteLine("*");
		    }
		}
	}
}