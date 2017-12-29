namespace Melrah_Shake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MelrahShake
    {
        public static void Main(string[] args)
        {

            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            Shake(text, pattern);
        }

        private static void Shake(string text, string pattern)
        {
            int patternOccurances = CountOcurances(text, pattern);

            if (patternOccurances > 1)
            {
                Console.WriteLine("Shaked it.");

                text = text.Remove(text.IndexOf(pattern), pattern.Length);
                text = text.Remove(text.LastIndexOf(pattern), pattern.Length);
                pattern = pattern.Remove(pattern.Length / 2, 1);

                Shake(text, pattern);
            }
            else
            {
                Console.WriteLine("No shake.");
                Console.WriteLine(text);
                return;
            }
        }

        private static int CountOcurances(string text, string pattern)
        {
            int index = text.IndexOf(pattern);
            int count = 0;
            while (index >= 0 && pattern.Length > 0)
            {
                count++;
                index = text.IndexOf(pattern, index + 1);
            }

            return count;
        }
    }
}