using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNum>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";

            var regex = new Regex(pattern);

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();

                var matches = regex.Matches(input);

                var middleMatch = matches[matches.Count / 2];

                var password = middleMatch.Groups["password"].Value;
                var streetName = middleMatch.Groups["streetName"].Value;
                var streetNum= middleMatch.Groups["streetNum"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNum}. Secret pass: {password}.");
            }
        }
    }
}
