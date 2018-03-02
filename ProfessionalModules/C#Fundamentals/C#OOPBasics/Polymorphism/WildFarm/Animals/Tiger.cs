using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Felime
{
    public Tiger(string name, string type, double weight, string livingRegion, string breed)
        : base(name, type, weight, livingRegion, breed, 1.00)
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
        Console.WriteLine("ROAR!!!");
    }
}

