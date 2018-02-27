using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var enteredInCity = new List<IIdentifiable>();

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ');

            if (data.Length==2)
            {
                enteredInCity.Add(new Robot(data[0], data[1]));
            }
            else
            {
                enteredInCity.Add(new Citizen(data[0], int.Parse(data[1]), data[2]));
            }
        }

        var fakeSuffix = Console.ReadLine();

        foreach (var thingInCity in enteredInCity.Where(t=>t.Id.EndsWith(fakeSuffix)))
        {
            Console.WriteLine(thingInCity.Id);
        }

    }
}

