using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Sessions;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        private const int RequestLineLength = 3;
        private const string CookieHeaderName = "Cookie";
        private const string CookiesSeparator = "; ";
        private const char CookieNameValueSeparator = '=';

        public HttpRequest(string requestString)
        {
            this.QueryData = new Dictionary<string, object>();
            this.FormData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(Environment.NewLine, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0]
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequest(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseRequestHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(CookieHeaderName))
            {
                return;
            }

            string cookiesString = this.Headers.GetHeader(CookieHeaderName).Value;

            if (string.IsNullOrEmpty(cookiesString))
            {
                return;
            }

            string[] allCookieInfo = cookiesString.Split(CookiesSeparator);
            foreach (string cookieInfo in allCookieInfo)
            {
                string[] cookieParts = cookieInfo.Split(CookieNameValueSeparator, StringSplitOptions.RemoveEmptyEntries);
                if (cookieParts.Length != 2)
                {
                    continue;
                }

                string key = cookieParts[0];
                string value = cookieParts[1];
                this.Cookies.Add(new HttpCookie(key, value, false));
            }
        }

        private void ParseRequestParameters(string formData, bool requestHasBody)
        {
            this.ParseQueryParameters();
            if (requestHasBody)
            {
                this.ParseFormData(formData);
            }
        }

        private void ParseFormData(string formData)
        {
            string[] bodyParameters = formData.Split('&', StringSplitOptions.RemoveEmptyEntries);
            this.ExtractRequestParameters(bodyParameters, this.FormData);
            
        }

        private void ParseQueryParameters()
        {
            string queryString = this.Url?
                .Split(new char[] { '?', '#' })
                .Skip(1)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }

            string[] queryParameters = queryString.Split('&', StringSplitOptions.RemoveEmptyEntries);
            this.ExtractRequestParameters(queryParameters, this.QueryData);
        }

        private void ParseRequestHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var headerInfo in requestHeaders)
            {
                if (string.IsNullOrWhiteSpace(headerInfo))
                {
                    return;
                }

                string[] splitRequestHeader = headerInfo.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string headerKey = splitRequestHeader[0];
                string headerValue = splitRequestHeader[1];
                HttpHeader header = new HttpHeader(headerKey, headerValue);
                this.Headers.Add(header);
            }
        }

        private void ParseRequestPath()
        {
            string path = this.Url.Split('?').FirstOrDefault();

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            string url = requestLine[1];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new BadRequestException();
            }

            this.Url = url;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            string requestMethodString = requestLine[0].Capitalize();
            bool validParse = Enum.TryParse<HttpRequestMethod>(requestMethodString, out HttpRequestMethod requestMethod);

            if (!validParse)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = requestMethod;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            bool result = !string.IsNullOrWhiteSpace(queryString) &&
                queryParameters.Length > 0;

            return result;
        }

        private bool IsValidRequest(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            bool result = requestLine.Length == RequestLineLength &&
                requestLine.Last() == GlobalConstants.HttpOneProtocolFragment;

            return result;
        }

        private void ExtractRequestParameters(string[] parameterkeyValuePairs, Dictionary<string, object> parameterCollection)
        {
            foreach (var parameterKeyValuePair in parameterkeyValuePairs)
            {
                string[] pairTokens = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (pairTokens.Length != 2)
                {
                    throw new BadRequestException();
                }

                string parameterKey = pairTokens[0];
                string parameterValue = pairTokens[1];
                if (parameterCollection.ContainsKey(parameterKey))
                {
                    parameterCollection[parameterKey] = parameterValue;
                }
                else
                {
                    parameterCollection.Add(parameterKey, parameterValue);
                }
            }
        }
    }
}
