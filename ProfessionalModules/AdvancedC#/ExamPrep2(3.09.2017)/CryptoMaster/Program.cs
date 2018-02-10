using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var nums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var maxSequence = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            for (int step = 1; step < nums.Length; step++)
            {
                int currentIndex = index;
                int nextIndex = (index + step) % nums.Length;
                int currentSequence = 1;

                while (nums[currentIndex] < nums[nextIndex])
                {
                    currentIndex = nextIndex;
                    nextIndex = (nextIndex + step) % nums.Length;
                    currentSequence++;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }
            }
        }

        Console.WriteLine(maxSequence);
    }
}