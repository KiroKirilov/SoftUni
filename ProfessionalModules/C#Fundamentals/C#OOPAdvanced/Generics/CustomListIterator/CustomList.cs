using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T> : IEnumerable<T>
    where T:IComparable<T>
{
    private List<T> items;

    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        var item = this.items[index];
        this.items.RemoveAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var tempItem = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = tempItem;
    }

    public int CountGreaterThan(T element)
    {
        return this.items.Count(i => i.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }

    public void Sort()
    {
        this.items = this.items.OrderBy(i => i).ToList();
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, this.items);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

