using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_for_a_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var count = numbers.Count;

            for (int i = 0; i < count - commands[0]; i++)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }

            for (int i = 0; i < commands[1]; i++)
            {
                numbers.RemoveAt(0);
            }

            if (numbers.IndexOf(commands[2]) != -1) Console.WriteLine("YES!");
            else Console.WriteLine("NO!");
        }
    }
}