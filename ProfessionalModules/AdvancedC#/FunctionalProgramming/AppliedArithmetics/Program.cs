using System;
using System.Collections.Generic;
using System.Linq;

namespace EvensOrOdds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);

            while (true)
            {
                var command = Console.ReadLine().ToLower().Trim();
                if (command == "end")
                    break;

                switch (command)
                {
                    case "add":
                        nums = ForEach(nums,n=>n+1);
                        break;

                    case "subtract":
                        nums = ForEach(nums, n => n - 1);
                        break;

                    case "multiply":
                        nums = ForEach(nums, n => n *2);
                        break;

                    case "print":
                        Console.WriteLine(String.Join(" ",nums));
                        break;
                    default:
                        break;
                }
            }
        }

        public static IEnumerable<int> ForEach(IEnumerable<int> collection, Func<int, int> func)
        {
            return collection.Select(n => func(n));
        }
    }
}
