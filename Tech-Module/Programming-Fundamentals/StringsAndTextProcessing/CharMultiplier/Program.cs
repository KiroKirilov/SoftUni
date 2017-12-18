using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace char_multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Console.WriteLine(getCharMulti(input[0], input[1]));
        }

        public static BigInteger getCharMulti(string a, string b)
        {
            BigInteger totalSum = 0;
            int iterations = 0;
            int shortLen = 0;
            string longer = "";
            if (a.Length - b.Length >= 0)
            {
                iterations = a.Length;
                shortLen = b.Length;
                longer = a;
            }
            else
            {
                iterations = b.Length;
                shortLen = a.Length;
                longer = b;
            }

            for (int i = 0; i < iterations; i++)
            {
                if (i >= shortLen) totalSum += (BigInteger)(longer[i]);
                else totalSum += (BigInteger)(a[i] * b[i]);
            }
            return totalSum;
        }
    }
}