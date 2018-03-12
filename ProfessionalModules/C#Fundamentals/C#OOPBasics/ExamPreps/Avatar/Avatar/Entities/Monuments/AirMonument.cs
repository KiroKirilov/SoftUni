using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirMonument:Monument
{
    public AirMonument(string name,int affinity) 
        : base(name)
    {
        this.AirAffinity = affinity;
    }

    public int AirAffinity  { get; private set; }

    public override int GetAffinity()
    {
        return this.AirAffinity;
    }

    public override string ToString()
    {
        return $"###Air Monument: {Name}, Air Affinity: {AirAffinity}";
    }
}

