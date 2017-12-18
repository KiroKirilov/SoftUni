using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                var commands = Console.ReadLine().Split().ToArray();
                var currentCommand = commands[0];

                if (currentCommand == "A")
                {
                    phonebook[commands[1]] = commands[2];
                }

                if (currentCommand == "S")
                {
                    if (phonebook.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"{commands[1]} -> {phonebook[commands[1]]}");
                    }
                    else Console.WriteLine($"Contact {commands[1]} does not exist.");
                }

                if (currentCommand == "ListAll")
                {
                    var sortedDict = phonebook.OrderBy(x => x.Key);

                    foreach (var item in sortedDict)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }

                if (currentCommand == "END")
                {
                    break;
                }
            }
        }
    }
}