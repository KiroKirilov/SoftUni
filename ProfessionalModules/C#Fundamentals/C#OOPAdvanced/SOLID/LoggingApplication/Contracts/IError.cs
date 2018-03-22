using LoggingApplication.Enums;
using System;

namespace LoggingApplication.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}