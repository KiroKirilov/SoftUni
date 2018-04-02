using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Weapon
{
    private int minDamage;
    private int maxDamage;
    private Gem[] gems;
    private WeaponRarity rarity;
    private string name;

    protected Weapon(string name,string rarity, int minDmg, int maxDmg, int amountOfSockets)
    {
        this.name = name;
        this.minDamage = minDmg;
        this.maxDamage = maxDmg;
        this.gems = new Gem[amountOfSockets];
        for (int i = 0; i < gems.Length; i++)
        {
            gems[i] = new Gem();
        }
        this.rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), rarity);
    }

    public int Strength => this.gems.Sum(g => g.Strength);
    public int Agility => this.gems.Sum(g => g.Agility);
    public int Vitality => this.gems.Sum(g => g.Vitality);

    public void AddGem(int index,Gem gem)
    {
        if (index>=0 && index<this.gems.Length)
        {
            this.gems[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.gems.Length)
        {
            this.gems[index] = new Gem();
        }
    }

    public int GetMinDamage()
    {
        var totalMinDamage = 0;

        totalMinDamage = this.minDamage * (int)this.rarity;
        totalMinDamage += 2 * this.Strength;
        totalMinDamage += this.Agility;

        return totalMinDamage;
    }

    public int GetMaxDamage()
    {
        var totalMaxDamage = 0;

        totalMaxDamage = this.maxDamage * (int)this.rarity;
        totalMaxDamage += 3 * this.Strength;
        totalMaxDamage += 4 * this.Agility;

        return totalMaxDamage;
    }

    public override string ToString()
    {
        //"{weapon's name}: {min damage}-{max damage} Damage, +{points} Strength, +{points} Agility, +{points} Vitality"
        return $"{this.name}: {this.GetMinDamage()}-{this.GetMaxDamage()} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}
