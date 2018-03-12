using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireMonument:Monument
{
    public FireMonument(string name, int affinity)
        : base(name)
    {
        this.FireAffinity = affinity;
    }

    public override int GetAffinity()
    {
        return this.FireAffinity;
    }

    public int FireAffinity { get; private set; }

    public override string ToString()
    {
        return $"###Fire Monument: {Name}, Fire Affinity: {FireAffinity}";
    }
}
