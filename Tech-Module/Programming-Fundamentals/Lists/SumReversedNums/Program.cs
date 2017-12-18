using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_reversed_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int result = 0;
                while (numbers[i] > 0)
                {
                    result = result * 10 + numbers[i] % 10;
                    numbers[i] /= 10;
                }
                sum += result;
            }
            Console.WriteLine(sum);
        }
    }
}