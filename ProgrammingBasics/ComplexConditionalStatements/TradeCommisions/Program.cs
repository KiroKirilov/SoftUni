using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            var town = Console.ReadLine().ToLower();
            double s = double.Parse(Console.ReadLine());
            double coms = -1;

            if (town == "sofia")
            {
                if (s < 0) Console.WriteLine("error");
                else if (0 <= s && s <= 500) coms = 0.05;
                else if (500 < s && s <= 1000) coms = 0.07;
                else if (1000 < s && s <= 10000) coms = 0.08;
                else if (s > 10000) coms = 0.12;
            }
            else if (town == "varna")
            {
                if (s < 0) Console.WriteLine("error");
                else if (0 <= s && s <= 500) coms = 0.045;
                else if (500 < s && s <= 1000) coms = 0.075;
                else if (1000 < s && s <= 10000) coms = 0.1;
                else if (s > 10000) coms = 0.13;
            }
            else if (town == "plovdiv")
            {
                if (s < 0) Console.WriteLine("error");
                else if (0 <= s && s <= 500) coms = 0.055;
                else if (500 < s && s <= 1000) coms = 0.08;
                else if (1000 < s && s <= 10000) coms = 0.12;
                else if (s > 10000) coms = 0.145;
            }
            else
            {
                if (coms < 0)
                {
                    Console.WriteLine("error");
                }
                else Console.WriteLine("error");
            }
            Console.WriteLine("{0:f2}", coms * s);
        }
    }
}
