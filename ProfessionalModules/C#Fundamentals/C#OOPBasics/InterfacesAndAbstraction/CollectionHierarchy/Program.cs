using System;


class Program
{
    static void Main(string[] args)
    {
        var inputLines = Console.ReadLine().Split(' ');
        var countRemove = int.Parse(Console.ReadLine());

        var addCollection = new AddCollection();
        var addRemoveCollection = new AddRemoveCollection();
        var myList = new MyList();

        AddItems(inputLines, addCollection, addRemoveCollection, myList);
        RemoveItems(countRemove, addRemoveCollection, myList);
    }

    private static void RemoveItems(int countRemove, AddRemoveCollection addRemoveCollection, MyList myList)
    {
        for (int i = 0; i < countRemove; i++)
        {
            Console.Write(addRemoveCollection.Remove() + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < countRemove; i++)
        {
            Console.Write(myList.Remove() + " ");
        }

        Console.WriteLine();
    }

    private static void AddItems(string[] inputLines, AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
    {
        foreach (var word in inputLines)
        {
            Console.Write(addCollection.Add(word) + " ");
        }

        Console.WriteLine();

        foreach (var word in inputLines)
        {
            Console.Write(addRemoveCollection.Add(word) + " ");
        }

        Console.WriteLine();

        foreach (var word in inputLines)
        {
            Console.Write(myList.Add(word) + " ");
        }

        Console.WriteLine();
    }
}

