using System;
using System.Collections.Generic;
using System.Text;


public class Gandalf
{
    private int happinessPoints;

    public int HappinessPoints
    {
        get { return happinessPoints; }
        set { happinessPoints = value; }
    }

    public Gandalf()
    {
        HappinessPoints = 0;
    }

    public void EatFood(string food)
    {
        var pointTable = new Dictionary<string, int>();
        pointTable["cram"] = 2;
        pointTable["lembas"] = 3;
        pointTable["apple"] = 1;
        pointTable["melon"] = 1;
        pointTable["honeycake"] = 5;
        pointTable["mushrooms"] = -10;

        if (pointTable.ContainsKey(food))
        {
            HappinessPoints += pointTable[food];
        }
        else
        {
            HappinessPoints--;
        }
    }

    public string GetMood()
    {
        if (HappinessPoints > 15)
        {
            return "JavaScript";
        }
        if (HappinessPoints >= 1)
        {
            return "Happy";
        }
        if (HappinessPoints >= -5)
        {
            return "Sad";
        }

        return "Angry";
    }
}

