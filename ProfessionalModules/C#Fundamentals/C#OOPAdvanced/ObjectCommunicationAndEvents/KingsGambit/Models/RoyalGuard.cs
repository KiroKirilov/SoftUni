using System;
using System.Collections.Generic;
using System.Text;


    public class RoyalGuard : IUnit
    {
        public string Name { get; private set; }

        public RoyalGuard(string name)
        {
            this.Name = name;
        }

        public void OnKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }

