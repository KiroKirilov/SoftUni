using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion:Item
    {
        private const int defaultWeight = 5;
        private const double defaultDamage = 20;

        public PoisonPotion()
            : base(defaultWeight)
        {
            base.Name = "PoisonPotion";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.TakeDirectDamage(defaultDamage);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
