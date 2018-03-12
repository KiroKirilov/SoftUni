using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthBender : Bender
{
    public double GroundSaturation { get;private set; }

    public EarthBender(string name, int power,double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public override string ToString()
    {
        return $"###Earth Bender: {Name}, Power: {Power}, Ground Saturation: {GroundSaturation:f2}";
    }

    public override double GetPower()
    {
        return this.Power * this.GroundSaturation;
    }
}

