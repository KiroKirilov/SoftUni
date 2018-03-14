using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOut)
        : base(id, energyOut * 1.5)
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"“Pressure Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().Trim();
    }
}