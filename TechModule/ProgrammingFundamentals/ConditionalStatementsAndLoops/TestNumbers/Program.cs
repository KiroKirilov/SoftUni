using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int boundry = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    sum += 3 * (i * j);
                    count++;
                    if (sum >= boundry)
                    {
                        break;
                    }
                }
                if (sum >= boundry)
                {
                    break;
                }
            }
            if (sum >= boundry)
            {
                Console.WriteLine("{0} combinations", count);
                Console.WriteLine("Sum: {0} >= {1}", sum, boundry);
            }
            else
            {
                Console.WriteLine("{0} combinations", count);
                Console.WriteLine("Sum: {0}", sum);
            }
        }
    }
}