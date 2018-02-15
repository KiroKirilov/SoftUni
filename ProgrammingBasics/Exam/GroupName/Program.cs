using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_6
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());
            char fourthLetter = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int count = 0;

            for (char i = 'A'; i <= firstLetter; i++)
            {

                for (char j = 'a'; j <= secondLetter; j++)
                {

                    for (char k = 'a'; k <= thirdLetter; k++)
                    {

                        for (char l = 'a'; l <= fourthLetter; l++)
                        {

                            for (int m = 0; m <= number; m++)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count - 1);
        }
    }
}
