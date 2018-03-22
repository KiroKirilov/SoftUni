using LoggingApplication.Contracts;
using LoggingApplication.Enums;
using LoggingApplication.Models.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggingApplication.Factories
{
    class ErrorFactory
    {
        private const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string date, string errorLevelString, string message)
        {
            var dateTime = DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
            var errorLevel = this.ParseErrorLevel(errorLevelString);
            IError error = new Error(dateTime,errorLevel,message);

            return error;
        }

        private ErrorLevel ParseErrorLevel(string errorLvl)
        {
            try
            {
                var level = Enum.Parse(typeof(ErrorLevel), errorLvl);
                return (ErrorLevel)level;
            }
            catch (ArgumentException argEx)
            {
                throw new ArgumentException("Invalid error level.", argEx);
            }
        }
    }
}
