using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirBender : Bender
{
    public AirBender(string name, int power,double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity  { get; private set; }

    public override double GetPower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"###Air Bender: {Name}, Power: {Power}, Aerial Integrity: {AerialIntegrity:f2}";
    }
}

