using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars { get; private set; }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"{Stars} *";
    }

    public override void Tune(int index, string addOn)
    {
        var halfIndex = (index * 50) / 100;
        this.Horsepower += index;
        this.Suspension += halfIndex;
        this.Stars += index;
    }
}

