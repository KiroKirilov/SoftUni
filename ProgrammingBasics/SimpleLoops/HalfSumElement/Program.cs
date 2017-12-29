using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace element_equal_to_others
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {

                int num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }
                sum += num;
            }

            sum -= max;
            if (sum == max)
            {
                Console.WriteLine($"Yes, sum = {sum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(max - sum)}");
            }
        }
    }
}