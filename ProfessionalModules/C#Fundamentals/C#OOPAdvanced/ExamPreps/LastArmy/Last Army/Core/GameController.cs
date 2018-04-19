using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private IWriter writer;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    
    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(army,wareHouse);
        this.missionFactory = new MissionFactory();
        this.soldierFactory = new SoldierFactory();
        this.writer = writer;
    }


    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1]=="Regenerate")
            {
                this.army.RegenerateTeam(data[2]);
            }
            else
            {
                ISoldier soldier = soldierFactory.CreateSoldier(
                    data[1], data[2], int.Parse(data[3]),
                    double.Parse(data[4]), double.Parse(data[5]));
                if (wareHouse.TryEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(
                       string.Format(OutputMessages.NoWeaponForSoldier, data[1], data[2]));
                }
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wareHouse.AddAmmo(name, number);
        }
        else if (data[0].Equals("Mission"))
        {
            IMission mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));
            writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        missionController.FailMissionsOnHold();
        writer.AppendLine("Results:");
        writer.AppendLine(string.Format(OutputMessages.SuccessfullMissions, missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.FailedMissions, missionController.FailedMissionCounter));
        writer.AppendLine("Soldiers:");
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }
    }
}
