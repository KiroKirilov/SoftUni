using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ribiksmatrix
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var block1 = new int[n][];
        var block2 = new int[n][];

        for (int i = 0; i < n; i++)
        {
            block1[i] =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        for (int i = 0; i < n; i++)
        {
            block2[i] =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        var lengthFirstRow = 0;
        var blocksMatch = true;
        var totalCells = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                lengthFirstRow = block1[i].Length + block2[i].Length;
                totalCells += lengthFirstRow;
                continue;
            }

            var lengthB1 = block1[i].Length;
            var lengthB2 = block2[i].Length;
            totalCells += lengthB1 + lengthB2;

            if (lengthB1 + lengthB2 != lengthFirstRow)
            {
                blocksMatch = false;
            }
        }

        if (!blocksMatch)
        {
            Console.WriteLine("The total number of cells is: {0}", totalCells);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                Array.Reverse(block2[i]);
                Console.WriteLine("[{0}, {1}]", string.Join(", ", block1[i]), string.Join(", ", block2[i]));
            }
        }
    }
}
