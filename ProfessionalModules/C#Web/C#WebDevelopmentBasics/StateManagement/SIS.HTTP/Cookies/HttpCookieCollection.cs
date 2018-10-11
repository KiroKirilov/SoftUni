using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private const string HttpCookieStringSeparator = "; ";

        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie==null)
            {
                throw new ArgumentException();
            }

            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            if (key == null)
            {
                throw new ArgumentException();
            }

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (key == null)
            {
                throw new ArgumentException();
            }

            return this.cookies.GetValueOrDefault(key, null);
        }

        public bool HasCookies()
        {
            return this.cookies.Count > 0;
        }

        public override string ToString()
        {
            return string.Join(HttpCookieStringSeparator, this.cookies.Values);
        }
    }
}
