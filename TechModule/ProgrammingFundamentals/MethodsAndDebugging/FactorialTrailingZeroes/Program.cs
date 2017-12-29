using System;
using System.Numerics;
public class Program
{
    public static BigInteger factorial(int n)
    {
        BigInteger fact = 1;
        for (int i = 1; i <= n; i++)
        {

            fact *= i;


        }
        return fact;

    }


    public static int zeroes(BigInteger n)
    {
        string num = n.ToString();
        int amount = 0;


        for (int i = 1; i <= int.MaxValue; i++)
        {
            char last = num[num.Length - i];

            if (last == '0') amount++;
            else break;

        }
        return amount;



    }


    public static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int amountZeroes = zeroes(factorial(n1));
        Console.Write(amountZeroes);

    }
}