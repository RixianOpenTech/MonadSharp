unit Main()
{
    eval PrintStuff();
}

unit PrintStuff()
{
    eval PrintDashes();
    eval PrintStars();
}

unit PrintDashes()
{
    range(x = 0..10)
    {
        eval Console.WriteLine("-");
    }
}

unit PrintStars()
{
    range(x = 0..10)
    {
        eval Console.WriteLine("*");
    }
}