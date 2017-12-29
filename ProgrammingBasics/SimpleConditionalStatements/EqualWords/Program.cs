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
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (String.Compare(a, b, true) == 0)
            {

                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");

        }
    }
}