using System;
using System.Collections.Generic;
using System.Text;


public abstract class Bird : Animal
{
    public double WingSize { get; set; }

    public Bird(string name, string type, double weight, double wingsize, double weightIncr)
        : base(name, type, weight, weightIncr)
    {
        this.WingSize = wingsize;
    }

    public override string ToString()
    {
        return $"{this.GetType()} [{this.AnimalName}, {this.WingSize}, {this.AnimalWeight}, {this.FoodEaten}]";
    }
}

