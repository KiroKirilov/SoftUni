using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    public int CompareTo(Person other)
    {
        if ((this.name.Equals(other.name)) && (this.age.Equals(other.age)) && (this.town.Equals(other.town)))
        {
            return 0;
        }

        return 1;
    }
}

