using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fold_nad_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = arr1.Length / 4;
            int[] fold1 = new int[k];
            int[] fold2 = new int[k];
            int[] leftover = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                fold1[i] = arr1[i];

            }

            Array.Reverse(fold1);

            for (int i = 1; i <= k; i++)
            {
                fold2[i - 1] = arr1[arr1.Length - i];
            }

            for (int i = 0; i < 2 * k; i++)
            {

                leftover[i] = arr1[k + i];
            }

            var folded = new int[fold1.Length + fold2.Length];
            fold1.CopyTo(folded, 0);
            fold2.CopyTo(folded, fold1.Length);



            var result = new int[Math.Max(leftover.Length, folded.Length)];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = folded[i % folded.Length] + leftover[i % leftover.Length];

                Console.Write(result[i] + " ");
            }
        }
    }
}