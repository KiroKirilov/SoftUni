using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());

            double area = (l * 100 * w * 100) - (a * 100 * a * 100) - ((l * 100 * w * 100) / 10);

            Console.WriteLine(Math.Floor(Math.Floor(area) / (40 + 7000)));
        }
    }
}
