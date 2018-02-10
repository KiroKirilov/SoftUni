using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Print(names,(name)=>name.Length<=maxLength);
        }

        public static void Print(IEnumerable<string> collection, Func<string, bool> Filter)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection.Where(Filter)));
        }
    }
}
