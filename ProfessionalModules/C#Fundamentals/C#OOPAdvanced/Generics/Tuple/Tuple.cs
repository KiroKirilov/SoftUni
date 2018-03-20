using System;
using System.Collections.Generic;
using System.Text;


public class Tuple<TItem1,TItem2>
{
    public Tuple(TItem1 item1, TItem2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public TItem1 Item1 { get; }

    public TItem2 Item2 { get; }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2}";
    }
}

