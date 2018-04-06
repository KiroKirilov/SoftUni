using System;
using System.Collections.Generic;
using System.Text;

public interface ICustomDateTime
{
    DateTime Now();

    void AddDays(DateTime date, double daysToAdd);

    TimeSpan SubstractDays(DateTime date, double daysToSybstract);
}