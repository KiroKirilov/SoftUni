using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pedala_vladi_i_voleibola_mu
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine().ToLower();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            var weekendsSofia = 48 - h;
            var gamesSofia = weekendsSofia * (3.0 / 4);
            var townGames = h;
            var holidayGames = p * (2.0 / 3);
            var totalGames = holidayGames + townGames + gamesSofia;

            if (year == "leap")
            {
                totalGames *= 1.15;
            }

            Console.WriteLine(Math.Truncate(totalGames));
        }
    }
}
