unit Main()
{
    eval Console.WriteLine("About to print a message...");
    eval Print("Foo bar");
}

unit Print(string message)
{
   eval Console.Write("Your message: ");
   eval Console.WriteLine(message);
}