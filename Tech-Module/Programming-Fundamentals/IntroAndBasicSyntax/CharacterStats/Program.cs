using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterStats
{
    public class Program
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            var health = int.Parse(Console.ReadLine());
            var maxHealth = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var maxEnergy = int.Parse(Console.ReadLine());


            Console.WriteLine("Name: " + name);
            Console.WriteLine("Health: |" + new string('|', health) + new string('.', maxHealth - health) + "|");
            Console.WriteLine("Energy: |" + new string('|', energy) + new string('.', maxEnergy - energy) + "|");

        }

    }
}
