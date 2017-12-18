using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compare_char_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            int length = 0;
            if (arr1.Length > arr2.Length) length = arr2.Length;
            else length = arr1.Length;
            int i;

            for (i = 0; i < length; i++)
            {
                if (arr1[i] < arr2[i])
                {
                    Console.WriteLine(string.Join("", arr1));
                    Console.WriteLine(string.Join("", arr2));
                    break;
                }
                else if (arr2[i] < arr1[i])
                {
                    Console.WriteLine(string.Join("", arr2));
                    Console.WriteLine(string.Join("", arr1));
                    break;
                }
                else if (i == length - 1)
                {
                    if (arr1.Length > arr2.Length)
                    {
                        Console.WriteLine(string.Join("", arr2));
                        Console.WriteLine(string.Join("", arr1));
                    }
                    else
                    {
                        Console.WriteLine(string.Join("", arr1));
                        Console.WriteLine(string.Join("", arr2));
                    }
                }
            }
        }
    }
}