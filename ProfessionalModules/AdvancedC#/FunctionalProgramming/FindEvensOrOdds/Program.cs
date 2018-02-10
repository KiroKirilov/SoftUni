using System;
using System.Linq;

namespace EvensOrOdds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numBounds = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var nums = Enumerable.Range(numBounds[0], numBounds[1] - numBounds[0] + 1);
            var numTypeFilter = GetNumType(Console.ReadLine());

            Console.WriteLine(String.Join(" ", nums.Where(numTypeFilter)));
        }

        private static Func<int, bool> GetNumType(string numType)
        {
            switch (numType)
            {
                case "odd":
                    return x => x % 2 != 0;

                case "even":
                    return x => x % 2 == 0;
                default:
                    return x => x == x;
            }
        }
    }
}
