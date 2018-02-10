using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Array.Reverse(nums);

            var divisor = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ",nums.Where(n=>n%divisor!=0)));
        }
    }
}
