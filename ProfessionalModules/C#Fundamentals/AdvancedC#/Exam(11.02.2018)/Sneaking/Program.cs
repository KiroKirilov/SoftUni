using System;
using System.Linq;

namespace Problem2
{
    internal class Program
    {
        static bool samDead = false;
        static int deadRow = 0;
        static int deadCol = 0;
        static bool samWin = false;

        private static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                

                matrix = MoveEnemies(matrix, rows, cols);
                matrix = CheckLoss(matrix, rows, cols);
                if (samDead)
                    break;
                var currentCommand = commands[i];
                matrix = MoveSam(matrix, currentCommand, rows, cols);
                matrix = CheckWin(matrix, rows, cols);
                if (samWin)
                    break;
            }

            if (samWin)
            {
                Console.WriteLine("Nikoladze killed!");
                PrintMatrix(matrix, rows);
            }
            else
            {
                Console.WriteLine($"Sam died at {deadRow}, {deadCol}");
                PrintMatrix(matrix, rows);
            }
        }

        private static char[][] MoveSam(char[][] matrix, char currentCommand, int rows, int cols)
        {
            var samData = GetPos(matrix, rows, cols, 'S');
            var samRow = samData[0];
            var samCol = samData[1];
            switch (currentCommand)
            {
                case 'U':
                    matrix = MoveUp(matrix, samRow, samCol);
                    break;
                case 'D':
                    matrix = MoveDown(matrix, samRow, samCol);
                    break;
                case 'R':
                    matrix = MoveRight(matrix, samRow, samCol);
                    break;
                case 'L':
                    matrix = MoveLeft(matrix, samRow, samCol);
                    break;
                case 'W':
                    return matrix;
                default:
                    break;
            }
            return matrix;
        }

        private static char[][] MoveLeft(char[][] matrix, int samRow, int samCol)
        {
            matrix[samRow][samCol - 1] = 'S';
            matrix[samRow][samCol] = '.';
            return matrix;
        }

        private static char[][] MoveRight(char[][] matrix, int samRow, int samCol)
        {
            matrix[samRow][samCol + 1] = 'S';
            matrix[samRow][samCol] = '.';
            return matrix;
        }

        private static char[][] MoveDown(char[][] matrix, int samRow, int samCol)
        {
            matrix[samRow + 1][samCol] = 'S';
            matrix[samRow][samCol] = '.';
            return matrix;
        }

        private static char[][] MoveUp(char[][] matrix, int samRow, int samCol)
        {
            matrix[samRow - 1][samCol] = 'S';
            matrix[samRow][samCol] = '.';
            return matrix;
        }

        private static char[][] MoveEnemies(char[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (col == cols - 1)
                        {
                            matrix[row][col] = 'd';
                            col++;
                            continue;
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                            continue;
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            matrix[row][col] = 'b';
                            col++;
                            continue;
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                            col++;
                            continue;
                        }
                    }
                }
            }

            return matrix;
        }

        private static void PrintMatrix(char[][] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(String.Empty, matrix[row]));
            }
        }

        private static char[][] CheckWin(char[][] matrix, int rows, int cols)
        {
            int[] nikoData = GetPos(matrix, rows, cols, 'N');
            int[] samData = GetPos(matrix, rows, cols, 'S');
            var samRow = samData[0];
            var nikoRow = nikoData[0];
            var nikoCol = nikoData[1];

            if (samRow == nikoRow)
            {
                matrix[nikoRow][nikoCol] = 'X';
                samWin = true;
            }

            return matrix;
        }

        private static char[][] CheckLoss(char[][] matrix, int rows, int cols)
        {
            int[] samData = GetPos(matrix, rows, cols, 'S');
            var samRow = samData[0];
            var samCol = samData[1];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (samRow == row && samCol > col)
                        {
                            deadRow = samRow;
                            deadCol = samCol;
                            samDead = true;
                            matrix[samRow][samCol] = 'X';
                            return matrix;
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (samRow == row && samCol < col)
                        {
                            deadRow = samRow;
                            deadCol = samCol;
                            samDead = true;
                            matrix[samRow][samCol] = 'X';
                            return matrix;
                        }
                    }
                }
            }
            return matrix;
        }

        private static int[] GetPos(char[][] matrix, int rows, int cols, char lookingFor)
        {
            var data = new int[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == lookingFor)
                    {
                        data[0] = row;
                        data[1] = col;
                    }
                }
            }
            return data;
        }
    }
}