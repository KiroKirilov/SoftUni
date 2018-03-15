using System;
using System.Collections.Generic;
using System.Text;


public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            case "Sonic":
                var sonicFactor = int.Parse(arguments[4]);
                var sonicHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                return sonicHarvester;
                //this.harvesters.Add(id, sonicHarvester);
                //return $"Successfully registered {type} Harvester - {id}";

            case "Hammer":
                var hammerHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
                return hammerHarvester;
                //this.harvesters.Add(id, hammerHarvester);
                //return $"Successfully registered {type} Harvester - {id}";

            default:
                throw new InvalidOperationException();
        }
    }
}

