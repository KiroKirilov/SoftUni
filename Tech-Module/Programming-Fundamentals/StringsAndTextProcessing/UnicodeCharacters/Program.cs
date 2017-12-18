using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace get_unicode_of_string
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            foreach (char ch in input)
            {
                Console.Write(GetEscapeSequence(ch).ToLower());
            }
        }

        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4");
        }
    }
}