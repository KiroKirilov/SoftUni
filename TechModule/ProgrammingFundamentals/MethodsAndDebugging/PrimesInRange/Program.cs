using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
        long n1 = long.Parse(Console.ReadLine());
        long n2 = long.Parse(Console.ReadLine());
        List<long> primes = new List<long>();


        for (long i = n1; i <= n2; i++)
        {

            if (prime(i)) primes.Add(i);


        }
        string nums = "";
        foreach (object o in primes)
        {
            nums += o + ", ";
        }
        nums = nums.Remove(nums.Length - 2);
        Console.WriteLine(nums);
    }
}