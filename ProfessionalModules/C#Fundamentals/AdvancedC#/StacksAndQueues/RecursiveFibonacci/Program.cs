﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    static long[] fibonacci;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        fibonacci = new long[n];
        fibonacci[0] = 1;
        if (n > 1) fibonacci[1] = 1;
        Console.WriteLine(GetFibonacci(n - 1));
    }

    static long GetFibonacci(int n)
    {
        if (fibonacci[n] == 0)
            fibonacci[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        return fibonacci[n];
    }
}