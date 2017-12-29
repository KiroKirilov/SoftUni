using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conditions
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = double.Parse(Console.ReadLine());
            Double bonus = 0;

            if (score <= 100)
            {
                bonus = 5;
            }
            else if (score > 1000)
            {
                bonus = 0.1 * score;
            }
            else if (score > 100)
            {
                bonus = 0.2 * score;
            }

            if (score % 2 == 0)
            {
                bonus += 1;
            }
            else if ((score % 5 == 0) && (score % 10 != 0))
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(score + bonus);
        }
    }
}
