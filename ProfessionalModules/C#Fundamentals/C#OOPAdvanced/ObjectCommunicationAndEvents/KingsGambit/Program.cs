using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var kingName = Console.ReadLine();
        var king = new King(kingName);
        var units = new List<IUnit>();
        var royalGuardsNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var rgName in royalGuardsNames)
        {
            var royalGuard = new RoyalGuard(rgName);
            king.UnderAttack += royalGuard.OnKingAttack;
            units.Add(royalGuard);
        }

        var footmenNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var fmName in footmenNames)
        {
            var footman = new Footman(fmName);
            king.UnderAttack += footman.OnKingAttack;
            units.Add(footman);
        }

        var input = "";
        while ((input=Console.ReadLine())!="End")
        {
            var cmdArgs = input.Split();
            var command = cmdArgs[0];

            switch (command)
            {
                case "Kill":
                    var unitName = cmdArgs[1];
                    var unitToKill = units.FirstOrDefault(u => u.Name == unitName);
                    king.UnderAttack -= unitToKill.OnKingAttack;
                    units.Remove(unitToKill);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
                default:
                    break;
            }
        }
    }
}

