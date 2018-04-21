using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(IList<string> args)
    {
        this.Arguments = args;
    }

    public IList<string> Arguments { get; }

    public abstract string Execute();
}

