namespace Letters_Change_Numbers
{
    using System;
    using System.Linq;
    using System.Text;

    public class LettersChangeNumbers
    {
        public static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            decimal totalSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                totalSum += StringValue(input[i]);
            }

            Console.WriteLine($"{totalSum:F2}");
        }

        private static decimal StringValue(string str)
        {
            decimal number = ExtractNumber(str);
            if (char.IsUpper(str[0]))
            {
                byte letterPosition = (byte)((str[0] - 'A') + 1);
                number /= letterPosition;
            }
            else
            {
                byte letterPosition = (byte)((str[0] - 'a') + 1);
                number *= letterPosition;
            }

            if (char.IsUpper(str.Last()))
            {
                byte letterPosition = (byte)((str.Last() - 'A') + 1);
                number -= letterPosition;
            }
            else
            {
                byte letterPosition = (byte)((str.Last() - 'a') + 1);
                number += letterPosition;
            }

            return number;
        }

        private static decimal ExtractNumber(string str)
        {
            StringBuilder result = new StringBuilder(str.Length - 2);
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    result.Append(str[i]);
                }
            }

            return decimal.Parse(result.ToString());
        }
    }
}