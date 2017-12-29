using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            var miles = Double.Parse(Console.ReadLine());

            Console.WriteLine("{0:f2}", miles * 1.60934);
        }
    }
}
