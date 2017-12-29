using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = (n - 1) / 2;
            int mid = 0;
            string row = "";

            if (n == 2)
            {
                Console.WriteLine("**");
            }
            else
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    row += new string('-', leftRight) + "*";
                    mid = n - 2 * leftRight - 2;
                    if (mid >= 0)
                    {
                        row += new string('-', mid) + "*";
                    }
                    row += new string('-', leftRight);
                    Console.WriteLine(row);
                    row = "";
                    leftRight--;
                }
                for (int i = 0; i <= n / 2; i++)
                {
                    if (n % 2 == 0 && i == 0)
                    {
                        i += 2;
                        leftRight += 2;
                    }
                    row += new string('-', leftRight) + "*";
                    mid = n - 2 * leftRight - 2;
                    if (mid >= 0)
                    {
                        row += new string('-', mid) + "*";
                    }
                    row += new string('-', leftRight);
                    Console.WriteLine(row);
                    row = "";
                    leftRight++;
                }
            }
        }
    }
}