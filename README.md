# MonadSharp

MonadSharp is an experimental language based on the Reactive Extension (Rx). The basis for the language comes from the ideas outline in this paper: http://rixianopentech.github.io/MonadSharp/Documents/ComputationAtTheSpeedOfMonadsPaper.pdf

This is a language that is very dependent on generated wrappers from the Rx Wrapper project: https://github.com/RixianOpenTech/RxWrappers

# Example
The following is an example of the syntax of the language:
```csharp
unit Main()
{
    bool b = true;
    Console.Write("bool: ");
    Console.WriteLine(b);
        
    string s = "Hi 1234 { } = . ; world";
    Console.Write("string: ");
    Console.WriteLine(s);
        
    int x = 12345;
    Console.Write("int: ");
    Console.WriteLine(x);

    unit u = Console.Write("unit: ");
    Console.WriteLine(u);
    
    Console.Write("Enter some text: ");
    string input = Console.ReadLine();
    Console.WriteLine(input);

    RunThosePrograms();

    SayHello();
}

parallel unit RunThosePrograms()
{
    ThisProgram();
    ThatProgram();
}

unit ThisProgram()
{
    range(x = 0..10)
    {
        Print(true);
    }
}

unit ThatProgram()
{
    range(x = 0..5)
    {
        Print(false);
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
    Console.Write("Hello ");
    Console.WriteLine(name);
}
```

## Notes

One of the most important features of this language is the automatic parallelism. by marking a block of code with the `parallel` or `serial` keywords, the compiler will emit Rx code that will automatically run that block of code in either parallel or serial fashion. The concepts behind this come for the paper linked to above. 