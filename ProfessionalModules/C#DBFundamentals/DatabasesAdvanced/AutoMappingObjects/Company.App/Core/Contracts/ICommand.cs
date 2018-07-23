using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
