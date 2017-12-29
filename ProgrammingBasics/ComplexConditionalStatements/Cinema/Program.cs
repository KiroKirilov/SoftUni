using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var projection = Console.ReadLine().ToLower();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            switch (projection)
            {
                case "premiere":
                    Console.WriteLine("{0:f2}", r * c * 12);
                    break;
                case "discount":
                    Console.WriteLine("{0:f2}", r * c * 5);
                    break;
                case "normal":
                    Console.WriteLine("{0:f2}", r * c * 7.5);
                    break;
                default:
                    break;
            }
        }
    }
}
