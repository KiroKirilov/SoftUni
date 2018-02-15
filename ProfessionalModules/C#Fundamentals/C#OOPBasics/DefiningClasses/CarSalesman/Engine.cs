using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    public string Model { get; set; }
    public string Efficiency { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }

    public Engine(string model, string eff, string pwr, string displacement)
    {
        Model = model;
        Efficiency = eff;
        Power = pwr;
        Displacement = displacement;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Console.WriteLine($"  {Model}:");
        Console.WriteLine($"    Power: {Power}");
        Console.WriteLine($"    Displacement: {Displacement}");
        Console.Write($"    Efficiency: {Efficiency}");
        return sb.ToString();
    }
}

