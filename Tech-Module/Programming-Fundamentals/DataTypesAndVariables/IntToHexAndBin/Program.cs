using System;

public class Program
{
    public static void Main()
    {
        int dec = int.Parse(Console.ReadLine());
        string hex = Convert.ToString(dec, 16).ToUpper();
        string bin = Convert.ToString(dec, 2);

        Console.WriteLine(hex);
        Console.WriteLine(bin);
    }
}