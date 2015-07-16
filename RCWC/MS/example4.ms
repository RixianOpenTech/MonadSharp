unit Main()
{
    eval PrintStuff();
}

serial unit PrintStuff()
{
    eval PrintDashes();
    eval PrintStars();
}

unit PrintDashes()
{
    range(x = 0..10)
    {
        eval PrintSymbol(false);
    }
}

unit PrintStars()
{
    range(x = 0..10)
    {
        eval PrintSymbol(true);
    }
}

unit PrintSymbol(bool printStar)
{
    if (printStar)
    {
        eval Console.WriteLine("*");
    }
    else
    {
        eval Console.WriteLine("-");
    }
}