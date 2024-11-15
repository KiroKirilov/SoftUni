﻿using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Felime
{

    public Cat(string name, string type, double weight, string livingRegion, string breed)
        : base(name, type, weight, livingRegion,breed,0.30)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public override void Eat(Food food)
    {
        if ((food is Meat)||(food is Vegetable))
        {
            this.FoodEaten += food.Quantity;
            this.AnimalWeight += this.WeightIncrease*food.Quantity;
        }
        else
            Console.WriteLine($"{this.GetType()} does not eat {food.GetType()}!");
    }
}
