using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireBender:Bender
{
    public FireBender(string name, int power,double heatAggresion)
        : base(name, power)
    {
        this.HeatAggression = heatAggresion;
    }

    public double HeatAggression { get; private set; }

    public override string ToString()
    {
        return $"###Fire Bender: {Name}, Power: {Power}, Heat Aggression: {HeatAggression:f2}";
    }

    public override double GetPower()
    {
        return this.Power * this.HeatAggression;
    }
}

