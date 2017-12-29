using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxN_sqare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string symbs = "";
            for (int i = 0; i < n; i++)
            {
                symbs += "* ";


            }
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(symbs);
            }
        }
    }
}