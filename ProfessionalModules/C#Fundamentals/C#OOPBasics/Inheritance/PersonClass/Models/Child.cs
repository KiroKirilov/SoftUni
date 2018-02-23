using System;
using System.Collections.Generic;
using System.Text;


public class Child:Person
{
    public override int Age
    {
        get { return base.Age; }
        protected set
        {
            if (value>15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            else
                base.Age = value;
        }
    }

    public Child(string name, int age)
        :base(name,age)
    {
    }
}

