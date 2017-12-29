using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string borders = new string('*', 2 * size);

            Console.WriteLine("{0}{1}{0}", borders, new string(' ', size));
            for (int i = 0; i < size - 2; i++)
            {
                char sep;
                if (size % 2 == 0)
                {
                    if (i == (size - 2) / 2 - 1)
                    {
                        sep = '|';
                    }
                    else sep = ' ';
                }
                else
                {
                    if (i == (size - 2) / 2)
                    {
                        sep = '|';
                    }
                    else sep = ' ';
                }
                Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * size - 2), new string(sep, size));
            }
            Console.WriteLine("{0}{1}{0}", borders, new string(' ', size));
        }
    }
}