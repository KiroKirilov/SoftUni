using SIS.Framework.ActionResults;
using SIS.Framework.Models;
using SIS.Framework.Security.Contracts;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewModel = new ViewModel();
        }

        protected IViewable View([CallerMemberName] string actionName = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);
            string viewContent = null;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, actionName);
            }
            catch (FileNotFoundException e)
            {
                this.ViewModel.Data["Error"] = e.Message;

                viewContent = this.ViewEngine.GetErrorContent();
            }

            string renderedContent = this.ViewEngine.RenderHtml(viewContent, this.ViewModel.Data);
            return new ViewResult(new View(renderedContent));
        }

        public IHttpRequest Request { get; set; }

        public Model ModelState { get; } = new Model();

        public ViewModel ViewModel { get; set; }

        public ViewEngine ViewEngine { get; } = new ViewEngine();

        public IIdentity Identity => (IIdentity)this.Request.Session.GetParameter("auth");

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
    }
}
