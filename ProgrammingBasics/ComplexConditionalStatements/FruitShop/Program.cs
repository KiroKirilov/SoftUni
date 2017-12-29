using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace fruit_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruit = Console.ReadLine().ToLower();
            var day = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            var price = -1.0;

            if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
            {
                if (fruit == "banana") price = 2.5;
                else if (fruit == "apple") price = 1.2;
                else if (fruit == "orange") price = 0.85;
                else if (fruit == "grapefruit") price = 1.45;
                else if (fruit == "kiwi") price = 2.7;
                else if (fruit == "pineapple") price = 5.5;
                else if (fruit == "grapes") price = 3.85;
                else Console.WriteLine("error");
                Console.WriteLine(Math.Round(price *= quantity, 2));
            }
            else if (day == "saturday" || day == "sunday")
            {
                if (fruit == "banana") price = 2.7;
                else if (fruit == "apple") price = 1.25;
                else if (fruit == "orange") price = 0.9;
                else if (fruit == "grapefruit") price = 1.6;
                else if (fruit == "kiwi") price = 3;
                else if (fruit == "pineapple") price = 5.6;
                else if (fruit == "grapes") price = 4.20;
                else Console.WriteLine("error");
                Console.WriteLine(Math.Round(price *= quantity, 2));
            }
            else Console.WriteLine("error");
        }
    }
}
