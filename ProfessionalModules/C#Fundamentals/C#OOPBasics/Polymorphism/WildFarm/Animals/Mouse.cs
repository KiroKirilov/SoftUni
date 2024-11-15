﻿using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    public Mouse(string name, string type, double weight, string livingRegion)
        : base(name, type, weight, livingRegion, 0.10)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Squeak");
    }

    public override void Eat(Food food)
    {
        if ((food is Vegetable)||(food is Fruit))
        {
            this.FoodEaten += food.Quantity;
            this.AnimalWeight += this.WeightIncrease * food.Quantity;
        }
        else
            Console.WriteLine($"{this.GetType()} does not eat {food.GetType()}!");
    }
}

