using System;

public class Program
{
    public static void Main()
    {

        var n = int.Parse(Console.ReadLine());

        for (var i = 1; i <= n; i++)

        {

            for (var j = 1; j <= i; j++) Console.Write(i + " ");
            Console.WriteLine();
        }

    }
}