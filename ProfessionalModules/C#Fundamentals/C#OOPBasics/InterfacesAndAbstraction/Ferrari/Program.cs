using System;


class Program
{
    static void Main(string[] args)
    {
        var driverName = Console.ReadLine();
        var ferr = new Ferrari(driverName);

        Console.WriteLine(ferr);
    }
}

