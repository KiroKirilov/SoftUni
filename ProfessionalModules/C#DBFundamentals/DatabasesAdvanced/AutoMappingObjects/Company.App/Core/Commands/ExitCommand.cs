using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.WriteLine("Program will now exit");
            Environment.Exit(0);
            return null;
        }
    }
}
