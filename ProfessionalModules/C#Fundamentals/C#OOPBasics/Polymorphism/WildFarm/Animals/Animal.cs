using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{
    public string AnimalName { get; set; }

    public string AnimalType { get; set; }

    public double AnimalWeight { get; set; }

    public int FoodEaten { get; set; }

    public virtual void MakeSound()
    {
        Console.WriteLine("Override me!");
    }

    public virtual void Eat(Food food)
    {

    }

    public Animal(string name, string type, double weight)
    {
        this.AnimalName = name;
        this.AnimalType = type;
        this.AnimalWeight = weight;
        this.FoodEaten = 0;
    }
}

