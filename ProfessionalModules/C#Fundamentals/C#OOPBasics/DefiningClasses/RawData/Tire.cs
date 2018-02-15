using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    public double Age { get; set; }
    public double Pressure { get; set; }

    public Tire(double age, double pressure)
    {
        Age = age;
        Pressure = pressure;
    }
}

