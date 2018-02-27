using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : Person, IIdentifiable, IBirthable
{
    public string Id { get; private set; }

    public string Birthdate { get; private set; }

    public Citizen(string name, int age, string id,string birthdate)
        :base(name,age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}

