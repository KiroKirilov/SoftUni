﻿using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{
    private const int BaseStrength = 7;
    private const int BaseAgility = 2;
    private const int BaseVitality = 5;

    public Ruby(string clarity) 
        : base(clarity, BaseStrength, BaseAgility, BaseVitality)
    {
    }
}