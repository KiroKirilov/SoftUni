using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());

            int dancers = int.Parse(Console.ReadLine());

            int days = int.Parse(Console.ReadLine());

            double stepsPerDay = steps / days;
            stepsPerDay /= steps;

            stepsPerDay = Math.Ceiling(stepsPerDay * 100);

            double stepsPerDancer = stepsPerDay / dancers;

            if (stepsPerDay <= 13)
            {
                Console.WriteLine("Yes, they will succeed in that goal! {0:f2}%. ", stepsPerDancer);
            }
            else
            {
                Console.WriteLine("No, They will not succeed in that goal! Required {0:f2}% steps to be learned per day.", stepsPerDancer);
            }
        }
    }
}
