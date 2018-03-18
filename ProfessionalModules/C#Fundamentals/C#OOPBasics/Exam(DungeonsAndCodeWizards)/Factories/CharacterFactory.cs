using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter( string factionStr, string charType, string name )
        {
            var validFaction = Enum.TryParse(typeof(Faction), factionStr, out object enumObj);

            if (!validFaction)
            {
                throw new ArgumentException($"Invalid faction \"{factionStr}\"!");
            }

            var faction = (Faction)enumObj;
            switch (charType)
            {
                case "Warrior":
                    return new Warrior(name, faction);

                case "Cleric":
                    return new Cleric(name, faction);

                default:
                    throw new ArgumentException($"Invalid character type \"{charType}\"!");
            }
        }
    }
}
