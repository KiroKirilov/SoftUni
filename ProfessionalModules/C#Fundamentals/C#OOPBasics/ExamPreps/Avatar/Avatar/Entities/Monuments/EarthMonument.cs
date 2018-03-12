using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EarthMonument:Monument
{
    public EarthMonument(string name, int affinity)
        : base(name)
    {
        this.EarthAffinity = affinity;
    }

    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }

    public int EarthAffinity { get; private set; }

    public override string ToString()
    {
        return $"###Earth Monument: {Name}, Earth Affinity: {EarthAffinity}";
    }
}

