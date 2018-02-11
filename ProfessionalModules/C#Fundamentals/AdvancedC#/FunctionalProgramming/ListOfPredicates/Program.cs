using System;
using System.Linq;
using System.Collections.Generic;

public class TheHeiganDance
{
    public static void Main()
    {
        var upperRangeBoundry = int.Parse(Console.ReadLine());

        var divisors = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Distinct();

        var numbers = new Queue<int>();

        var predicates = divisors
                .Select(div => (Func<int, bool>)(n => n % div == 0))
                .ToArray();

        for (int i = 1; i <= upperRangeBoundry; i++)
        {
            if (IsValid(predicates, i))
            {
                numbers.Enqueue(i);
            }
        }

        Console.WriteLine(String.Join(" ", numbers));
    }

    private static bool IsValid(Func<int, bool>[] predicates, int num)
    {
        foreach (var predicate in predicates)
        {
            if (!predicate(num))
            {
                return false;
            }
        }

        return true;
    }
}
