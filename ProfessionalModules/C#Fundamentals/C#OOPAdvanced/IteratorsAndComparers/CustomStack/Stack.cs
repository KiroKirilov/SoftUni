using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Stack<T> : IEnumerable<T>
{
    private List<T> list;

    public Stack()
    {
        this.list = new List<T>();
    }

    public void Push (params T[] itemsToPush)
    {
        foreach (var item in itemsToPush)
        {
            this.list.Add(item);
        }
    }

    public void Pop()
    {
        if (this.list.Count==0)
        {
            throw new InvalidOperationException("No elements");
        }
        this.list.RemoveAt(this.list.Count-1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.list.Count-1; i >=0; i--)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

