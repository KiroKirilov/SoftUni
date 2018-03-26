using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LinkedList<T> : IEnumerable<T>
    where T: IComparable
{
    private List<T> list;

    public LinkedList()
    {
        this.list = new List<T>();
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public bool Remove(T element)
    {
        return this.list.Remove(element);
    }

    public int Count => this.list.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

