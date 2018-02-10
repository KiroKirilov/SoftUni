using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Func<int[], int> getMin = nums => nums.Min();

            Console.WriteLine(getMin(numbers));
        }
    }
}
