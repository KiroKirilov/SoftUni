using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class _07BalancedParentheses
{
    public static void Main()
    {
        var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        var r = dimensions[0];
        var c = dimensions[1];

        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                var str = alphabet[i].ToString() + alphabet[i + j].ToString() + alphabet[i].ToString();
                Console.Write("{0} ", str);
            }
            Console.WriteLine();
        }
    }
}
