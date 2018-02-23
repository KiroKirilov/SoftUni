using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public virtual string Name
    {
        get { return name; }
        protected set
        {
            if (value.Length < 3)
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            else
                name = value;
        }
    }

    private int age;

    public virtual int Age
    {
        get { return age; }
        protected set
        {
            if (value < 0)
                throw new ArgumentException("Age must be positive!");
            else
                age = value;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
        return stringBuilder.ToString();
    }
}

