using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christmas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string row = "";

            Console.WriteLine(new string(' ', n) + " |");

            for (int i = 1; i <= n; i++)
            {
                row += new string(' ', n - i) + new string('*', i) + " | " + new string('*', i) + new string(' ', n - i);
                Console.WriteLine(row);
                row = "";
            }
        }
    }
}
