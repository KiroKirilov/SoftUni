using MishMashWebApp.Data;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new MishMashDbContext();
        }

        protected MishMashDbContext Db { get; }
    }
}
