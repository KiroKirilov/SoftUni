using System;


class Program
{
    static void Main(string[] args)
    {
        var list = new CustomList<string>();

        var input = "";

        while ((input=Console.ReadLine())!="END")
        {
            var commandArgs = input.Split(' ');
            var currentCommand = commandArgs[0];

            switch (currentCommand)
            {
                case "Add":
                    var elementToAdd = commandArgs[1];
                    list.Add(elementToAdd);
                    break;

                case "Remove":
                    var indexToRemoveAt = int.Parse(commandArgs[1]);
                    list.Remove(indexToRemoveAt);
                    break;

                case "Contains":
                    var elementToContain = commandArgs[1];
                    var result = list.Contains(elementToContain) ? "True" : "False";
                    Console.WriteLine(result);
                    break;

                case "Min":
                    Console.WriteLine(list.Min());
                    break;

                case "Max":
                    Console.WriteLine(list.Max());
                    break;

                case "Swap":
                    var index1 = int.Parse(commandArgs[1]);
                    var index2 = int.Parse(commandArgs[2]);
                    list.Swap(index1, index2);
                    break;

                case "Greater":
                    var elementToCountGreaterThan = commandArgs[1];
                    Console.WriteLine(list.CountGreaterThan(elementToCountGreaterThan));
                    break;

                case "Print":
                    Console.WriteLine(list.ToString());
                    break;

                case "Sort":
                    Sorter.Sort(list);
                    break;

                default:
                    break;
            }
        }
    }
}

