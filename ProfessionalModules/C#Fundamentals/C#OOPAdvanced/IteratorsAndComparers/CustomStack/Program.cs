using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var stack = new Stack<string>();

        while ((input = Console.ReadLine())!="END")
        {
            var cmdArgs = input.Split(" ").ToList();
            var command = cmdArgs[0];
            cmdArgs.RemoveAt(0);
            var cmdString = string.Join(string.Empty, cmdArgs);
            var pushArgs = cmdString.Split(',');

            try
            {
                switch (command)
                {
                    case "Push":
                        stack.Push(pushArgs);
                        break;

                    case "Pop":
                        stack.Pop();
                        break;

                    default:
                        break;
                }
            }
            catch(InvalidOperationException invOpEx)
            {
                Console.WriteLine(invOpEx.Message);
            }
        }

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}

