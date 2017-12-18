using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interchangeable_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Console.WriteLine(AreExchhangable(input[0], input[1]).ToString().ToLower());
        }

        private static bool AreExchhangable(string firstString, string secondString)
        {
            List<char> firstList = firstString
                .ToList()
                .Distinct()
                .ToList();

            List<char> secondList = secondString
                .ToList()
                .Distinct()
                .ToList();

            return (firstList.Count == secondList.Count) ? true : false;
        }
    }
}