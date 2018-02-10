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

        string[][] matrix = new string[r][];

        for (int i = 0; i < r; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Take(c)
                .ToArray();
        }

        int squares = 0;

        for (int i = 0; i < r - 1; i++)
        {
            for (int j = 0; j < c - 1; j++)
            {
                var allEqual = new[] { matrix[i][j], matrix[i + 1][j], matrix[i][j + 1], matrix[i + 1][j + 1] }.Distinct().Count() == 1;
                if (allEqual)
                {
                    squares++;
                }
            }
        }

        Console.WriteLine(squares);
    }
}
