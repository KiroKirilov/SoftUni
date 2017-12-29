using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1._2_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] InputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> sequences = new List<int>();
            for (int i = 0; i < InputNumbers.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (InputNumbers[i] == InputNumbers[j]) counter++;
                }
                sequences.Add(counter);
            }

            int maxsequence = sequences.Max();
            int positionmax = sequences.IndexOf(sequences.Max());
            for (int i = 0; i < maxsequence; i++)
            {
                Console.Write(InputNumbers[positionmax]);
                if (i != maxsequence - 1) Console.Write(" ");
                else Console.WriteLine();
            }
        }
    }
}