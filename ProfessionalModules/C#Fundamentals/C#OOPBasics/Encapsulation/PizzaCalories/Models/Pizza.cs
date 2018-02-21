using System;
using System.Collections.Generic;
using System.Text;


public class Pizza
{
    private string name;

    private string Name
    {
        get { return name; }
        set
        {
            if (IsNameValid(value))
                name = value;
            else
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
    }

    private bool IsNameValid(string value)
    {
        if (value?.Length>0 && value?.Length<=15)
        {
            return true;
        }

        return false;
    }

    private Dough dough;

    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    private List<Topping> toppings;

    private IReadOnlyCollection<Topping> Toppings
    {
        get { return toppings; }
    }

    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    public void AddTopping(Topping top)
    {
        if (EnoughRoom())
        {
            toppings.Add(top);
        }
        else
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    private bool EnoughRoom()
    {
        if (Toppings.Count==10)
        {
            return false;
        }

        return true;
    }

    private double CalculateCalories()
    {
        var totalCals = dough.CalculateCalories();

        foreach (var top in toppings)
        {
            totalCals += top.CalculateCalories();
        }

        return totalCals;
    }

    public override string ToString()
    {
        return $"{Name} - {CalculateCalories():f2} Calories.";
    }
}

