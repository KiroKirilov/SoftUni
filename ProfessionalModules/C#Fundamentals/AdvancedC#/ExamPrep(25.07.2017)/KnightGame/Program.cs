using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public class TheHeiganDance
{
    public static void Main()
    {
        var boardSize = int.Parse(Console.ReadLine());

        var board = new char[boardSize][];

        for (int row = 0; row < boardSize; row++)
        {
            board[row] = Console.ReadLine().ToCharArray();
        }

        int maxRow = 0;
        int maxCol = 0;
        int maxPositionsAttacked = 0;
        int removedKnights = 0;

        do
        {
            if (maxPositionsAttacked > 0)
            {
                board[maxRow][maxCol] = '0';
                removedKnights++;
                maxPositionsAttacked = 0;
            }

            int currentPositionsAttacked = 0;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        currentPositionsAttacked = GetAttackedPositions(row, col, board);

                        if (currentPositionsAttacked > maxPositionsAttacked)
                        {
                            maxPositionsAttacked = currentPositionsAttacked;
                            maxRow = row;
                            maxCol = col;
                        }

                    }
                }
            }
        }
        while (maxPositionsAttacked != 0);

        Console.WriteLine(removedKnights);
    }

    static int GetAttackedPositions(int row, int col, char[][] board)
    {
        var attackedPositions = 0;

        if (IsPositionAtacked(row - 2, col - 1, board)) attackedPositions++;
        if (IsPositionAtacked(row - 2, col + 1, board)) attackedPositions++;
        if (IsPositionAtacked(row - 1, col - 2, board)) attackedPositions++;
        if (IsPositionAtacked(row - 1, col + 2, board)) attackedPositions++;
        if (IsPositionAtacked(row + 1, col - 2, board)) attackedPositions++;
        if (IsPositionAtacked(row + 1, col + 2, board)) attackedPositions++;
        if (IsPositionAtacked(row + 2, col - 1, board)) attackedPositions++;
        if (IsPositionAtacked(row + 2, col + 1, board)) attackedPositions++;

        return attackedPositions;
    }

    static bool IsPositionAtacked(int row, int col, char[][] board)
    {
        return IsPositionInBoard(row, col, board[0].Length)
            && board[row][col] == 'K';
    }

    static bool IsPositionInBoard(int row, int col, int boardSize)
    {
        return row >= 0 && row < boardSize
            && col >= 0 && col < boardSize;
    }
}