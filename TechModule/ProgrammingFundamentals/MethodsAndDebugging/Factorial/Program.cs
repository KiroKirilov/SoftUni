using System;
using System.Numerics;
public class Program
{
    public static void factorial(int n)
    {
        BigInteger fact = 1;
        for (int i = 1; i <= n; i++)
        {

            fact *= i;


        }
        Console.WriteLine(fact);

    }

    public static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        factorial(n1);

    }
}