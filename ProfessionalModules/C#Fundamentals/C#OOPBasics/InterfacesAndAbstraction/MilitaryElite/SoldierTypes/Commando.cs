using System;
using System.Collections.Generic;
using System.Text;


public class Commando : SpecialisedSoldier, ICommando
{
    public List<IMission> Missions { get; private set; }

    public Commando(string id, string firstName, string lastName, double salary, string corps, List<IMission> missions)
        :base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public void CompleteMission()
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Missions:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Missions)}");

        return sb.ToString().Trim();
    }
}

