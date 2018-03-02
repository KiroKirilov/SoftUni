using System;
using System.Collections.Generic;
using System.Text;


public abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    public Mammal(string name,string type,double weight, string livingRegion, double weightIncr)
        :base(name,type,weight,weightIncr)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{this.GetType()} [{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

