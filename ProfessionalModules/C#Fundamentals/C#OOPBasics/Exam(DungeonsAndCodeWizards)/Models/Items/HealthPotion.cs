using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int defaultWeight = 5;
        private const double defaultHealAmount = 20;

        public HealthPotion() 
            : base(defaultWeight)
        {
            base.Name = "HealthPotion";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.GainHeal(defaultHealAmount);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
