using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var amountOfPeople = int.Parse(Console.ReadLine());

        var people = new Dictionary<string,Person>();

        for (int i = 0; i < amountOfPeople; i++)
        {
            var data = Console.ReadLine().Split(' ');

            if (data.Length==3)
            {
                people.Add(data[0],new Rebel(data[0], int.Parse(data[1]), data[2]));
            }
            else
            {
                people.Add(data[0], new Citizen(data[0], int.Parse(data[1]), data[2], data[3]));
            }
        }

        var personWhoBoughtFood = "";

        while ((personWhoBoughtFood=Console.ReadLine())!="End")
        {
            if (people.ContainsKey(personWhoBoughtFood))
                people[personWhoBoughtFood].BuyFood();
        }

        Console.WriteLine(people.Sum(p=>p.Value.Food));
    }
}

