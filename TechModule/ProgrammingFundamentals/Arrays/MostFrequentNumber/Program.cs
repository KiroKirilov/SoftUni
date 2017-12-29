using System;
using System.Linq;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split(new char[] { ' ', '\r', '\n' }).Select(int.Parse).ToArray();
        var numbersByFrequency = new Dictionary<int, int>();

        foreach (int n in input)
        {
            if (numbersByFrequency.ContainsKey(n)) numbersByFrequency[n]++;
            else numbersByFrequency[n] = 1;
        }

        numbersByFrequency.OrderByDescending(n => n.Value);
        Console.WriteLine(numbersByFrequency.First().Key);
    }
}