using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Contracts
{
    interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}
