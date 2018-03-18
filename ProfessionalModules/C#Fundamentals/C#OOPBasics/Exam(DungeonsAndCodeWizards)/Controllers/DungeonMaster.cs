using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Controllers
{
    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemPool;
        private int lastSurvivorRounds;
        private ItemFactory itemFactory;
        private CharacterFactory characterFactory;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            //   faction – a string
            //   characterType – string
            //   name – string
            var factionStr = args[0];
            var charType = args[1];
            var name = args[2];

            if (!party.Any(c => c.Name == name))
            {
                var character = characterFactory.CreateCharacter(factionStr, charType, name);

                this.party.Add(character);

                return $"{name} joined the party!";
            }
            return "";
        }



        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            var item = itemFactory.CreateItem(itemName);
            this.itemPool.Push(item);
            return $"{itemName} added to pool.";
        }


        public string PickUpItem(string[] args)
        {
            var charName = args[0];
            var character = this.party.FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            var item = this.itemPool.Pop();

            character.ReceiveItem(item);

            return $"{charName} picked up {item.Name}!";
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];

            var character = this.party.FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            character.Bag.RemoveItem(itemName);

            return $"{charName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);
            giver.Bag.RemoveItem(itemName);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);
            giver.Bag.RemoveItem(itemName);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var output = new StringBuilder();
            var orderedParty = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

            foreach (var c in orderedParty)
            {
                output.AppendLine(c.ToString());
            }
            return output.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attackerChar = party.FirstOrDefault(c => c.Name == attackerName);

            if (attackerChar == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            var receiver = party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(attackerChar is IAttackable))
            {
                throw new ArgumentException($"{attackerChar.Name} cannot attack!");
            }

            var attacker = (Warrior)attackerChar;
            attacker.Attack(receiver);

            // "{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points"
            var output = new StringBuilder();
            output.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            output.AppendLine($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.Health == 0)
            {
                output.AppendLine($"{receiver.Name} is dead!");
            }

            return output.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healerChar = party.FirstOrDefault(c => c.Name == healerName);

            if (healerChar == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            var receiver = party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (!(healerChar is IHealable))
            {
                throw new ArgumentException($"{healerChar.Name} cannot heal!");
            }

            var healer = (Cleric)healerChar;

            healer.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var output = new StringBuilder();

            var alive = this.party.Where(c => c.IsAlive).ToList();

            if (alive.Count == 0)
            {
                this.lastSurvivorRounds++;
                return "";
            }

            if (alive.Count == 1)
            {
                this.lastSurvivorRounds++;
            }

            foreach (var character in alive)
            {
                var hpBefore = character.Health;
                character.Rest();
                output.AppendLine($"{character.Name} rests ({hpBefore} => {character.Health})");
            }

            return output.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRounds>1)
            {
                return true;
            }

            return false;
        }

    }
}
