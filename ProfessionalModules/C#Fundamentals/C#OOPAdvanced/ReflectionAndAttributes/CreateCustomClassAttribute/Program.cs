using System;
using System.Linq;

[Data("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class Program
{
    static void Main(string[] args)
    {
        var attribute = (DataAttribute)typeof(Program).GetCustomAttributes(false).First();

        var currentCommand = "";

        while ((currentCommand = Console.ReadLine()) != "END")
        {
            switch (currentCommand)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attribute.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                    break;
                default:
                    break;

            }
        }
    }
}

