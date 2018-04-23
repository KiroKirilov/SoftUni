using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string siteName = input[0];
                long visits = long.Parse(input[1]);
                decimal moneyPerVisit = decimal.Parse(input[2]);
                Console.WriteLine(siteName);
                totalLoss += visits * moneyPerVisit;
            }


            BigInteger s = BigInteger.Pow(securityKey, n);
            Console.WriteLine("Total Loss: {0:f20}", totalLoss);
            Console.WriteLine("Security Token: {0}", s);
        }
    }
}
