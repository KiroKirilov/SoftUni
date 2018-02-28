using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    public Mouse(string name, string type, double weight, string livingRegion)
        :base(name,type,weight,livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            this.FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine("Mouses are not eating that type of food!");
    }
}

