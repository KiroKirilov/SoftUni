﻿using System;

public class Chicken
{
    private const int MinAge = 0;
    private const int MaxAge = 15;

    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (IsNameValid(value))
                this.name = value;
            else
                throw new ArgumentException("Name cannot be empty.");
        }
    }

    private bool IsNameValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name == string.Empty)
            return false;

        return true;
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        set
        {
            if (IsAgeValid(value))
                this.age = value;
            else
                throw new ArgumentException("Age should be between 0 and 15.");
        }
    }

    private bool IsAgeValid(int age)
    {
        if (age>0 && age<=15)
            return true;

        return false;
    }

    public double ProductPerDay
    {
        get
        {
            return this.CalculateProductPerDay();
        }
    }

    private double CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }
}

