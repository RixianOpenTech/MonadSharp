﻿unit Main()
{
	bool b = true;
	Console.WriteLine(b);
		
	string s = "Hi 1234 { } = . ; world";
	Console.WriteLine(s);
		
	int x = 12345;
	Console.WriteLine(x);

	unit u = unit;
	Console.WriteLine(u);
	
	Console.Write("Enter some text: ");
	string input = Console.ReadLine();
	Console.WriteLine(input);

	serial
	{
		ThisProgram();
		ThatProgram();
	}
}

unit ThisProgram()
{
	int x = 0;
	while (x < 5)
	{
		Print(true);
		x = x + 1;
	}
}

unit ThatProgram()
{
	int x = 0;
	while (x < 5)
	{
		Print(false);
		x = x + 1;
	}
}

unit Print(bool thisProgram)
{
	if (thisProgram)
	{
		Console.WriteLine("Hello from this program.");
	}
	else
	{
		Console.WriteLine("Hello from that program.");
	}
}

serial unit SayHello()
{
	Console.Write("Please Enter Your Name: ");
	string name = Console.ReadLine();
	Console.WriteLine("Hello " + name);
}