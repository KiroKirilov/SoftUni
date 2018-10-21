using SIS.Framework.ActionResults;
using SIS.Framework.Models;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Requests;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller() { }

        protected IViewable View(IDictionary<string, object> viewData = null, [CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);
            string fullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, caller);
            View view = new View(fullyQualifiedName, viewData);
            return new ViewResult(view);
        }

        public IHttpRequest Request { get; set; }

        public Model ModelState { get; } = new Model();

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }
    }
}
