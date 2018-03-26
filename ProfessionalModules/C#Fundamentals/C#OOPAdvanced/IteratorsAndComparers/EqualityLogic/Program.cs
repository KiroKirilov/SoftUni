using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var amountOfPeople = int.Parse(Console.ReadLine());

        var sorted = new SortedSet<Person>(new PersonComparer());
        var hash = new HashSet<Person>(new PersonEqualityComparer());

        for (int i = 0; i < amountOfPeople; i++)
        {
            var data = Console.ReadLine().Split(" ");
            var name = data[0];
            var age = int.Parse(data[1]);
            var person = new Person(name, age);
            sorted.Add(person);
            hash.Add(person);
        }

        Console.WriteLine(sorted.Count);
        Console.WriteLine(hash.Count);
    }
}

