using System;
using System.Collections.Generic;
using System.Text;


public class Cat
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int EarSize { get; set; }
    public int MeowDecibels { get; set; }
    public double FurLength { get; set; }

    public Cat(string name ,string type, string prop)
    {
        Name = name;
        Type = type;

        switch (type)
        {
            case "Siamese":
                EarSize = int.Parse(prop);
                break;

            case "StreetExtraordinaire":
                MeowDecibels = int.Parse(prop);
                break;

            case "Cymric":
                FurLength = double.Parse(prop);
                break;

            default:
                break;
        }
    }

    public override string ToString()
    {
        switch (Type)
        {
            case "Siamese":
                return $"{Type} {Name} {EarSize}";

            case "Cymric":
                return $"{Type} {Name} {FurLength:f2}";

            case "StreetExtraordinaire":
                return $"{Type} {Name} {MeowDecibels}";

            default:
                return "";
        }
    }
}

