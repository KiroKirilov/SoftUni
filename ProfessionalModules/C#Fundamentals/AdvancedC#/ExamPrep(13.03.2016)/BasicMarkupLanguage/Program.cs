using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMarkupLanguage
{
    class Program
    {
        static int lineCounter = 0;
        static void Main(string[] args)
        {
            var output = new StringBuilder();

            var input = "";
            while ((input=Console.ReadLine())!="<stop/>")
            {
                var commandArgs = input.Split(new char[] { ' ','>','<','/' },StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0].ToLower())
                {
                    case "inverse":
                        output.Append(InverseContent(input));
                        break;

                    case "reverse":
                        output.Append(ReverseContent(input));
                        break;

                    case "repeat":
                        output.Append(RepeatContent(input));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(output);
        }

        private static string RepeatContent(string input)
        {
            var repeated = new StringBuilder();

            var args=input.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);

            var timesToRepeat = int.Parse(args[1]);
            var stringToRepeat = args[3];

            for (int counter = 0; counter < timesToRepeat; counter++)
            {
                lineCounter++;
                repeated.Append(lineCounter + ". " + stringToRepeat + Environment.NewLine);
            }

            return repeated.ToString();
        }

        private static string ReverseContent(string input)
        {
            var args = input.Split(new char[]{'"'},StringSplitOptions.RemoveEmptyEntries);
            var stringToReverse = args[1];

            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            stringToReverse= new string(charArray);
            lineCounter++;
            return lineCounter + ". " + stringToReverse + Environment.NewLine;
        }

        private static string InverseContent(string input)
        {
            var args=input.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);
            var stringToInverse = args[1];

            string reversedCase = new string(
                stringToInverse.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                                  char.ToLower(c) : char.ToUpper(c)) : c).ToArray());

            lineCounter++;
            return lineCounter+". "+reversedCase+Environment.NewLine;
        }
    }
}
