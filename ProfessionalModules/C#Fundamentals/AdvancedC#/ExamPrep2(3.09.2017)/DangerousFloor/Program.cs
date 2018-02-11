using System;
using System.Linq;

public class Program
{
    static char[][] board;

    public static void Main()
    {
        board = new char[8][];

        for (int row = 0; row < 8; row++)
        {
            board[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var figureType = command[0];
            var startRow = int.Parse(command[1].ToString());
            var startCol = int.Parse(command[2].ToString());
            var targetRow = int.Parse(command[4].ToString());
            var targetCol = int.Parse(command[5].ToString());

            bool figureExist = DoesFigureExist(figureType, startRow, startCol);
            bool validMove = IsMoveValid(figureType, startRow, startCol, targetRow, targetCol);
            bool inBoard = IsPieceInBoard(targetRow, targetCol);

            if (!figureExist)
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!validMove)
            {
                Console.WriteLine("Invalid move!");
                continue;
            }

            if (!inBoard)
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }

            board[startRow][startCol] = 'x';
            board[targetRow][targetCol] = figureType;
        }
    }

    static bool IsPieceInBoard(int targetRow, int targetCol)
    {
        return targetRow >= 0 && targetRow < 8
            && targetCol >= 0 && targetCol < 8;
    }

    static bool IsMoveValid(char figureType, int startRow, int startCol, int targetRow, int targetCol)
    {
        switch (figureType)
        {
            case 'P':
                return ValidPawnMove(startRow, startCol, targetRow, targetCol);

            case 'R':
                return ValidStraightMove(startRow, startCol, targetRow, targetCol);

            case 'B':
                return ValidDiagonalMove(startRow, startCol, targetRow, targetCol);

            case 'Q':
                return ValidDiagonalMove(startRow, startCol, targetRow, targetCol) ||
                    ValidStraightMove(startRow, startCol, targetRow, targetCol);

            case 'K':
                return ValidKingMove(startRow, startCol, targetRow, targetCol);

            default:
                throw new ArgumentException();

        }
    }

    static bool ValidKingMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        var validRow = Math.Abs(startRow - targetRow) == 1
            && Math.Abs(targetCol - startCol) == 0;

        var validCol = Math.Abs(startRow - targetRow) == 0
            && Math.Abs(targetCol - startCol) == 1;

        var validDiag = Math.Abs(startRow - targetRow) == 1
            && Math.Abs(targetCol - startCol) == 1;

        return validRow || validCol || validDiag;
    }

    static bool ValidDiagonalMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        return Math.Abs(startRow - targetRow) == Math.Abs(startCol - targetCol);
    }

    static bool ValidStraightMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        return targetRow == startRow
            || targetCol == startCol;
    }

    static bool ValidPawnMove(int startRow, int startCol, int targetRow, int targetCol)
    {
        return targetRow + 1 == startRow
            && targetCol == startCol;
    }

    static bool DoesFigureExist(char figureType, int startRow, int startCol)
    {
        return board[startRow][startCol] == figureType;
    }
}