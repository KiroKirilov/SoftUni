using System;
using System.Net;
using System.Text;

namespace ValidateURL
{
    class Program
    {
        private const string InvalidUrlMessage = "Invalid URL";

        static void Main(string[] args)
        {
            string encodedUrl = Console.ReadLine();
            string decodedUrl = WebUtility.UrlDecode(encodedUrl);
            Uri parsedUrl = new Uri(decodedUrl);
            string validationResult = GetUrlValidity(parsedUrl);
            Console.WriteLine(validationResult);
        }

        private static string GetUrlValidity(Uri parsedUrl)
        {
            bool mandatoryComponentsAreValid = CheckMandatoryUrlComponentsValidity(parsedUrl);

            StringBuilder builder = new StringBuilder();

            if (!mandatoryComponentsAreValid)
            {
                return InvalidUrlMessage;
            }

            builder.AppendLine($"Protocol: {parsedUrl.Scheme}")
                .AppendLine($"Host: {parsedUrl.Host}")
                .AppendLine($"Port: {parsedUrl.Port}")
                .AppendLine($"Path: {parsedUrl.LocalPath}");

            string optionalComponentsResult = GetUrlOptionalComponents(parsedUrl);
            builder.AppendLine(optionalComponentsResult);

            string result = builder.ToString().Trim();
            return result;
        }

        private static string GetUrlOptionalComponents(Uri parsedUrl)
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(parsedUrl.Query))
            {
                builder.AppendLine($"Query: {parsedUrl.Query.Substring(1)}");
            }

            if (!string.IsNullOrWhiteSpace(parsedUrl.Fragment))
            {
                builder.AppendLine($"Fragment: {parsedUrl.Fragment.Substring(1)}");
            }

            string result = builder.ToString().Trim();

            return result;
        }

        private static bool CheckMandatoryUrlComponentsValidity(Uri parsedUrl)
        {
            bool isValid = !string.IsNullOrWhiteSpace(parsedUrl.Scheme) &&
                !string.IsNullOrWhiteSpace(parsedUrl.Host) &&
                !string.IsNullOrWhiteSpace(parsedUrl.LocalPath) &&
                parsedUrl.IsDefaultPort;

            return isValid;
        }
    }
}
