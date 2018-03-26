using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var data = Console.ReadLine();
        var input = new List<int>();
        if (data.Contains(','))
        {
            input = data.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }
        else
            input = data.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var lake = new Lake<int>(input);
        var orderedItems = new Queue<long>();

        foreach (var item in lake)
        {
            orderedItems.Enqueue(item);
        }

        Console.WriteLine(string.Join(", ", orderedItems));
    }
}

