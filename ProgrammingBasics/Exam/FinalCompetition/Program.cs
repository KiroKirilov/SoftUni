using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());

            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string place = Console.ReadLine().ToLower();
            double prize = 0;
            if (place == "bulgaria")
            {
                prize = points * dancers;
                if (season == "summer")
                {
                    prize -= prize * 0.05;
                }
                else
                {
                    prize -= prize * 0.08;
                }
            }
            else
            {
                prize = (dancers * points) * 1.5;
                if (season == "summer")
                {
                    prize -= prize * 0.1;
                }
                else
                {
                    prize -= prize * 0.15;
                }
            }
            double charity = prize * 0.75;
            prize -= charity;

            Console.WriteLine("Charity - {0:f2}", charity);
            Console.WriteLine("Money per dancer - {0:f2}", prize / dancers);
        }
    }
}
