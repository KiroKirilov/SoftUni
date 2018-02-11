using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var stackNumbers = new Stack<int>();
        var max = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (query[0] == 1)
            {
                stackNumbers.Push(query[1]);
                if (query[1] > max)
                {
                    max = query[1];
                }
            }

            if (query[0] == 2)
            {
                var removed = stackNumbers.Pop();

                if (removed == max && stackNumbers.Count > 0)
                {
                    max = stackNumbers.Max();
                }
                else if (removed == max && stackNumbers.Count == 0)
                {
                    max = 0;
                }
            }

            if (query[0] == 3)
            {
                Console.WriteLine(max);
            }
        }
    }
}