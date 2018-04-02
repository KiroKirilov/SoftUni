using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var weapons = new Dictionary<string, Weapon>();

        while ((input = Console.ReadLine()) != "END")
        {
            var cmdArgs = input.Split(';');
            var currentCommand = cmdArgs[0];

            switch (currentCommand)
            {
                case "Create":
                    var weaponTypeToCreate = cmdArgs[1];
                    var weaponNameToCreate = cmdArgs[2];
                    Weapon weapon = CreateWeapon(weaponTypeToCreate, weaponNameToCreate);
                    weapons.Add(weaponNameToCreate, weapon);
                    break;

                case "Add": //Add;Axe of Misfortune;0;Flawless Ruby
                    var weaponToAddTo = cmdArgs[1];
                    var indexToAddTo = int.Parse(cmdArgs[2]);
                    var gemInfo = cmdArgs[3];
                    Gem gemToAdd = CreateGem(gemInfo);
                    weapons[weaponToAddTo].AddGem(indexToAddTo, gemToAdd);
                    break;

                case "Remove"://Remove;{weapon name};{socket index}
                    var weaponToRemoveFrom = cmdArgs[1];
                    var indexToRemoveFrom = int.Parse(cmdArgs[2]);
                    weapons[weaponToRemoveFrom].RemoveGem(indexToRemoveFrom);
                    break;

                case "Print":
                    var nameToPrint = cmdArgs[1];
                    Console.WriteLine(weapons[nameToPrint].ToString());
                    break;

                default:
                    break;
            }
        }
    }

    private static Gem CreateGem(string gemInfoStr) //Flawless Ruby
    {
        var gemInfo = gemInfoStr.Split();
        var clarity = gemInfo[0];
        var type = gemInfo[1];

        switch (type)
        {
            case "Ruby":
                return new Ruby(clarity);

            case "Amethyst":
                return new Amethyst(clarity);

            case "Emerald":
                return new Emerald(clarity);

            default:
                throw new ArgumentException();
        }
    }

    private static Weapon CreateWeapon(string weaponTypeRaw, string weaponName)
    {
        var typeArgs = weaponTypeRaw.Split();
        var rarity = typeArgs[0];
        var weaponType = typeArgs[1];

        switch (weaponType)
        {
            case "Axe":
                return new Axe(weaponName, rarity);

            case "Knife":
                return new Knife(weaponName,rarity);

            case "Sword":
                return new Sword(weaponName,rarity);

            default:
                throw new ArgumentException();
        }
    }
}

