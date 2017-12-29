using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rhombus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string row = "";

            for (int i = 1; i <= n; i++)
            {
                row += new string(' ', n - i);
                for (int j = 0; j < i; j++)
                {
                    row += "* ";
                }
                row += new string(' ', n - i);
                Console.WriteLine(row);
                row = "";
            }

            for (int i = 1; i <= n; i++)
            {
                row += new string(' ', i);
                for (int j = 0; j < n - i; j++)
                {
                    row += "* ";
                }
                row += new string(' ', i);
                Console.WriteLine(row);
                row = "";
            }

        }
    }
}