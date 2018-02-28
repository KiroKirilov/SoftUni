using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Felime
{
    public string Breed { get; set; }

    public Cat(string name, string type, double weight, string livingRegion, string breed)
        : base(name, type, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
