using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace max_sequence_of_inc_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxStart = 0;
            int maxLen = 1;
            int currentStart = 0;
            int currentLen = 1;

            for (int i = 1; i < sequance.Length; i++)
            {
                if (sequance[i] > sequance[i - 1])
                {
                    currentLen++;
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        maxStart = currentStart;
                    }
                }
                else
                {
                    currentStart = i;
                    currentLen = 1;
                }
            }
            for (int i = maxStart; i < maxStart + maxLen; i++)
                Console.Write("{0} ", sequance[i]);
        }
    }
}