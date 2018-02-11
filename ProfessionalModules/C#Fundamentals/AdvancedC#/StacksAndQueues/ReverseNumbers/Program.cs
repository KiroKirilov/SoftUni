using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        try
        {
            var intNumbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var stackNumbers = new Stack<int>();
            intNumbers.ForEach(n => stackNumbers.Push(n));
            foreach (var stackNumber in stackNumbers)
            {
                Console.Write(stackNumber + " ");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine(input);
        }
    }
}