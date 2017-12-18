using System;
using System.Linq;

public class Program
{
    public static string reverseNum(double a)
    {

        return new string(a.ToString().ToCharArray().Reverse().ToArray());

    }



    public static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        Console.WriteLine(reverseNum(n));
    }
}