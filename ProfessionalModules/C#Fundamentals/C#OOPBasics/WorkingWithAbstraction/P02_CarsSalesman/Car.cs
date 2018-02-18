using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, string weight, string color,Engine eng)
    {
        Model = model;
        Weight = weight;
        Color = color;
        Engine = eng;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        Console.WriteLine(Model+":");
        Console.WriteLine(Engine);
        Console.WriteLine($"  Weight: {Weight}");
        Console.Write($"  Color: {Color}");

        return sb.ToString();
    }
}

