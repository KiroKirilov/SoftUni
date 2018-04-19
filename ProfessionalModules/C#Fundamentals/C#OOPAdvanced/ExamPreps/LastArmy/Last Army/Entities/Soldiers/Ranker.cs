using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplierRanker = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => OverallSkillMiltiplierRanker;

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;
}