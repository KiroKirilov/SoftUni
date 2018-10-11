using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        private const string ResponseLineFormat = "{0} {1}";

        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            string responseLine = string.Format(ResponseLineFormat, (int)statusCode, statusCode.ToString());
            return responseLine;
        }
    }
}
