﻿using System;
using System.Collections.Generic;
using System.Text;


public class AddRemoveCollection :IAddRemoveCollection
{
    public List<string> Items { get; set; }

    public AddRemoveCollection()
    {
        this.Items = new List<string>();
    }

    public int Add(string item)
    {
        this.Items.Insert(0, item);
        return this.Items.IndexOf(item);
    }

    public string Remove()
    {
        var last = this.Items[this.Items.Count - 1];
        this.Items.Remove(last);
        return last;
    }
}

