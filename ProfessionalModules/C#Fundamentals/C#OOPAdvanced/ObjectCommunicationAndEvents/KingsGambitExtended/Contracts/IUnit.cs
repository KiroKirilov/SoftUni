using System;
using System.Collections.Generic;
using System.Text;


public interface IUnit
{
    string Name { get; }
    bool IsDead { get; }
    void OnKingAttack(object sender, EventArgs e);
    void OnUnderAttack(object sender, EventArgs ea);
    void OnUnderAttack();
}

