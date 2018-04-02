using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    private const int BaseMinDamage = 4;
    private const int BaseMaxDamage = 6;
    private const int BaseAmountOfSockets = 3;

    public Sword(string name, string rarity)
        : base(name,rarity, BaseMinDamage, BaseMaxDamage, BaseAmountOfSockets)
    {
    }
}
