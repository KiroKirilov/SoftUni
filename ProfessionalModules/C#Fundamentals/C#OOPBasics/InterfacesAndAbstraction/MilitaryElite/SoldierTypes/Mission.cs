using System;
using System.Collections.Generic;
using System.Text;


public class Mission : IMission
{
    public string Name { get; private set; }

    public string State { get; private set; }

    public Mission(string name, string state)
    {
        this.Name = name;
        this.State = state;
    }

    public override string ToString()
    {
        return $"Code Name: {this.Name} State: {this.State}";
    }
}

