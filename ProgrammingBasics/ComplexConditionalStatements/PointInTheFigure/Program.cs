using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_in_figure
{
    class Program
    {
        static void Main(string[] args)
        {

            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if ((x >= 0 && x <= 3 * h && y <= h) || (x >= h && x <= h * 2 && y >= h && y <= h * 4))
            {
                if ((x > 0 && x < h * 3 && y > 0 && y < h) || (x > h && x < h * 2 && y > h && y < h * 4))
                    Console.WriteLine("inside");
                else
                {
                    if (x > h && x < h * 2 && y == h)
                        Console.WriteLine("inside");
                    else if (y < 0)
                        Console.WriteLine("outside");
                    else
                        Console.WriteLine("border");
                }
            }
            else Console.WriteLine("outside");
        }
    }
}
