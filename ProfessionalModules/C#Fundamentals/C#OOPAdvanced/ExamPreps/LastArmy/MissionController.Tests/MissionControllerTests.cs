﻿using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void MissionControllerShouldDisplayFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }

    [Test]
    public void MissionControllerShouldDisplaySuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);
        string result = missionController.PerformMission(mission);

        Assert.IsTrue(result.StartsWith("Mission completed - Suppression of civil rebellion"));
    }
}