using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace change_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();


            while (true)
            {
                var commands = Console.ReadLine().Split(' ').ToArray();
                string currentCommand = commands[0];

                if (currentCommand == "Delete")
                {
                    while (numbers.Remove(int.Parse(commands[1])))
                    {
                        numbers.Remove(int.Parse(commands[1]));
                    }
                }

                if (currentCommand == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }

                if (currentCommand == "Odd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                    }
                    break;
                }

                if (currentCommand == "Even")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                    }
                    break;
                }

            }
        }
    }
}