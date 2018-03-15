using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Car
{
    public string Brand { get; private set; }

    public string Model { get; private set; }

    public int YearOfProduction { get; private set; }

    public int Horsepower { get; protected set; }

    public int Acceleration { get; protected set; }

    public int Suspension { get; protected set; }

    public int Durability { get; protected set; }

    public bool IsParked { get; set; }

    public List<int> Races { get; set; }

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.IsParked = false;
        this.Races = new List<int>();
    }

    public override string ToString()
    {
        //Porsche Carrera 2017
        //850 HP, 100 m / h in 4 s
        //450 Suspension force, 100 Durability

        var sb = new StringBuilder();

        sb.AppendLine($"{Brand} {Model} {YearOfProduction}");
        sb.AppendLine($"{Horsepower} HP, 100 m/h in {Acceleration} s");
        sb.AppendLine($"{Suspension} Suspension force, {Durability} Durability");

        return sb.ToString().Trim();
    }

    public abstract void Tune(int index, string addOn);
}

