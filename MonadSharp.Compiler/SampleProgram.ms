unit Main()
{
	bool b = true;
	eval Console.WriteLine(b);
		
	string s = "Hi 1234 { } = . ; world";
	eval Console.WriteLine(s);
		
	int x = 12345;
	eval Console.WriteLine(x);

	unit u = unit;
	eval Console.WriteLine(u);
	
	eval Console.Write("Enter some text: ");
	string input = Console.ReadLine();
	eval Console.WriteLine(input);

	serial
	{
		eval ThisProgram();
		eval ThatProgram();
	}
}

unit ThisProgram()
{
	for(x = 0..10)
	{
		Print(true);
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