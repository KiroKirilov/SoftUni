using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = Double.Parse(Console.ReadLine());
            var w = Double.Parse(Console.ReadLine());

            Console.WriteLine("{0:f2}", h * w);
        }
    }
}
