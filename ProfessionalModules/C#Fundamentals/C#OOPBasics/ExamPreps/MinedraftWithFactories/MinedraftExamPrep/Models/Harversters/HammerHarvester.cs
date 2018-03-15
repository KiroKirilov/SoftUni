using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOut, double energyReq)
        : base(id, oreOut * 3, energyReq * 2)
    {
    }

    public override string Type { get => "Hammer"; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();
    }
}