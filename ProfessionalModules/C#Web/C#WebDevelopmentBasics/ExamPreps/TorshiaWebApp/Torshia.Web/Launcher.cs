﻿using SIS.Framework;

namespace Torshia.Web
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}