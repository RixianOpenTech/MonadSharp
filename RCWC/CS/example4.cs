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
		        PrintSymbol(false);
		    }
		}
		
		static void PrintStars()
		{
		    for(int x = 0; x < 10; x++)
		    {
		        PrintSymbol(true);
		    }
		}
		
		static void PrintSymbol(bool printStar)
		{
		    if (printStar)
		    {
		        Console.WriteLine("*");
		    }
		    else
		    {
		        Console.WriteLine("-");
		    }
		}
	}
}