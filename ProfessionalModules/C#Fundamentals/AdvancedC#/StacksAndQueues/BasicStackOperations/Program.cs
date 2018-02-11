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
        var stackNumbers = new Stack<int>();

        intNumbers.ForEach(num => stackNumbers.Push(num));
        for (int i = 0; i < s; i++)
        {
            stackNumbers.Pop();
        }

        if (stackNumbers.Count != 0)
        {
            if (stackNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackNumbers.Min());
            }
        }
        else
            Console.WriteLine(0);
    }
}