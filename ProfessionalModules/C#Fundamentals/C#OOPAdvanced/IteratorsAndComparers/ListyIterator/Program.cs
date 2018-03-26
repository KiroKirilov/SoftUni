using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var createData = Console.ReadLine().Split().ToList();
        createData.RemoveAt(0);

        var listy = new ListyIterator<string>(createData);

        var command = "";

        while ((command = Console.ReadLine())!="END")
        {
            try
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;

                    case "Print":
                        listy.Print();
                        break;

                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;

                    case "PrintAll":
                        listy.PrintAll();
                        break;

                    default:
                        break;
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}

