using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var inputNSX = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var n = int.Parse(inputNSX[0]);
        var s = int.Parse(inputNSX[1]);
        var x = int.Parse(inputNSX[2]);                         //n - number of elements; s - number of elements to pop; x - check if present(true;smallest element)

        if (n < s)
            s = n;

        var intNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var queueNumbers = new Queue<int>();

        intNumbers.ForEach(num => queueNumbers.Enqueue(num));
        for (int i = 0; i < s; i++)
        {
            queueNumbers.Dequeue();
        }

        if (queueNumbers.Count != 0)
        {
            if (queueNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queueNumbers.Min());
            }
        }
        else
            Console.WriteLine(0);
    }
}