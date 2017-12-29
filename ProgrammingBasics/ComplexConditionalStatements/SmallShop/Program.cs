using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazinche
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            var town = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            if (town == "sofia")
            {
                if (product == "coffee") Console.WriteLine(0.5 * quantity);
                if (product == "peanuts") Console.WriteLine(1.6 * quantity);
                if (product == "sweets") Console.WriteLine(1.45 * quantity);
                if (product == "beer") Console.WriteLine(1.2 * quantity);
                if (product == "water") Console.WriteLine(0.8 * quantity);
            }

            if (town == "plovdiv")
            {
                if (product == "coffee") Console.WriteLine(0.4 * quantity);
                if (product == "peanuts") Console.WriteLine(1.5 * quantity);
                if (product == "sweets") Console.WriteLine(1.30 * quantity);
                if (product == "beer") Console.WriteLine(1.15 * quantity);
                if (product == "water") Console.WriteLine(0.7 * quantity);
            }

            if (town == "varna")
            {
                if (product == "coffee") Console.WriteLine(0.45 * quantity);
                if (product == "peanuts") Console.WriteLine(1.55 * quantity);
                if (product == "sweets") Console.WriteLine(1.35 * quantity);
                if (product == "beer") Console.WriteLine(1.1 * quantity);
                if (product == "water") Console.WriteLine(0.7 * quantity);
            }
        }
    }
}
