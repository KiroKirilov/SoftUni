using System;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double diagonal = Math.Sqrt((a * a) + (b * b));

        Console.WriteLine(2 * (a + b));
        Console.WriteLine(a * b);
        Console.WriteLine(diagonal);
    }
}