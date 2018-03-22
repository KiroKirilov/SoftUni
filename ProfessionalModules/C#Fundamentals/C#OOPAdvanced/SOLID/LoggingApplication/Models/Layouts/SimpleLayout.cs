using LoggingApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggingApplication.Models.Layouts
{
    class SimpleLayout : ILayout
    {
        //date - level - message
        private const string format = "{0} - {1} - {2}";

        private const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            var date = error.DateTime.ToString(dateFormat, CultureInfo.InvariantCulture);
            var formattedError = string.Format(format, date, error.ErrorLevel.ToString(), error.Message);
            return formattedError;
        }
    }
}
