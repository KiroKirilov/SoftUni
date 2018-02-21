using System;
using System.Collections.Generic;
using System.Text;


public class Dough
{
    const int BASE_CALS_PER_GRAM = 2;

    private string flourType;

    private string FlourType
    {
        get { return flourType; }
        set
        {
            if (IsFlourTypeValid(value.ToLower()))
                flourType = value;
            else
                throw new ArgumentException("Invalid type of dough.");
        }
    }

    private bool IsFlourTypeValid(string value)
    {
        return value == "white" || value == "wholegrain";
    }

    private string bakingTechnique;

    private string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (IsBakingTechValid(value.ToLower()))
                bakingTechnique = value;
            else
                throw new ArgumentException("Invalid type of dough.");
        }
    }

    private bool IsBakingTechValid(string value)
    {
        return value == "chewy" || value == "crispy" || value == "homemade";
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
                throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
    }

    private bool IsWeightValid(int value)
    {
        return value > 0 && value <= 200;
    }

    public double CalculateCalories()
    {
        var flourModifier = GetFlourModifier();
        var bakingModifier = GetBakingModifier();
        var totalCals = (BASE_CALS_PER_GRAM * weight) * flourModifier * bakingModifier;

        return totalCals;
    }

    private double GetBakingModifier()
    {
        var modifier = 0.0;

        switch (bakingTechnique.ToLower())
        {
            case "crispy":
                modifier = 0.9;
                break;

            case "chewy":
                modifier = 1.1;
                break;

            case "homemade":
                modifier = 1.0;
                break;

            default:
                break;
        }

        return modifier;
    }

    private double GetFlourModifier()
    {
        var modifier = 0.0;
        switch (flourType.ToLower())
        {
            case "white":
                modifier = 1.5;
                break;

            case "wholegrain":
                modifier = 1.0;
                break;

            default:
                break;
        }
        return modifier;
    }

    public Dough(string flour, string bake, int weight)
    {
        FlourType = flour;
        BakingTechnique = bake;
        Weight = weight;
    }
}

