using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrangenumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var stringNums = new List<string>();
            var item = new string[2];

            stringNums = numbers.OrderBy(n=>Stringify(n)).ToList();
            Console.WriteLine(String.Join(", ",stringNums));
        }

        private static string Stringify(string num)
        {
            var sb = new StringBuilder();
            foreach (var digit in num)
            {
                sb.Append(GetDigitAsString(digit));
            }

            sb.Remove(0, 1);
            return sb.ToString();
        }

        private static string GetDigitAsString(char digit)
        {
            switch(digit)
            {
                case '1':
                    return "-one";
                case '2':
                    return "-two";
                case '3':
                    return "-three";
                case '4':
                    return "-four";
                case '5':
                    return "-five";
                case '6':
                    return "-six";
                case '7':
                    return "-seven";
                case '8':
                    return "-eight";
                case '9':
                    return "-nine";
                case '0':
                    return "-zero";
                default:
                    return null;

            }
        }
    }
}
