using System;
using System.Collections.Generic;
using System.Text;


public class Gem
{
    private int strength;
    private int agility;
    private int vitality;
    private GemClarity clarity;

    protected Gem(string clarity,int str,int agi,int vit)
    {
        this.strength = str;
        this.agility = agi;
        this.vitality = vit;
        this.clarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);
    }

    public Gem()
    {
        this.strength = 0;
        this.agility = 0;
        this.vitality = 0;
        this.clarity = GemClarity.Empty;
    }

    public int Strength => this.strength + (int)clarity;

    public int Vitality => this.vitality + (int)clarity;

    public int Agility => this.agility + (int)clarity;
}

