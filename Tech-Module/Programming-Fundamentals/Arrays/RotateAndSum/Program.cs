using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rotate_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sum = new int[arr1.Length];
            int r = int.Parse(Console.ReadLine());

            for (int i = 0; i < r; i++)
            {
                int[] rotated = new int[arr1.Length];
                rotated[0] = arr1[arr1.Length - 1];
                for (int j = 1; j < rotated.Length; j++)
                {
                    rotated[j] = arr1[j - 1];
                }

                for (int j = 0; j < sum.Length; j++)
                {
                    sum[j] += rotated[j];
                }

                arr1 = rotated;
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}