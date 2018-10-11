using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string stringToCapitalize)
        {
            if (string.IsNullOrWhiteSpace(stringToCapitalize))
            {
                return stringToCapitalize;
            }

            string capitalizedFirstLetter = stringToCapitalize[0].ToString().ToUpper();
            string restOfString = stringToCapitalize.Substring(1).ToLower();
            string result = capitalizedFirstLetter + restOfString;

            return result;
        }
    }
}
