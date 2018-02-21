using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (IsNameValid(value))
                name = value;
            else
                throw new ArgumentException("Name cannot be empty");
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        set
        {
            if (IsCostValid(value))
                money = value;
            else
                throw new ArgumentException("Money cannot be negative");

        }
    }

    private List<Product> shoppingBag;

    public IReadOnlyCollection<Product> ShoppingBag
    {
        get { return shoppingBag; }
    }

    private bool IsNameValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            return false;

        return true;
    }

    private bool IsCostValid(decimal cost)
    {
        if (cost < 0)
            return false;

        return true;

    }

    public Person()
    {
        shoppingBag = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        this.Name = name;
        this.Money = money;
    }

    public void AddItemToBag(Product product)
    {
        shoppingBag.Add(product);
        money -= product.Cost;
    }

    public bool CanPersonAffordItem (Product product)
    {
        if (product.Cost<=this.money)
        {
            return true;
        }

        return false;
    }
}

