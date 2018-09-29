using System;
using System.Linq;
using System.Threading;

namespace EvenNumbersThread
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = numberData[0];
            int end = numberData[1];
            
            Thread evens = new Thread(() => PrintEvenNumbers(start, end));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int currentNum = start; currentNum <= end; currentNum++)
            {
                if (currentNum%2==0)
                {
                    Console.WriteLine(currentNum);
                }
            }
        }
    }
}
