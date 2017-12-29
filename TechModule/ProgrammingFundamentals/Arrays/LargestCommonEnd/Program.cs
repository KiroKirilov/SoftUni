using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common_ends
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ').ToArray();
            string[] arr2 = Console.ReadLine().Split(' ').ToArray();
            int countLeft = 0;
            int countRight = 0;
            int length = 0;

            if (arr1.Length > arr2.Length)
            {
                length = arr2.Length;
            }
            else length = arr1.Length;


            for (int i = 0; i < length; i++)
            {
                if (arr1[i] == arr2[i]) countLeft++;
                else break;
            }
            Array.Reverse(arr1);
            Array.Reverse(arr2);
            for (int i = 0; i < length; i++)
            {
                if (arr1[i] == arr2[i]) countRight++;
                else break;
            }

            if (countLeft > countRight) Console.WriteLine(countLeft);
            else Console.WriteLine(countRight);
        }
    }
}