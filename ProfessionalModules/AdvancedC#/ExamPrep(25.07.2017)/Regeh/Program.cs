using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public class TheHeiganDance
{
    public static void Main()
    {
        var pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]";

        var input = Console.ReadLine();

        var regex = new Regex(pattern);

        var indexes = new List<int>();

        foreach (Match match in regex.Matches(input))
        {
            indexes.Add(int.Parse(match.Groups[1].Value));
            indexes.Add(int.Parse(match.Groups[2].Value));
        }

        int currIndex = 0;
        var output = new StringBuilder();

        foreach (var index in indexes)
        {
            currIndex += index;
            var charToWrite = currIndex % (input.Length - 1);
            output.Append(input[charToWrite]);
        }
        Console.WriteLine(output);
    }
}
