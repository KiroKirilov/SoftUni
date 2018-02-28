using System;
using System.Collections.Generic;
using System.Text;


public class Zebra : Mammal
{
    public Zebra(string name, string type, double weight, string livingRegion)
           : base(name, type, weight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            this.FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine("Zebras are not eating that type of food!");
    }
}

