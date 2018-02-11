using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"((?<curl>\{)|\[)[^{}[]*?(?<number>\d{3,})[^{}[]*?(?(curl)\}|\])";
            var regex = new Regex(pattern);

            var lines = int.Parse(Console.ReadLine());

            var input = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                var currentLine = Console.ReadLine();
                input.Append(currentLine);
            }

            var output = new StringBuilder();

            foreach (Match match in regex.Matches(input.ToString()))
            {
                if (match.Groups["number"].Value.Length%3==0)
                {
                    for (int i = 0; i < match.Groups["number"].Value.Length; i+=3)
                    {
                        var str = match.Groups["number"].Value[i].ToString() + match.Groups["number"].Value[i+1] + match.Groups["number"].Value[i+2];
                        var strInt = int.Parse(str)- match.Length;
                        output.Append((char)strInt);
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}
