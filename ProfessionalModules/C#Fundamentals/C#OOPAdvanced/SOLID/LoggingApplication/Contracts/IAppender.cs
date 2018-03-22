using System;
using System.Collections.Generic;
using System.Text;
using LoggingApplication.Enums;

namespace LoggingApplication.Contracts
{
    interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorLevel { get; }

        void Append(IError error);
    }
}
