using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Nation
{
    public List<Bender> Benders { get; set; }
    public List<Monument> Monuments { get; set; }

    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public void AddBender(Bender b)
    {
        this.Benders.Add(b);
    }

    public void AddMonument(Monument m)
    {
        this.Monuments.Add(m);
    }

    public double GetTotalPower()
    {
        var bendersPower = this.Benders.Sum(b => b.GetPower());
        var monumentPower =(long)this.Monuments.Sum(m => m.GetAffinity());
        var bonusPower = (bendersPower / 100) * monumentPower;
        var totalPower = bendersPower + bonusPower;
        return totalPower;
    }
}

