using System;
using System.Linq;

public class Program
{
    static bool prime(long n)
    {
        if (n == 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(n));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (n % i == 0) return false;
        }

        return true;
    }



    public static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(prime(n));
    }
}