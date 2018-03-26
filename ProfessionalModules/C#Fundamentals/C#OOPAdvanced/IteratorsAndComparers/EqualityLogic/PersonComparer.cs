using System;
using System.Collections.Generic;
using System.Text;


public class PersonComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.CompareTo(y.Name);

        if (result==0)
        {
            result = x.Age.CompareTo(y.Age);
        }

        return result;
    }
}

