using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                primaryDiagonal += matrix[i][i];
                secondaryDiagonal += matrix[i][n - i - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }
    }
}
