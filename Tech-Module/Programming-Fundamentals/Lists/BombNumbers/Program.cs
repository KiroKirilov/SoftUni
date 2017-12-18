using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

        string[] intpit = Console.ReadLine().Split();

        int number = int.Parse(intpit[0]);
        int power = int.Parse(intpit[1]);

        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i] == number)
            {
                int left = Math.Max(i - power, 0);

                int right = Math.Min(i + power, sequence.Count - 1);

                int length = right - left + 1;
                sequence.RemoveRange(left, length);
                i = 0;
            }
        }
        Console.WriteLine(sequence.Sum());
    }
}