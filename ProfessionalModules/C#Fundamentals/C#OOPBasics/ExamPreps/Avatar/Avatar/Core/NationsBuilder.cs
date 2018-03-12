using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.wars = new List<string>();
        this.nations = new Dictionary<string, Nation>()
        {
            {"Fire",new Nation() },
            {"Water",new Nation() },
            {"Earth",new Nation() },
            {"Air",new Nation() }
        };
    }

    public void AssignBender(List<string> benderArgs)//	Bender {type} {name} {power} {secondaryParameter}
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var param = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Fire":
                nations[type].AddBender(new FireBender(name,power,param));
                break;

            case "Earth":
                nations[type].AddBender(new EarthBender(name, power, param));
                break;

            case "Air":
                nations[type].AddBender(new AirBender(name, power, param));
                break;

            case "Water":
                nations[type].AddBender(new WaterBender(name, power, param));
                break;

            default:
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)// Monument {type} {name} {affinity}
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Fire":
                nations[type].AddMonument(new FireMonument(name, affinity));
                break;

            case "Air":
                nations[type].AddMonument(new AirMonument(name, affinity));
                break;

            case "Earth":
                nations[type].AddMonument(new EarthMonument(name, affinity));
                break;

            case "Water":
                nations[type].AddMonument(new WaterMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        var output = new StringBuilder();

        output.AppendLine($"{nationsType} Nation");

        if (nations[nationsType].Benders.Count==0)
        {
            output.AppendLine("Benders: None");
        }
        else
        {
            output.AppendLine("Benders:");
            foreach (var bender in nations[nationsType].Benders)
            {
                output.AppendLine(bender.ToString());
            }
        }

        if (nations[nationsType].Monuments.Count == 0)
        {
            output.AppendLine("Monuments: None");
            
        }
        else
        {
            output.AppendLine("Monuments:");
            foreach (var monument in nations[nationsType].Monuments)
            {
                output.AppendLine(monument.ToString());
            }
        }

        return output.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);
        var winner = nations.Max(n=>n.Value.GetTotalPower());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPower()<winner)
            {
                nation.Value.Benders = new List<Bender>();
                nation.Value.Monuments = new List<Monument>();
            }
        }
    }

    public string GetWarsRecord()
    {
        var output = new StringBuilder();

        for (int i = 0; i < wars.Count; i++)
        {
            output.AppendLine($"War {i+1} issued by {wars[i]}");
        }

        return output.ToString().Trim();
    }

}

