using LoggingApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggingApplication.Models.Layouts
{
    class XmlLayout : ILayout
    {
        //<log>
        //    <date>3/31/2015 5:33:07 PM</date>
        //    <level>ERROR</level>
        //    <message>Error parsing request</message>
        //</log>

        private string format = "<log>" + Environment.NewLine +
                                        "    <date>{0}</date>" +Environment.NewLine +
                                        "    <level>{1}</level>" + Environment.NewLine +
                                        "    <message>{2}</message>" + Environment.NewLine +
                                "</log>";

        private const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            var date = error.DateTime.ToString(dateFormat, CultureInfo.InvariantCulture);
            var formattedError = string.Format(format, date, error.ErrorLevel.ToString(), error.Message);
            return formattedError;
        }
    }
}
