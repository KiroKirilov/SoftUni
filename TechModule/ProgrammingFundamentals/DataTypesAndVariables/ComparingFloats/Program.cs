using System;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        const double eps = 0.000001;

        if (Math.Abs(a - b) < eps) Console.WriteLine("True");
        else Console.WriteLine("False");
    }
}