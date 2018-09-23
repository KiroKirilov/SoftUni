using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RequestParser
{
    class Program
    {
        private const string EndCommand = "END";
        private const char PathSeparator = '/';
        private const char RequestSeparator = ' ';

        static void Main(string[] args)
        {
            // The key is the url itself and the hashset contains the allowed methods
            Dictionary<string, HashSet<string>> validPaths = ReadValidPaths();
            string processResult=ProcessRequest(validPaths);
            Console.WriteLine(processResult);
        }

        private static string ProcessRequest(Dictionary<string, HashSet<string>> validPaths)
        {
            string fullRequest = Console.ReadLine();
            string[] tokens = fullRequest.Split(RequestSeparator, StringSplitOptions.RemoveEmptyEntries);
            string requestedMethod = tokens[0].ToLower();
            string requestedUrl = tokens[1];
            string requestProtocol = tokens[2];

            bool isRequestValid = validPaths.ContainsKey(requestedUrl) &&
                validPaths[requestedUrl].Contains(requestedMethod);

            HttpStatusCode statusCode = HttpStatusCode.NotFound;

            if (isRequestValid)
            {
                statusCode = HttpStatusCode.OK;
            }

            var builder = new StringBuilder();
            builder
                .AppendLine($"{requestProtocol} {(int)statusCode} {statusCode.ToString()}")
                .AppendLine($"Content-Length: {statusCode.ToString().Length}")
                .AppendLine($"Content-Type: text/plain")
                .AppendLine()
                .AppendLine(statusCode.ToString());

            string result = builder.ToString().Trim();

            return result;
        }

        private static Dictionary<string, HashSet<string>> ReadValidPaths()
        {
            Dictionary<string, HashSet<string>> validPaths = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != EndCommand)
            {
                string[] tokens = input.Split(PathSeparator, StringSplitOptions.RemoveEmptyEntries);
                string partialPath = tokens[0];
                string method = tokens[1].ToLower();
                string fullPath = PathSeparator + partialPath;

                if (!validPaths.ContainsKey(fullPath))
                {
                    validPaths[fullPath] = new HashSet<string>();
                }

                validPaths[fullPath].Add(method);
            }

            return validPaths;
        }
    }
}
