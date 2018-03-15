using System;
using System.Collections.Generic;
using System.Text;


public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "Solar":
                var solarProvider = new SolarProvider(id, energyOutput);
                return solarProvider;
                //this.providers.Add(id, solarProvider);
                //return $"Successfully registered {type} Provider - {id}";

            case "Pressure":
                var pressureProvider = new PressureProvider(id, energyOutput);
                return pressureProvider;
                //this.providers.Add(id, pressureProvider);
                //return $"Successfully registered {type} Provider - {id}";

            default:
                throw new InvalidOperationException();
        }
    }
}

