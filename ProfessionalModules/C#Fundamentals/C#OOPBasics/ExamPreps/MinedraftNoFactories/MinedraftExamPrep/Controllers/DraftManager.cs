﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;

    private Dictionary<string, Provider> providers;

    private double totalOreMined;

    private double totalEnergyStored;

    private string mode;

    private double percentMiningOre;

    private double percentEnergyUse;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = "Full";
        this.totalOreMined = 0;
        this.totalEnergyStored = 0;
        this.percentEnergyUse = 1;
        this.percentMiningOre = 1;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //•	RegisterHarvester {type} {id} {oreOutput} {energyRequirement}
        //RegisterHarvester Sonic { id} { oreOutput} { energyRequirement} { sonicFactor}
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        try
        {
            switch (type)
            {
                case "Sonic":
                    var sonicFactor = int.Parse(arguments[4]);
                    var sonicHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                    this.harvesters.Add(id,sonicHarvester);
                    return $"Successfully registered {type} Harvester - {id}";

                case "Hammer":
                    var hammerHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
                    this.harvesters.Add(id,hammerHarvester);
                    return $"Successfully registered {type} Harvester - {id}";

                default:
                    return "";
            }
        }
        catch (ArgumentException argEx)
        {
            return $"Harvester is not registered, because of it's {argEx.Message}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        try
        {
            switch (type)
            {
                case "Solar":
                    var solarProvider = new SolarProvider(id, energyOutput);
                    this.providers.Add(id, solarProvider);
                    return $"Successfully registered {type} Provider - {id}";

                case "Pressure":
                    var pressureProvider = new PressureProvider(id, energyOutput);
                    this.providers.Add(id, pressureProvider);
                    return $"Successfully registered {type} Provider - {id}";

                default:
                    return "";
            }
        }
        catch (ArgumentException argEx)
        {
            return $"Provider is not registered, because of it's {argEx.Message}";
        }
    }

    public string Day()
    {
        var producedToday=ProduceEnergy();
        var energyRequired = this.harvesters.Sum(h => h.Value.EnergyRequirement*this.percentEnergyUse);
        var minedToday = 0.0;

        if (energyRequired<=totalEnergyStored)
        {
            minedToday += this.harvesters.Sum(h => h.Value.OreOutput * this.percentMiningOre);
            this.totalOreMined += minedToday;
            this.totalEnergyStored -= energyRequired;
        }


        var output = new StringBuilder();

        output.AppendLine("A day has passed.");
        output.AppendLine($"Energy Provided: {producedToday}");
        output.AppendLine($"Plumbus Ore Mined: {minedToday}");

        return output.ToString().Trim();
    }

    private double ProduceEnergy()
    {
        var producedToday = 0.0;

        foreach (var provider in providers)
        {
            this.totalEnergyStored += provider.Value.EnergyOutput;
            producedToday += provider.Value.EnergyOutput;
        }

        return producedToday;
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        switch (mode)
        {
            case "Full":
                this.percentMiningOre = 1;
                this.percentEnergyUse = 1;
                break;

            case "Half":
                this.percentMiningOre = 0.5;
                this.percentEnergyUse = 0.6;
                break;

            case "Energy":
                this.percentEnergyUse = 0;
                this.percentMiningOre = 0;
                break;

            default:
                break;
        }
        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (providers.ContainsKey(id))
        {
            return providers[id].ToString();
        }
        else if (harvesters.ContainsKey(id))
        {
            return harvesters[id].ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalOreMined}");
        return sb.ToString().Trim();
    }


}
