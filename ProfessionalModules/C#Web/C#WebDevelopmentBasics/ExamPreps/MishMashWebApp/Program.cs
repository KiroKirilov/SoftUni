using SIS.MvcFramework;
using System;

namespace MishMashWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
