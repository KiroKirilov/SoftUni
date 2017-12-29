using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fruit_or_vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine();

            if (product == "banana" || product == "apple" || product == "kiwi" || product == "cherry" || product == "lemon" || product == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (product == "cucumber" || product == "tomato" || product == "carrot" || product == "pepper")
            {
                Console.WriteLine("vegetable");
            }
            else Console.WriteLine("unknown");
        }
    }
}
