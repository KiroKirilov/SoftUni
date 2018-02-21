using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{
    const int BASE_CALS_PER_GRAM = 2;
    private string type;

    private string Type
    {
        get { return type; }
        set
        {
            if (IsTypeValid(value.ToLower()))
                type = value;
            else
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        }
    }

    private bool IsTypeValid(string val)
    {
        return val == "meat" || val == "veggies" || val == "cheese" || val == "sauce";
    }

    private int weight;

    private int Weight
    {
        get { return weight; }
        set
        {
            if (IsWeightValid(value))
                weight = value;
            else
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
        }
    }

    private bool IsWeightValid(int value)
    {
        return value > 0 && value <= 50;
    }

    public double CalculateCalories()
    {
        var typeModifier = GetTypeModifier();
        var calories = weight * typeModifier;

        return calories;
    }

    private double GetTypeModifier()
    {
        var modifier = (double) BASE_CALS_PER_GRAM;

        switch (type.ToLower())
        {
            case "meat":
                modifier *= 1.2;
                break;

            case "veggies":
                modifier *= 0.8;
                break;

            case "cheese":
                modifier *= 1.1;
                break;

            case "sauce":
                modifier *= 0.9;
                break;

            default:
                break;
        }
        return modifier;
    }

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }
}

