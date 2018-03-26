using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var same = 1;
        var different = 0;

        var input = "";

        var people = new List<Person>();

        while ((input = Console.ReadLine()) != "END")
        {
            var data = input.Split();
            var name = data[0];
            var age = int.Parse(data[1]);
            var town = data[2];
            people.Add(new Person(name, age, town));
        }
        var personIndex = int.Parse(Console.ReadLine());
        personIndex--;
        var person = people[personIndex];
        people.RemoveAt(personIndex);

        foreach (var otherPerson in people)
        {
            var result = person.CompareTo(otherPerson);
            if (result==0)
            {
                same++;
            }
            else
            {
                different++;
            }
        }

        if (same==1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{same} {different} {same+different}");
        }
    }
}

