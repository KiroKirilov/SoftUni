using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var boxes = new List<Box<int>>();

        for (int i = 0; i < n; i++)
        {
            var input = int.Parse(Console.ReadLine());
            boxes.Add(new Box<int>(input));
        }

        var swapData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var index1 = swapData[0];
        var index2 = swapData[1];
        SwapElements(boxes, index1, index2);

        foreach (var box in boxes)
        {
            Console.WriteLine(box.ToString());
        }
    }

    private static void SwapElements<T>(List<Box<T>> list, int index1, int index2)
    {
        var tempItem = list[index1];
        list[index1] = list[index2];
        list[index2] = tempItem;
    }
}

