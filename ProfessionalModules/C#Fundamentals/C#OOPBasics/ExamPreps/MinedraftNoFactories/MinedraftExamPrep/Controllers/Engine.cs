using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    public void Run()
    {
        var dm = new DraftManager();
        var inProgress = true;

        while (inProgress)
        {
            var commandArgs = Console.ReadLine().Split(' ').ToList();
            var currentCommand = commandArgs[0];
            commandArgs.RemoveAt(0);

            switch (currentCommand)
            {
                case "RegisterHarvester":
                    Console.WriteLine(dm.RegisterHarvester(commandArgs));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(dm.RegisterProvider(commandArgs));
                    break;

                case "Mode":
                    Console.WriteLine(dm.Mode(commandArgs));
                    break;

                case "Check":
                    Console.WriteLine(dm.Check(commandArgs));
                    break;

                case "Day":
                    Console.WriteLine(dm.Day());
                    break;

                case "Shutdown":
                    Console.WriteLine(dm.ShutDown());
                    inProgress = false;
                    break;

                default:
                    break;
            }
        }
    }
}

