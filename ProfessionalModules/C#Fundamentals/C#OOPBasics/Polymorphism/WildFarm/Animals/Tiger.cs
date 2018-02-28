using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Felime
{
    public Tiger(string name, string type, double weight, string livingRegion)
        : base(name, type, weight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            this.FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine("Tigers are not eating that type of food!");
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }
}

