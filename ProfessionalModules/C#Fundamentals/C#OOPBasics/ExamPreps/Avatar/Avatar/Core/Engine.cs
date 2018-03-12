using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    

public class Engine
{
    public void Run()
    {
        var nb = new NationsBuilder();
        var inProgress = true;
        while (inProgress)
        {
            var commandArgs = Console.ReadLine().Split(' ').ToList();
            var currentCommand = commandArgs[0];
            commandArgs.RemoveAt(0);

            switch (currentCommand)
            {
                case "Bender":
                    nb.AssignBender(commandArgs);
                    break;

                case "Monument":
                    nb.AssignMonument(commandArgs);
                    break;

                case "Status":
                    var statusNation = commandArgs[0];
                    Console.WriteLine(nb.GetStatus(statusNation));
                    break;

                case "War":
                    var warNation = commandArgs[0];
                    nb.IssueWar(warNation);
                    break;

                case "Quit":
                    Console.WriteLine(nb.GetWarsRecord());
                    inProgress = false;
                    break;
            }
        }
    }
}

