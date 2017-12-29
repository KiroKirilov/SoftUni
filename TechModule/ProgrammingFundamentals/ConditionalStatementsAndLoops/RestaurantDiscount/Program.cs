using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var groupSize = int.Parse(Console.ReadLine());
        var package = Console.ReadLine().ToLower();
        double price = 0;

        if (groupSize <= 50)
        {
            price += 2500;
            switch (package)
            {

                case "gold":

                    price += 750;
                    price -= price * 0.1;

                    Console.WriteLine("We can offer you the Small Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "normal":

                    price += 500;
                    price -= price * 0.05;

                    Console.WriteLine("We can offer you the Small Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "platinum":

                    price += 1000;
                    price -= price * 0.15;

                    Console.WriteLine("We can offer you the Small Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

            }

        }

        else if (groupSize <= 100)
        {

            price += 5000;
            switch (package)
            {

                case "gold":

                    price += 750;
                    price -= price * 0.1;

                    Console.WriteLine("We can offer you the Terrace");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "normal":

                    price += 500;
                    price -= price * 0.05;

                    Console.WriteLine("We can offer you the Terrace");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "platinum":

                    price += 1000;
                    price -= price * 0.15;

                    Console.WriteLine("We can offer you the Terrace");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

            }

        }
        else if (groupSize <= 120)
        {

            price += 7500;
            switch (package)
            {

                case "gold":

                    price += 750;
                    price -= price * 0.1;

                    Console.WriteLine("We can offer you the Great Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "normal":

                    price += 500;
                    price -= price * 0.05;

                    Console.WriteLine("We can offer you the Great Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

                case "platinum":

                    price += 1000;
                    price -= price * 0.15;

                    Console.WriteLine("We can offer you the Great Hall");
                    Console.WriteLine("The price per person is {0:f2}$", price / groupSize);

                    break;

            }

        }
        else Console.WriteLine("We do not have an appropriate hall.");
    }
}