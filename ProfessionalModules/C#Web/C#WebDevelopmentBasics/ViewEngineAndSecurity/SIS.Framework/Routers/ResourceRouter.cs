using SIS.WebServer.Api;
using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System.IO;
using SIS.HTTP.Enums;
using SIS.WebServer.Results;

namespace SIS.Framework.Routers
{
    public class ResourceRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var requestPath = request.Path;
            var extensionStartIndex = requestPath.LastIndexOf('.');
            var resourceNameStartIndex = requestPath.LastIndexOf('/');
            var extension = requestPath.Substring(extensionStartIndex);
            var resourceName = requestPath.Substring(resourceNameStartIndex);
            var resourcePath= MvcContext.Get.RootDirectoryRelativePath
                               + $"/{MvcContext.Get.ResourceFolderName}"
                               + $"/{extension.Substring(1)}"
                               + resourceName;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);
            return new InlineResouceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
