using System;
using System.Collections.Generic;
using System.Text;


public class King : IAttackable
{
    public event EventHandler UnderAttack;

    public string Name { get; set; }


    public King(string name)
    {
        this.Name = name;
    }
    public void GetAttacked()
    {
        throw new NotImplementedException();
    }

    public void OnUnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        UnderAttack?.Invoke(this, new EventArgs());
    }
}

