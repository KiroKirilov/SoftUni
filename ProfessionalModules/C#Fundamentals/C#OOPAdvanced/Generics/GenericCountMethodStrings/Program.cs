using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var boxes = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            boxes.Add(new Box<string>(input));
        }

        var element = Console.ReadLine();

        Console.WriteLine(GetGreaterCount(boxes,element));
    }

    private static int GetGreaterCount<T>(List<Box<T>> list, T element)
        where T : IComparable<T>
    {
        return list.Count(b => b.Value.CompareTo(element) > 0);
    }


    private static void SwapElements<T>(List<Box<T>> list, int index1, int index2)
    {
        var tempItem = list[index1];
        list[index1] = list[index2];
        list[index2] = tempItem;
    }
}

