using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var fibonacci = new Stack<long>();
        fibonacci.Push(1);
        fibonacci.Push(1);
        for (int i = 2; i < n; i++)
        {
            long fibPrev = fibonacci.Pop();
            long fibNext = fibonacci.Peek() + fibPrev;
            fibonacci.Push(fibPrev);
            fibonacci.Push(fibNext);
        }
        Console.WriteLine(fibonacci.Peek());
    }
}