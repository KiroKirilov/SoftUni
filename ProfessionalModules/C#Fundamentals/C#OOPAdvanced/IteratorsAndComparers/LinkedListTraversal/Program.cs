using System;


class Program
{
    static void Main(string[] args)
    {
        var amountOfCommands = int.Parse(Console.ReadLine());

        var linkedList = new LinkedList<string>();

        for (int i = 0; i < amountOfCommands; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var command = cmdArgs[0];
            var param = cmdArgs[1];
            switch (command)
            {
                case "Add":
                    linkedList.Add(param);
                    break;

                case "Remove":
                    linkedList.Remove(param);
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ",linkedList));
    }
}

