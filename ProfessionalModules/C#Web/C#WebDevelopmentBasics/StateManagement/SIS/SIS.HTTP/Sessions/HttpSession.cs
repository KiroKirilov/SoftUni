using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> sessionParameters;

        public HttpSession(string id)
        {
            if (id==null)
            {
                throw new ArgumentNullException();
            }

            this.Id = id;
            this.sessionParameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (string.IsNullOrWhiteSpace(name) || parameter==null)
            {
                throw new ArgumentNullException();
            }

            this.sessionParameters.Add(name, parameter);
        }

        public void ClearParameters()
        {
            this.sessionParameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            return this.sessionParameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            return this.sessionParameters.GetValueOrDefault(name, null);
        }
    }
}
