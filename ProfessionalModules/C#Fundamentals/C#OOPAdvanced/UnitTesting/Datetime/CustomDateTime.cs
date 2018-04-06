using System;
using System.Collections.Generic;
using System.Text;

public class CustomDateTime : ICustomDateTime
{
    public void AddDays(DateTime date, double daysToAdd)
    {
        date.AddDays(daysToAdd);
    }

    public DateTime Now()
    {
        return DateTime.Now;
    }

    public TimeSpan SubstractDays(DateTime date, double daysToSybstract)
    {
        return date.Subtract(DateTime.Parse($"{daysToSybstract}", System.Globalization.CultureInfo.InvariantCulture));
    }
}
