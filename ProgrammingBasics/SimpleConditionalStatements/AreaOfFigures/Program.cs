using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            string fig = Console.ReadLine();

            switch (fig)
            {
                case "square":
                    var a = double.Parse(Console.ReadLine());
                    var lk = a * a;
                    Console.WriteLine(Math.Round(lk, 3));
                    break;
                case "rectangle":
                    var w = double.Parse(Console.ReadLine());
                    var h = double.Parse(Console.ReadLine());
                    var lp = w * h;
                    Console.WriteLine(Math.Round(lp, 3));
                    break;
                case "triangle":
                    var s = double.Parse(Console.ReadLine());
                    var v = double.Parse(Console.ReadLine());
                    var lt = (s * v) / 2;
                    Console.WriteLine(Math.Round(lt, 3));
                    break;
                case "circle":
                    var r = double.Parse(Console.ReadLine());
                    var lo = Math.PI * r * r;
                    Console.WriteLine(Math.Round(lo, 3));
                    break;
                default:
                    break;
            }
        }
    }
}