using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Api.Contracts
{
    public interface IHttpHandlingContext
    {
        IHttpResponse Handle(IHttpRequest httpRequest);
    }
}
