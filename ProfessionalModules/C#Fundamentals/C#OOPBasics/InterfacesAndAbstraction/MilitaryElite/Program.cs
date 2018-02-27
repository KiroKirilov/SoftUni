using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<ISoldier> allSoldiers;
    static void Main(string[] args)
    {
        var input = "";

        allSoldiers = new List<ISoldier>();

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ');
            var soldierType = data[0];

            switch (soldierType.ToLower())
            {
                case "private":
                    allSoldiers.Add(new Private(data[1], data[2], data[3], double.Parse(data[4])));
                    break;
                case "spy":
                    allSoldiers.Add(new Spy(data[1], data[2], data[3], int.Parse(data[4])));
                    break;
                case "leutenantgeneral":
                    var soldiersUnderCtrl = GetSoldiersUnderControl(data.Skip(5).ToList());
                    allSoldiers.Add(new LeutenantGeneral(data[1], data[2], data[3], double.Parse(data[4]), soldiersUnderCtrl));
                    break;
                case "commando":
                    if (data[5] != "Airforces" && data[5] != "Marines")
                    {
                        break;
                    }
                    var missions = GetCommandoMissions(data.Skip(6).ToList());
                    allSoldiers.Add(new Commando(data[1], data[2], data[3], double.Parse(data[4]), data[5], missions));
                    break;
                case "engineer":
                    if (data[5] != "Airforces" && data[5] != "Marines")
                    {
                        break;
                    }
                    var repairs = GetEngineerRepairs(data.Skip(6).ToList());
                    allSoldiers.Add(new Engineer(data[1], data[2], data[3], double.Parse(data[4]), data[5], repairs));
                    break;
            }
        }

        foreach (var soldier in allSoldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static List<IRepair> GetEngineerRepairs(List<string> partsInput)
    {
        var listOfParts = new List<IRepair>();

        for (int i = 0; i < partsInput.Count - 1; i += 2)
        {
            listOfParts.Add(new Repair(partsInput[i], int.Parse(partsInput[i + 1])));
        }

        return listOfParts;
    }

    private static List<IMission> GetCommandoMissions(List<string> missionsInput)
    {
        var listOfMissions = new List<IMission>();

        for (int i = 0; i < missionsInput.Count - 1; i += 2)
        {
            if (missionsInput[i + 1] != "inProgress" && missionsInput[i + 1] != "Finished")
            {
                continue;
            }

            listOfMissions.Add(new Mission(missionsInput[i], missionsInput[i + 1]));
        }

        return listOfMissions;
    }

    private static List<ISoldier> GetSoldiersUnderControl(List<string> soldiersInput)
    {
        var listOfSoldiers = new List<ISoldier>();

        foreach (var soldier in soldiersInput)
        {
            listOfSoldiers.Add(allSoldiers.First(s => s.Id == soldier));
        }

        return listOfSoldiers;
    }
}

