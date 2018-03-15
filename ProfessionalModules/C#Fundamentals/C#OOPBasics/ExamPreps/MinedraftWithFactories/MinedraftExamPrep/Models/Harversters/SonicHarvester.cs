using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOut, double energyReq,int sonicFac)
        :base(id,oreOut, energyReq/sonicFac)
    {
        this.sonicFactor = sonicFac;
    }

    public override string Type { get => "Sonic"; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();
    }
}

