using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace box_frame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string row = "";

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    row += "+ ";
                }
                else row += "- ";
            }
            Console.WriteLine(row);
            row = "";

            for (int i = 1; i <= n - 2; i++)
            {

                for (int j = 1; j <= n; j++)
                {
                    if (j == 1 || j == n)
                    {
                        row += "| ";
                    }
                    else row += "- ";
                }
                Console.WriteLine(row);
                row = "";
            }



            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    row += "+ ";
                }
                else row += "- ";
            }
            Console.WriteLine(row);
        }
    }
}