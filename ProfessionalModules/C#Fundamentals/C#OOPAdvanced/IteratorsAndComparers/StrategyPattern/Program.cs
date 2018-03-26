using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var amountOfPeople = int.Parse(Console.ReadLine());

        var nameSet = new SortedSet<Person>(new NameComparer());
        var ageSet = new SortedSet<Person>(new AgeComparer());

        for (int i = 0; i < amountOfPeople; i++)
        {
            var data = Console.ReadLine().Split(" ");
            var name = data[0];
            var age = int.Parse(data[1]);
            var person = new Person(name, age);
            nameSet.Add(person);
            ageSet.Add(person);
        }

        foreach (var person in nameSet)
        {
            Console.WriteLine(person);
        }

        foreach (var person in ageSet)
        {
            Console.WriteLine(person);
        }
    }
}

