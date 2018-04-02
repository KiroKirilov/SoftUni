using System;
using System.Collections.Generic;
using System.Text;


public class Axe : Weapon
{
    private const int BaseMinDamage = 5;
    private const int BaseMaxDamage = 10;
    private const int BaseAmountOfSockets = 4;

    public Axe(string name,string rarity) 
        : base(name,rarity, BaseMinDamage, BaseMaxDamage, BaseAmountOfSockets)
    {
    }
}

