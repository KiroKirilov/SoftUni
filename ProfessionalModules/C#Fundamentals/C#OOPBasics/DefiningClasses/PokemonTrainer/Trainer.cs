using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Trainer
{
    public string Name { get; set; }
    public int AmountOfBadges { get; set; }
    public List<Pokemon> Pokemon { get; set; }

    public Trainer(string name)
    {
        Name = name;
        AmountOfBadges = 0;
        Pokemon = new List<Pokemon>();
    }

    public bool ContainsType(string type)
    {
        if (Pokemon.Any(x=>x.Element==type))
        {
            return true;
        }
        return false;
    }

    public void DecreaseHelth()
    {
        for (int i = 0; i < Pokemon.Count; i++)
        {
            Pokemon[i].Health -= 10;
        }
    }

    public void RemoveDead()
    {
        Pokemon = Pokemon.Where(p => p.Health > 0).ToList();
    }
}

