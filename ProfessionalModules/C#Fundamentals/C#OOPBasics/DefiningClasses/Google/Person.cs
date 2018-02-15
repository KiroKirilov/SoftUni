using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    public string Name { get; set; }
    public Car Car { get; set; }
    public Company Company { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Pokemon> Pokemon { get; set; }
    public List<Child> Children { get; set; }

    private Person()
    {
        Parents = new List<Parent>();
        Pokemon = new List<Pokemon>();
        Children = new List<Child>();
    }

    public Person(string name):this()
    {
        Name = name;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Name);
        sb.AppendLine("Company:");
        if (!(Company==null))
        {
            sb.AppendLine($"{Company.Name} {Company.Department} {Company.Salary:f2}");
        }

        sb.AppendLine("Car:");
        if (!(Car == null))
        {
            sb.AppendLine($"{Car.Model} {Car.Speed}");
        }

        sb.AppendLine("Pokemon:");
        if (!(Pokemon.Count == 0))
        {
            foreach (var pokemon in Pokemon)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
        }

        sb.AppendLine("Parents:");
        if (!(Parents.Count == 0))
        {
            foreach (var parent in Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
        }

        sb.AppendLine("Children:");
        if (!(Children.Count == 0))
        {
            foreach (var child in Children)
            {
                sb.AppendLine($"{child.Name} {child.Birthday}");
            }
        }

        return sb.ToString();
    }
}

