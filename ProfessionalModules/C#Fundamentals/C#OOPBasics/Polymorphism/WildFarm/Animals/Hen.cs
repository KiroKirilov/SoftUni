using System;
using System.Collections.Generic;
using System.Text;


public class Hen : Bird
{
    public Hen(string name, string type, double weight, double wingsize)
        : base(name, type, weight,wingsize ,0.35)
    {
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.AnimalWeight += this.WeightIncrease * food.Quantity;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Cluck");
    }
}

