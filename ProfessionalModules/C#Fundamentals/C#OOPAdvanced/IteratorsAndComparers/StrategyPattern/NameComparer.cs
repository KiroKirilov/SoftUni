using System;
using System.Collections.Generic;
using System.Text;


public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var lengthDifference = x.Name.Length - y.Name.Length;
        if (lengthDifference!=0)
        {
            return lengthDifference;
        }

        var letterX = x.Name.ToLower()[0];
        var letterY = y.Name.ToLower()[0];

        return letterX.CompareTo(letterY);
    }
}

