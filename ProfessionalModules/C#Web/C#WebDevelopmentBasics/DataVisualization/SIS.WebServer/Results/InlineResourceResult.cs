using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Results
{
    public class InlineResourceResult : HttpResponse
    {
        public InlineResourceResult(byte[] content,HttpResponseStatusCode responseStatusCode) 
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Length", content.Length.ToString()));
            this.Headers.Add(new HttpHeader("Content-Disposition", "inline"));
            this.Content = content;
        }
    }
}
