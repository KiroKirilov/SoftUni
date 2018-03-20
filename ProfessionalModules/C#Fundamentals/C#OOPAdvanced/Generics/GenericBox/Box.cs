using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public T Value { get; set; }

    public Box(T val)
    {
        this.Value = val;
    }

   

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

