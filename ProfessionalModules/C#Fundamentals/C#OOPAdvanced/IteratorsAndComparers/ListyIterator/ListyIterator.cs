using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> list;

    public ListyIterator(List<T> list)
    {
        this.list = list;
        this.currentIndex = 0;
    }

    private int currentIndex;

    public void Print()
    {
        if (this.list.Count == 0 || this.list == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.list[currentIndex]);
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.currentIndex++;
            return true;
        }
        return false;
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ",this.list));
    }

    public bool HasNext()
    {
        return this.currentIndex + 1 < this.list.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.list.Count==0 || this.list==null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        for (int i = 0; i < this.list.Count; i++)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

