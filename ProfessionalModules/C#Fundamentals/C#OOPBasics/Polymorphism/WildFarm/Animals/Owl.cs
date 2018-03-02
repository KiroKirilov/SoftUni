using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public Owl(string name, string type, double weight, double wingsize)
        : base(name, type, weight, wingsize, 0.25)
    {
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            this.FoodEaten += food.Quantity;
            this.AnimalWeight += this.WeightIncrease * food.Quantity;
        }
        else
            Console.WriteLine($"{this.GetType()} does not eat {food.GetType()}!");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}

