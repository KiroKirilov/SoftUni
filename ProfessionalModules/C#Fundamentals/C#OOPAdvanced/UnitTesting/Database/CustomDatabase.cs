using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomDatabase
{
    private const int MaxCapacity = 16;
    private int[] items;
    private int count;

    public CustomDatabase()
    {
        this.items = new int[MaxCapacity];
        this.count = 0;
    }

    public CustomDatabase(params int[] items)
        : this()
    {
        if (items != null)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }
    }

    public int Count => this.count;

    public void Add(int item)
    {
        if (this.count == MaxCapacity)
        {
            throw new InvalidOperationException();
        }
        this.items[this.count] = item;
        this.count++;
    }

    public void Remove()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException();
        }
        this.count--;
    }

    public int[] Fetch()
    {
        return this.items.Take(this.count).ToArray();
    }
}
