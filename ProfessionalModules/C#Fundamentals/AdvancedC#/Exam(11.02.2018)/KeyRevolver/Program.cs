using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            var intelligenceValue = int.Parse(Console.ReadLine());

            var totalBullets = bullets.Count;
            var reloadCounter=0;

            while (bullets.Count>0 && locks.Count>0)
            {
                if (reloadCounter == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    reloadCounter = 0;
                    continue;
                }

                var currentBullet = bullets.Pop();
                var currentLock = locks.Peek();

                if (currentBullet>currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                reloadCounter++;
            }

            if (reloadCounter==barrelSize && bullets.Count>0)
            {
                Console.WriteLine("Reloading!");
            }

            if (locks.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                long bulletCost = (totalBullets - bullets.Count) * bulletPrice;
                var earned = intelligenceValue - bulletCost;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
        }
    }
}
