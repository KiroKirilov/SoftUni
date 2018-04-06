using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var arr = new int[] { 1, 4, 5, 2, 3, 8 };
        var bubble = new Bubble<int>(arr);
        var sorted=bubble.Sort();
        Console.WriteLine(string.Join(" ",sorted));
    }
}

