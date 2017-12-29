using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var profession = Console.ReadLine().ToLower();

        switch (profession)
        {
            case "athlete":

                Console.WriteLine("Water");
                break;



            case "businessman":

                Console.WriteLine("Coffee");
                break;

            case "businesswoman":

                Console.WriteLine("Coffee");
                break;

            case "softuni student":

                Console.WriteLine("Beer");
                break;

            default:

                Console.WriteLine("Tea");
                break;
        }
    }
}