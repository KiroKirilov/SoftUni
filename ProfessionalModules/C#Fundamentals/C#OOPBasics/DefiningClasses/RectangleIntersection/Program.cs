using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var amountOfRectangles = int.Parse(data[0]);
        var amountOfQueries = int.Parse(data[1]);

        var rectangles = new Rectangle[amountOfRectangles];

        for (int i = 0; i < amountOfRectangles; i++)
        {
            var rectData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var id = rectData[0];
            var w = double.Parse(rectData[1]);
            var h = double.Parse(rectData[2]);
            var lx = double.Parse(rectData[3]);
            var ly = double.Parse(rectData[4]);

            var currentRect = new Rectangle(id, w, h, lx, ly);
            rectangles[i] = currentRect;
        }

        for (int i = 0; i < amountOfQueries; i++)
        {
            var currentQuery=Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var id1 = currentQuery[0];
            var id2 = currentQuery[1];
            var filtered = rectangles.Where(r => r.ID == id1 || r.ID == id2).ToArray();

           
           Console.WriteLine(filtered[0].IntersectsWith(filtered[1]));
        }
    }
}

