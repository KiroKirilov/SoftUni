using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_on_border
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool inside = x > x1 && x < x2 && y > y1 && y < y2 && y2 > y1 && x2 > x1;
            bool outside = (x < x1 || x > x2 || y < y1 || y > y2) && (x2 > x1 && y2 > y1);

            if (inside || outside)
            {
                Console.WriteLine("Inside / Outside");
            }
            else Console.WriteLine("Border");
        }
    }
}
