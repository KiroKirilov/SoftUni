using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WaterBender : Bender
{
    public WaterBender(string name, int power,double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; private set; }

    public override string ToString()
    {
        return $"###Water Bender: {Name}, Power: {Power}, Water Clarity: {WaterClarity:f2}";
    }

    public override double GetPower()
    {
        return this.Power * this.WaterClarity;
    }
}

