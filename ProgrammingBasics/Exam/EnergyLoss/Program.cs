using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int dancers = int.Parse(Console.ReadLine());
            int energyWasted = 0;
            double energy = 100 * days * dancers;
            for (int i = 1; i <= days; i++)
            {

                int hours = int.Parse(Console.ReadLine());

                if (i % 2 == 0 && hours % 2 == 0)
                {
                    energyWasted = 68 * dancers;
                }
                if (i % 2 == 1 && hours % 2 == 1)
                {
                    energyWasted = 30 * dancers;
                }
                if (i % 2 == 0 && hours % 2 == 1)
                {
                    energyWasted = 65 * dancers;
                }
                if (i % 2 == 1 && hours % 2 == 0)
                {
                    energyWasted = 49 * dancers;
                }

                energy -= energyWasted;
            }
            energy = energy / dancers / days;

            if (energy < 50)
            {
                Console.WriteLine("They are wasted! Energy left: {0:f2}", energy);
            }
            else
            {
                Console.WriteLine("They feel good! Energy left: {0:f2}", energy);
            }
        }
    }
}
