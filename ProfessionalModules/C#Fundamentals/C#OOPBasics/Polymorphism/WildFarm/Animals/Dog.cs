using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Mammal
{
    public Dog(string name, string type, double weight, string livingRegion)
           : base(name, type, weight, livingRegion,0.40)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
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
}

