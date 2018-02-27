using System;
using System.Collections.Generic;
using System.Text;


public class AddCollection : IAddCollection
{
    public List<string> Items { get; }

    public AddCollection()
    {
        Items = new List<string>();
    }

    public int Add(string item)
    {
        this.Items.Add(item);
        return this.Items.Count - 1;
    }
}

