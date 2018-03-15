using System;
using System.Collections.Generic;
using System.Text;


public abstract class Unit
{
    public string Id { get;  private set; }

    protected Unit(string id)
    {
        Id = id;
    }

    public abstract string Type { get; }
}

