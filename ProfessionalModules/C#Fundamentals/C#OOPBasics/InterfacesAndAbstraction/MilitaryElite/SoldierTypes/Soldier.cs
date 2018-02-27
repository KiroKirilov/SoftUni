using System;
using System.Collections.Generic;
using System.Text;


public abstract class Soldier : ISoldier
{
    public string Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Soldier(string id, string fName, string lName)
    {
        this.Id = id;
        this.FirstName = fName;
        this.LastName = lName;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}