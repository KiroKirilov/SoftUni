using System;
using System.Collections.Generic;
using System.Text;


public abstract class Person : IBuyer
{
    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public int Food { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public abstract void BuyFood();
}

