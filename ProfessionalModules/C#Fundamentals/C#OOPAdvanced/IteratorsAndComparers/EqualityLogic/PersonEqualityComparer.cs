using System;
using System.Collections.Generic;
using System.Text;


public class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        bool areEqual = x.Name.Equals(y.Name);

        if (areEqual)
        {
            areEqual = x.Age.Equals(y.Age);
        }

        return areEqual;
    }

    public int GetHashCode(Person obj)
    {
        return obj.Name.GetHashCode() + obj.Age.GetHashCode();
    }
}

