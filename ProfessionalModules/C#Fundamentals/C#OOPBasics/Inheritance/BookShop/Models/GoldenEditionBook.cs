using System;
using System.Collections.Generic;
using System.Text;


public class GoldenEditionBook:Book
{
    public override decimal Price
    {
        get => base.Price * 1.3m;
        
    }

    public GoldenEditionBook(string author, string title, decimal price)
        :base(author,title,price)
    {
    }
}

