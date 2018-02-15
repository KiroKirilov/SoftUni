using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var peopleData = new Dictionary<string, Person>();

        while ((input=Console.ReadLine())!="End")


        {
            var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var personName = data[0];
            var propToSet = data[1];

            if (!peopleData.ContainsKey(personName))
            {
                peopleData.Add(personName,new Person(personName));
            }

            switch (propToSet)
            {
                case "car":
                    peopleData[personName].Car = new Car(data[2],data[3]);
                    break;

                case "company":
                    peopleData[personName].Company = new Company(data[2], data[3], double.Parse(data[4]));
                    break;

                case "parents":
                    peopleData[personName].Parents.Add(new Parent(data[2],data[3]));
                    break;

                case "children":
                    peopleData[personName].Children.Add(new Child(data[2], data[3]));
                    break;

                case "pokemon":
                    peopleData[personName].Pokemon.Add(new Pokemon(data[2], data[3]));
                    break;

                default:
                    break;
            }
        }

        var nameToPrint = Console.ReadLine();

        Console.WriteLine(peopleData[nameToPrint]);
    }
}

