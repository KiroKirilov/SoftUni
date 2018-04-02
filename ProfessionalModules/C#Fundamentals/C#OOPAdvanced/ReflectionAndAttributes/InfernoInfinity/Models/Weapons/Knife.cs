using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    private const int BaseMinDamage = 3;
    private const int BaseMaxDamage = 4;
    private const int BaseAmountOfSockets = 2;

    public Knife(string name, string rarity)
        : base(name,rarity, BaseMinDamage, BaseMaxDamage, BaseAmountOfSockets)
    {
    }
}
