using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Torshia.Data;

namespace Torshia.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new TorshiaDbContext();
        }

        protected TorshiaDbContext Db { get; set; }

        protected IViewable RenderView([CallerMemberName] string actionName = "")
        {
            if (this.Identity==null)
            {
                this.Model["LoggedOutNav"] = "block";
                this.Model["UserNav"] = "none";
                this.Model["AdminNav"] = "none";
                this.Model["UserOrAdmin"] = "none";
            }
            else if (this.Identity.Roles.Contains("Admin"))
            {
                this.Model["LoggedOutNav"] = "none";
                this.Model["UserNav"] = "none";
                this.Model["AdminNav"] = "block";
                this.Model["UserOrAdmin"] = "block";
            }
            else
            {
                this.Model["LoggedOutNav"] = "none";
                this.Model["UserNav"] = "block";
                this.Model["AdminNav"] = "none";
                this.Model["UserOrAdmin"] = "block";
            }

            return base.View(actionName);
        }
    }
}
