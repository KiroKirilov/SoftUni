using System;
using System.Collections.Generic;
using System.Text;


public abstract class Felime : Mammal
{
    public string Breed { get; set; }

    public Felime(string name, string type, double weight, string livingRegion,string breed,double weightIncr)
        :base(name,type,weight,livingRegion, weightIncr)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

