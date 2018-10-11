namespace IRunesWebApp.Controllers
{
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests.Contracts;
    using System.IO;
    using Microsoft.EntityFrameworkCore;    
    using IRunesWebApp.Data;
    using System.Runtime.CompilerServices;   
    using IRunesWebApp.Services;
    using System.Collections.Generic;
    using IRunesWebApp.Constants;

    public abstract class BaseController
    {
        private string GetCurrentControllerName() => GetType().Name.Replace(GlobalConstants.ControllerDefaultName, string.Empty);

        protected bool Authenticated { get; set; }

        protected IDictionary<string, string> ViewBag { get; set; }
       
        protected IRunesDbContext Db { get; }

        protected UserCookieService UserCookieService { get; }

        public BaseController()
        {
            this.Db = new IRunesDbContext();
            this.ViewBag = new Dictionary<string, string>();
            this.UserCookieService = new UserCookieService();
            this.Authenticated = false;
        }

        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter(GlobalConstants.Username);
        }

        protected IHttpResponse SignInUser(IHttpRequest request, IHttpResponse response, string username)
        {
            request.Session.AddParameter(GlobalConstants.Username, username);
            var cookieContent = this.UserCookieService.GetUserCookie(username);
            response.CookieCollection.Add(new HttpCookie(GlobalConstants.AuthCookie, cookieContent));
            return response;
        }

        protected string GetUser(IHttpRequest request)
        {
            var username = request.Session.GetParameter(GlobalConstants.Username);

            return username.ToString();
        }

        protected string GetFormData(IHttpRequest request, string data)
        {
            if (request.FormData.ContainsKey(data))
            {
                return request.FormData[data].ToString();
            }

            return null;
        }

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            string filePath = GetViewPath(viewName);

            var content = File.ReadAllText(filePath);

            var layout = string.Empty;

            if (this.Authenticated)
            {
                layout = File.ReadAllText(this.GetLayoutPath("LayoutLoggedIn"));
            }
            else
            {
                layout = File.ReadAllText(this.GetLayoutPath("Layout"));
            }

            var layoutWithContent = layout.Replace("{{{Content}}}", content);

            foreach (var viewBagKey in ViewBag.Keys)
            {
                var dynamicDataPlaceholder = $"{{{{{{{viewBagKey}}}}}}}";

                if (layoutWithContent.Contains(dynamicDataPlaceholder))
                {
                    layoutWithContent = layoutWithContent.Replace(dynamicDataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return new HtmlResult(layoutWithContent, HttpResponseStatusCode.OK);
        }

        private string GetLayoutPath(string viewName)
        {
            string filePath =GlobalConstants.RootDirectoryRelativePath + GlobalConstants.ViewsFolderName + GlobalConstants.DirectorySeparator +
                             viewName + GlobalConstants.HtmlFileExtension;
            return filePath;
        }

        private string GetViewPath(string viewName)
        {
            string filePath = GlobalConstants.RootDirectoryRelativePath + GlobalConstants.ViewsFolderName + GlobalConstants.DirectorySeparator +
                            this.GetCurrentControllerName() + GlobalConstants.DirectorySeparator + viewName + GlobalConstants.HtmlFileExtension;
            return filePath;
        }
    }
}
