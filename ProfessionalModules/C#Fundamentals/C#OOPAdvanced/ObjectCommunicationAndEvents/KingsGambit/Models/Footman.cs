using System;
using System.Collections.Generic;
using System.Text;


    public class Footman : IUnit
    {
        public string Name { get; private set; }

        public Footman(string name)
        {
            this.Name = name;
        }

        public void OnKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }

