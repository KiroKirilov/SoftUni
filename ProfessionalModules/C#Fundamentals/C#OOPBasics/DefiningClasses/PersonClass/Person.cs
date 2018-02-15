using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }

    public int Age {
        get { return age; }
        set
        {
            age = value;
        }
    }

    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int personAge)
    {
        name = "No name";
        age = personAge;
    }

    public Person(string personName,int personAge)
    {
        name = personName;
        age = personAge;
    }
}

