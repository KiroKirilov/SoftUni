﻿using System;
using System.Collections.Generic;
using System.Text;

public class Writer : IWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
