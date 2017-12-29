using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            var input = double.Parse(Console.ReadLine());

            if (input < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if ((input > 99) && (input <= 200))
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (input > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}