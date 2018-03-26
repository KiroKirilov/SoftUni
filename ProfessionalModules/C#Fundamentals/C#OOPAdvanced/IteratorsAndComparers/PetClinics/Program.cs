using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var amountOfCommands = int.Parse(Console.ReadLine());
        var pets = new List<Pet>();
        var clinics = new List<Clinic>();

        for (int i = 0; i < amountOfCommands; i++)
        {
            var cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var currentCommand = cmdArgs[0];
            cmdArgs.RemoveAt(0);

            switch (currentCommand)
            {
                case "Create":
                    var thingToCreate = cmdArgs[0];
                    var name = cmdArgs[1];
                    var num = int.Parse(cmdArgs[2]);
                    if (thingToCreate=="Pet")
                    {
                        var kind = cmdArgs[3];
                        pets.Add(new Pet(name, num, kind));
                    }
                    if (thingToCreate=="Clinic")
                    {
                        clinics.Add(new Clinic(name, num));
                    }
                    break;

                case "Add":
                    var petNameToAdd = cmdArgs[0];
                    var clinicNameToAdd = cmdArgs[1];
                    Console.WriteLine(clinics.First(c=>c.Name==clinicNameToAdd).Add(pets.First(p=>p.Name==petNameToAdd)));
                    break;

                case "Release":
                    var clinicToReleaseFrom = cmdArgs[0];
                    Console.WriteLine(clinics.First(c=>c.Name==clinicToReleaseFrom).Release());
                    break;

                case "HasEmptyRooms":
                    var clinictoCheck = cmdArgs[0];
                    Console.WriteLine(clinics.First(c => c.Name == clinictoCheck).HasEmptyRooms());
                    break;

                case "Print":
                    var clinicToPrint = cmdArgs[0];

                    if (cmdArgs.Count==1)
                    {
                        clinics.First(c => c.Name == clinicToPrint).Print();
                    }
                    if (cmdArgs.Count>1)
                    {
                        var roomdIdToPrint = int.Parse(cmdArgs[1]);
                        clinics.First(c => c.Name == clinicToPrint).Print(roomdIdToPrint);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

