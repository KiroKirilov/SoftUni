using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Longer_Line
{
    class GivesLongerLineInCoordinateSystem
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());


            if (CloserPoint(x1, y1, x2, y2))
            {

                Console.WriteLine($"({x1}, {y1})");

            }
            else Console.WriteLine($"({x2}, {y2})");
        }



        private static bool CloserPoint(double x1, double y1, double x2, double y2)
        {
            double firstPointLine = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointLine = Math.Sqrt(x2 * x2 + y2 * y2);
            bool isFirstCloser = true;
            if (firstPointLine <= secondPointLine)
            {
                isFirstCloser = true;
            }
            else
            {
                isFirstCloser = false;
            }
            return isFirstCloser;
        }
    }
}