using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var profession = Console.ReadLine();
        var quantity = int.Parse(Console.ReadLine());

        switch (profession)
        {
            case "Athlete":

                Console.WriteLine("The Athlete has to pay {0:f2}.", quantity * 0.70);
                break;



            case "Businessman":

                Console.WriteLine("The Businessman has to pay {0:f2}.", quantity * 1);
                break;

            case "Businesswoman":

                Console.WriteLine("The Businesswoman has to pay {0:f2}.", quantity * 1);
                break;

            case "SoftUni Student":

                Console.WriteLine("The SoftUni Student has to pay {0:f2}.", quantity * 1.7);
                break;

            default:

                Console.WriteLine("The {0} has to pay {1:f2}.", profession, quantity * 1.2);
                break;
        }
    }
}