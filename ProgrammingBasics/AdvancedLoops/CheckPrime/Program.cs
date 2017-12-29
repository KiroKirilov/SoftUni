using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {

        public static bool isPrime(int number)
        {
            if (number <= 0 || number == 2) return false;
            if (number == 1) return false;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }



        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (isPrime(n) == true)
            {
                Console.WriteLine("Prime");
            }
            else Console.WriteLine("Not Prime");
        }
    }
}