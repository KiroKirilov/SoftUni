using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
    public LightColors LightColor { get; set; }

    public TrafficLight(string lightColorString)
    {
        var lightColor =(LightColors) Enum.Parse(typeof(LightColors), lightColorString);
        this.LightColor = lightColor;
    }

    public void ChangeColor()
    {
        var intColor = (int)this.LightColor;
        intColor = (intColor + 1) % 3;
        this.LightColor =(LightColors)Enum.Parse(typeof(LightColors), intColor.ToString());
    }

    public override string ToString()
    {
        return $"{this.LightColor.ToString()}";
    }
}
