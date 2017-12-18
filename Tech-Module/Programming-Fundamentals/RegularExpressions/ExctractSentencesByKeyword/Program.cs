using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace extract_sentence_by_keyword
{
    class Program
    {
        static void Main(string[] args)
        {

            var keyword = Console.ReadLine();
            var pattern = $@"\b{keyword}\b";
            var input = Console.ReadLine();
            string[] sentences = input.Split(new char[] { '.', '!', '?' }).ToArray();

            foreach (var item in sentences)
            {
                if (Regex.IsMatch(item, pattern))
                {
                    Console.WriteLine(item.Trim().TrimEnd(new char[] { '.', '!', '?' }));
                }
            }
        }
    }
}