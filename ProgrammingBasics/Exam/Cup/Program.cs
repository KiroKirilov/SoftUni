using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string row = "";

            for (int i = 0; i <= n; i++)
            {
                if (i < n / 2)
                {
                    row += new string('.', n + i) + new string('#', 3 * n - i * 2) + new string('.', n + i);
                    Console.WriteLine(row);
                    row = "";
                }
                else
                {
                    row += new string('.', n + i) + "#" + new string('.', (3 * n - i * 2) - 2) + "#" + new string('.', n + i);
                    Console.WriteLine(row);
                    row = "";
                }
            }
            Console.WriteLine(new string('.', 2 * n) + new string('#', n) + new string('.', 2 * n));
            for (int i = 0; i < n + 2; i++)
            {
                if (i != (n + 2) / 2 - 1)
                {
                    row += new string('.', (5 * n - (n + 4)) / 2) + new string('#', n + 4) + new string('.', (5 * n - (n + 4)) / 2);
                }
                else
                {
                    row += new string('.', (5 * n - (n + 4)) / 2) + new string('.', (n + 4 - 10) / 2) + "D^A^N^C^E^" + new string('.', (n + 4 - 10) / 2) + new string('.', (5 * n - (n + 4)) / 2);
                }
                Console.WriteLine(row);
                row = "";
            }
        }
    }
}
