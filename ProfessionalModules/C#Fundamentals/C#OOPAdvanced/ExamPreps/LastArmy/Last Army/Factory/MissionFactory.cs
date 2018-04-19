using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);

        IMission mission = (IMission)Activator.CreateInstance(missionType, neededPoints);

        return mission;
    }
}

