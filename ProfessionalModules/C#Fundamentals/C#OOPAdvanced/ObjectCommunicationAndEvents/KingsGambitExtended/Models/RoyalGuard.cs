using System;
using System.Collections.Generic;
using System.Text;


public class RoyalGuard : IUnit
{
    private const int HitsToDie = 3;

    public event EventHandler UnderAttack;

    public string Name { get; private set; }

    public bool IsDead { get; private set; }

    public int HitsTaken { get; private set; }

    public RoyalGuard(string name)
    {
        this.Name = name;
        this.HitsTaken = 0;
        this.IsDead = false;
    }

    public void OnKingAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }

    public void OnUnderAttack(object sender, EventArgs ea)
    {
        this.UnderAttack?.Invoke(this, new EventArgs());
    }

    public void OnUnderAttack()
    {
        this.HitsTaken++;

        if (this.HitsTaken == HitsToDie)
        {
            IsDead = true;
        }
    }
}

