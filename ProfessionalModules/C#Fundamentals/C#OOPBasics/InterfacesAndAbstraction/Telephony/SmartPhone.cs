using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SmartPhone : ICallable, IBrowsable
{
    public void BrowseSite(string site)
    {
        if (IsSiteValid(site))
        {
            Console.WriteLine($"Browsing: {site}!");
        }
        else
        {
            Console.WriteLine("Invalid URL!");
        }
    }

    public void CallNumber(string number)
    {
        if (IsNumberValid(number))
        {
            Console.WriteLine($"Calling... {number}");
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
    }

    private bool IsSiteValid(string site)
    {
        if (site.Any(char.IsDigit))
            return false;

        return true;
    }

    private bool IsNumberValid(string number)
    {
        if (number.Any(char.IsLetter))
            return false;

        return true;
    }
}

