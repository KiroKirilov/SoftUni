using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Contracts
{
    interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
