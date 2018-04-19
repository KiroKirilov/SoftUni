using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplierSpForce = 3.5;
    private const double BaseRegen = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => OverallSkillMiltiplierSpForce;

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double BaseRegenIncrease => BaseRegen;
}