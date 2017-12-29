using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string row = "";
            int amountStars = 1;
            if (n % 2 == 0) amountStars++;

            for (int i = 1; i <= (n + 1) / 2; i++)
            {
                row += new string('-', (n - amountStars) / 2) + new string('*', amountStars) + new string('-', (n - amountStars) / 2);
                Console.WriteLine(row);
                row = "";
                amountStars += 2;
            }

            for (int i = 1; i <= n / 2; i++)
            {
                row += "|" + new string('*', n - 2) + "|";
                Console.WriteLine(row);
                row = "";
            }
        }
    }
}