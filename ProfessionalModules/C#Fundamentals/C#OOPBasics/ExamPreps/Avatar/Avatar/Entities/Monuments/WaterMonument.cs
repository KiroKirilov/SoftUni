using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WaterMonument:Monument
{
    public WaterMonument(string name, int affinity)
        : base(name)
    {
        this.WaterAffinity = affinity;
    }

    public int WaterAffinity { get; private set; }

    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        return $"###Water Monument: {Name}, Water Affinity: {WaterAffinity}";
    }
}

