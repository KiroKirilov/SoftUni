using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vowels_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int vowelValue = 0;

            for (int i = 0; i < word.Length; i++)
            {
                switch (word[i])
                {
                    case 'a':
                        vowelValue += 1;
                        break;
                    case 'e':
                        vowelValue += 2;
                        break;
                    case 'i':
                        vowelValue += 3;
                        break;
                    case 'o':
                        vowelValue += 4;
                        break;
                    case 'u':
                        vowelValue += 5;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(vowelValue);
        }
    }
}