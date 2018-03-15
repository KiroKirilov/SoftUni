using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PerformanceCar : Car
{
    public List<string> AddOns { get; private set; }

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, (horsepower*150)/100, acceleration, (suspension*75)/100, durability) //(X * 50) / 100
    {
        this.AddOns = new List<string>();
    }

    public override string ToString()
    {
        var addOnsString = "";

        if (AddOns.Count==0)
        {
            addOnsString = "Add-ons: None";
        }
        else
        {
            addOnsString = "Add-ons: " + String.Join(", ", AddOns);
        }

        return base.ToString()+Environment.NewLine+addOnsString;
    }

    public override void Tune(int index, string addOn)
    {
        var halfIndex = (index * 50) / 100;
        this.Horsepower += index;
        this.Suspension += halfIndex;
        this.AddOns.Add(addOn);
    }
}
