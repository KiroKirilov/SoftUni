using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int power = 1;
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(power);
                power *= 4;
            }
        }
    }
}