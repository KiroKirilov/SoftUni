using System;
using System.Collections.Generic;
using System.Text;


public class Threeuple<TItem1,TItem2,TItem3>
{
    public Threeuple(TItem1 item1, TItem2 item2,TItem3 item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public TItem1 Item1 { get; }

    public TItem2 Item2 { get; }

    public TItem3 Item3 { get; }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
    }
}

