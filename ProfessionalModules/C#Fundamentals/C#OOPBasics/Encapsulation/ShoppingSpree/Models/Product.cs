using System;
using System.Collections.Generic;
using System.Text;


public class Product
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (IsNameValid(value))
                name = value;
            else
                throw new ArgumentException("Name cannot be empty");
        }
    }

    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (IsCostValid(value))
                cost = value;
            else
                throw new ArgumentException("Money cannot be negative");
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    private bool IsNameValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            return false;

        return true;
    }

    private bool IsCostValid(decimal cost)
    {
        if (cost<0)
            return false;

        return true;
        
    }

    public override string ToString()
    {
        return Name;
    }
}

