using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace max_sequenceof_equal_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int equalNumber = arr1[0];
            int currLength = 1;
            int bestLength = 0;

            for (int i = 1; i < arr1.Length; i++)
            {
                if (arr1[i] == arr1[i - 1])
                {
                    currLength++;
                    if (currLength > bestLength)
                    {
                        bestLength = currLength;
                        equalNumber = arr1[i];
                    }
                }
                else currLength = 1;
            }
            for (int i = 1; i <= bestLength; i++)
            {
                Console.Write(equalNumber + " ");
            }
        }
    }
}