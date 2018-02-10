using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class _07BalancedParentheses
{
    public static void Main()
    {
        var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        var r = dimensions[0];
        var c = dimensions[1];

        var matrix = new int[r][];

        for (int i = 0; i < r; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Take(c)
                .ToArray();
        }

        int[] biggest = new int[9];

        long currentSum = 0;
        long biggestSum = long.MinValue;

        for (int i = 0; i < r - 2; i++)
        {
            for (int j = 0; j < c - 2; j++)
            {
                var currentMatrElements = new int[] { matrix[i][j], matrix[i][j + 1], matrix[i][j + 2], matrix[i + 1][j], matrix[i + 1][j + 1], matrix[i + 1][j + 2], matrix[i + 2][j], matrix[i + 2][j + 1], matrix[i + 2][j + 2] };
                currentSum = currentMatrElements.Sum();
                if (currentSum > biggestSum)
                {
                    biggestSum = currentSum;
                    biggest = currentMatrElements;
                }
                currentSum = 0;
            }
        }

        Console.WriteLine("Sum = {0}", biggestSum);

        for (int i = 0; i < 9; i += 3)
        {
            Console.WriteLine("{0} {1} {2}", biggest[i], biggest[i + 1], biggest[i + 2]);
        }
    }
}
