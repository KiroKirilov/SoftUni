using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int defaultWeight = 10;

        public ArmorRepairKit()
            : base(defaultWeight)
        {
            base.Name = "ArmorRepairKit";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.RestoreArmor();
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
