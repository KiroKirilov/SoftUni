using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace base_10_to_base_n
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            Console.WriteLine(ConvertToBase(input[1], input[0]));
        }

        public static string ConvertToBase(BigInteger number, BigInteger toBase)
        {
            StringBuilder converted = new StringBuilder();

            while (number != 0)
            {
                int rem = (int)BigInteger.Remainder(number, toBase);
                number = BigInteger.Divide(number, toBase);
                converted.Insert(0, rem);
            }
            return converted.ToString();
        }
    }
}