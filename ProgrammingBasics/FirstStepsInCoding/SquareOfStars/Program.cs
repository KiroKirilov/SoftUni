using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                Console.Write("*");
            }
            Console.WriteLine("");
            for (int i = 0; i < n - 2; i++)
            {


                for (int j = 0; j < n; j++)
                {
                    if ((j == 0) || (j == n - 1))
                    {
                        Console.Write("*");
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine("");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }

        }
    }
}