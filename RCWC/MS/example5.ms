unit Main()
{
    eval SayHello();
}

unit SayHello()
{
    eval Console.Write("Please Enter Your Name: ");
    string name = Console.ReadLine();
    eval Console.Write("Hello ");
    eval Console.WriteLine(name);
}