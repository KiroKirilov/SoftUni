﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2k__1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 1;

            do
            {
                Console.WriteLine(num);
                num *= 2;
                num += 1;
            } while (n >= num);
        }
    }
}