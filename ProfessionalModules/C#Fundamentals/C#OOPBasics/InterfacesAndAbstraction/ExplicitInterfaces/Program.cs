using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var citizens = new List<Citizen>();

        var input = "";

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ');
            var name = data[0];
            var country = data[1];
            var age = int.Parse(data[2]);

            citizens.Add(new Citizen(name, country, age));
        }

        foreach (var citizen in citizens)
        {
            IResident res = citizen;
            IPerson per = citizen;
            Console.WriteLine(per.GetName());
            Console.WriteLine(res.GetName());
        }
    }
}

