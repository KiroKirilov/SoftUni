using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var initialColors = Console.ReadLine().Split().ToList();
        var trafficLights = initialColors.Select(t => new TrafficLight(t)).ToList();
        var amountOfChanges = int.Parse(Console.ReadLine());

        for (int i = 0; i < amountOfChanges; i++)
        {
            foreach (var light in trafficLights)
            {
                light.ChangeColor();
            }

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}

