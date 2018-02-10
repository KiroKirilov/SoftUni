using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var rows = int.Parse(dimensions[0]);
        var cols = int.Parse(dimensions[1]);

        var snake = Console.ReadLine();

        char[][] matrix = InitilizeMatrix(rows, cols, snake);

        var shotInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        matrix = TakeShot(shotInfo, matrix);
        matrix = RearrangeAfterShot(matrix);

        foreach (var row in matrix)
        {
            Console.WriteLine(String.Join("", row));
        }
    }

    public static char[][] RearrangeAfterShot(char[][] matrix)
    {
        for (int col = 0; col < matrix[0].Length; col++)
        {
            var list = new List<char>();

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (matrix[row][col] != ' ')
                {
                    list.Add(matrix[row][col]);
                }
            }

            for (int i = list.Count; i < matrix.Length; i++)
            {
                list.Add(' ');
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][col] = list[list.Count - row - 1];
            }
        }

        return matrix;
    }

    public static char[][] TakeShot(int[] shotInfo, char[][] matrix)
    {
        var targetRow = shotInfo[0];
        var targetCol = shotInfo[1];
        var radius = shotInfo[2];

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                double distance = Math.Sqrt(Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2));
                if (distance <= radius)
                {
                    matrix[row][col] = ' ';
                }
            }
        }

        return matrix;
    }

    public static char[][] InitilizeMatrix(int rows, int cols, string snake)
    {
        var matrix = new char[rows][];
        int indexOfSnake = 0;
        int numberOfRows = 0;
        for (int row = matrix.Length - 1; row >= 0; row--)
        {
            matrix[row] = new char[cols];
            if (numberOfRows % 2 == 0)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake[indexOfSnake % snake.Length];
                    indexOfSnake++;
                }
            }
            else
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = snake[indexOfSnake % snake.Length];
                    indexOfSnake++;
                }
            }
            numberOfRows++;
        }

        return matrix;
    }
}