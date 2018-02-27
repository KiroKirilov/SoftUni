using System;
using System.Collections.Generic;
using System.Text;


public class Rebel : Person
{
    public string Group { get; set; }

    public Rebel(string name, int age, string group)
        :base(name,age)
    {
        this.Group = group;
    }

    public override void BuyFood()
    {
        this.Food += 5;
    }
}

