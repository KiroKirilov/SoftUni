using System;

public class Program
{

    public static double cube(double s, string r)
    {
        switch (r)
        {
            case "volume": return s * s * s;

            case "area": return 6 * s * s;

            case "face": return Math.Sqrt(2 * s * s);

            case "space": return Math.Sqrt(3 * s * s);

            default: return 0;
        }


    }


    public static void Main()
    {
        double side = double.Parse(Console.ReadLine());
        string request = Console.ReadLine();
        double result = cube(side, request);
        Console.WriteLine("{0:f2}", result);
    }
}