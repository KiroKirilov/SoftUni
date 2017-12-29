using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string triangle = "";
            for (int i = 0; i < n; i++)
            {
                triangle += "$ ";
                Console.WriteLine(triangle);
            }

        }
    }
}