using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Monument
{
    public string Name { get; private set; }

    public Monument(string name)
    {
        this.Name = name;
    }

    public abstract int GetAffinity();
}

