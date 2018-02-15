using System;


class Program
{
    static void Main(string[] args)
    {
        var datemod = new DateModifier();
        var d1 = Console.ReadLine();
        var d2 = Console.ReadLine();
        datemod.PrintDifference(d1,d2);
    }
}

