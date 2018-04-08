using System;
using System.Collections.Generic;
using System.Text;


public interface IUnit
{
    string Name { get; }
    void OnKingAttack(object sender, EventArgs e);
}

