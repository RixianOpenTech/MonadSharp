serial unit Main()
{
	bool b = true;
	eval Console.WriteLine(b);
		
	string s = "Hi 1234 { } = . ; world";
	eval Console.WriteLine(s);
		
	int x = 12345;
	eval Console.WriteLine(x);

	eval Console.Write("Enter some text: ");
	string input = Console.ReadLine();
	eval Console.WriteLine(input);

	eval ThisProgram();
	eval ThatProgram();

	eval SayHello();
}

unit ThisProgram()
{
	range(x = 0..10)
	{
		eval Print(true);
	}
}

unit ThatProgram()
{
	range(x = 0..5)
	{
		eval Print(false);
	}
}

unit Print(bool thisProgram)
{
	if (thisProgram)
	{
		eval Console.WriteLine("Hello from this program.");
	}
	else
	{
		eval Console.WriteLine("Hello from that program.");
	}
}

serial unit SayHello()
{
	eval Console.Write("Please Enter Your Name: ");
	string name = Console.ReadLine();
	eval Console.Write("Hello ");
	eval Console.WriteLine(name);
}