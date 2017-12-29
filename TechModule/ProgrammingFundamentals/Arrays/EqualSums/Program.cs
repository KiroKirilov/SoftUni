using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equal_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            int i;

            for (i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr1[j];
                }

                for (int j = i + 1; j < arr1.Length; j++)
                {
                    rightSum += arr1[j];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }
            if (i == arr1.Length)
            {
                Console.WriteLine("no");
            }
        }
    }
}