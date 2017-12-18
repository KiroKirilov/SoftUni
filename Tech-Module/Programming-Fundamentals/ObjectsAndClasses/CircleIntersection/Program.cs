using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intersection_of_circles
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCircle1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputCircle2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Circle c1 = new Circle { x = inputCircle1[0], y = inputCircle1[1], r = inputCircle1[2] };
            Circle c2 = new Circle { x = inputCircle2[0], y = inputCircle2[1], r = inputCircle2[2] };

            if (CirclesIntersect(c1, c2)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }



        public static bool CirclesIntersect(Circle c1, Circle c2)
        {
            double d = Math.Sqrt(((c2.x - c1.x) * (c2.x - c1.x)) + ((c2.y - c1.y) * (c2.y - c1.y)));
            if (d > c1.r + c2.r) return false;
            else return true;
        }
    }




    public class Circle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int r { get; set; }
    }
}