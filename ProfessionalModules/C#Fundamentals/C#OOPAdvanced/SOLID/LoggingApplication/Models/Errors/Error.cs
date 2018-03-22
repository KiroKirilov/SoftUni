using LoggingApplication.Contracts;
using LoggingApplication.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Models.Errors
{
    class Error : IError
    {
        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel ErrorLevel { get; }

        public Error(DateTime date, ErrorLevel errorLevel, string message)
        {
            this.DateTime = date;
            this.ErrorLevel = errorLevel;
            this.Message = message;
        }
    }
}
