using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var enteredInCity = new List<IBirthable>();

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ');
            var thingToAdd = data[0];

            switch (thingToAdd.ToLower())
            {
                case "pet":
                    enteredInCity.Add(new Pet(data[1], data[2]));
                    break;

                case "citizen":
                    enteredInCity.Add(new Citizen(data[1], int.Parse(data[2]),data[3],data[4]));
                    break;

                default:
                    break;
            }
        }

        var birthYear = Console.ReadLine();

        foreach (var thingInCity in enteredInCity.Where(t=>t.Birthdate.EndsWith(birthYear)))
        {
            Console.WriteLine(thingInCity.Birthdate);
        }

    }
}

