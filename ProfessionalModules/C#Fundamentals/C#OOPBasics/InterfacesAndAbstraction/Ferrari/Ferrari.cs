using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICar
{
    public string Model { get; private set; }

    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
        this.Model = "488-Spider";
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        //488-Spider/Brakes!/Zadu6avam sA!/Bat Giorgi
        return $"{this.Model}/{this.Brakes()}/{this.PushGasPedal()}/{this.Driver}";
    }
}

