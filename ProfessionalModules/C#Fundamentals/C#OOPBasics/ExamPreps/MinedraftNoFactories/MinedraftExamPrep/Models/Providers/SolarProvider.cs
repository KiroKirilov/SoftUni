using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOut)
        : base(id, energyOut)
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Solar Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().Trim();
    }
}