using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader httpHeader)
        {
            if (httpHeader == null ||
                string.IsNullOrWhiteSpace(httpHeader.Key) ||
                string.IsNullOrWhiteSpace(httpHeader.Value) ||
                this.headers.ContainsKey(httpHeader.Key))
            {
                throw new ArgumentException();
            }

            this.headers.Add(httpHeader.Key, httpHeader);
        }

        public bool ContainsHeader(string key)
        {
            bool result = this.headers.ContainsKey(key);

            return result;
        }

        public HttpHeader GetHeader(string key)
        {
            bool getHeaderResult = this.headers.TryGetValue(key, out HttpHeader header);

            if (getHeaderResult==false)
            {
                return null;
            }

            return header;
        }

        public override string ToString()
        {
            string result = string.Join(Environment.NewLine,this.headers.Values);
            return result;
        }
    }
}
