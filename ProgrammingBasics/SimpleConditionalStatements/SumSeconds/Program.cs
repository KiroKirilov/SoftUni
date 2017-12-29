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
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var sec = a + b + c;

            if (sec < 60)
            {
                if (sec < 10)
                {
                    Console.WriteLine("0:0" + sec);
                }
                else Console.WriteLine("0:" + sec);
            }
            else if ((sec < 120) && (sec > 59))
            {
                sec -= 60;
                if (sec < 10)
                {
                    Console.WriteLine("1:0" + sec);
                }
                else Console.WriteLine("1:" + sec);
            }
            else if ((sec < 180) && (sec > 119))
            {
                sec -= 120;
                if (sec < 10)
                {
                    Console.WriteLine("2:0" + sec);
                }
                else Console.WriteLine("2:" + sec);
            }


        }
    }
}
