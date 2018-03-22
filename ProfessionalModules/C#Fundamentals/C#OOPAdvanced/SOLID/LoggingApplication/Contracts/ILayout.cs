using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Contracts
{
    interface ILayout
    {
        string FormatError(IError error);
    }
}
