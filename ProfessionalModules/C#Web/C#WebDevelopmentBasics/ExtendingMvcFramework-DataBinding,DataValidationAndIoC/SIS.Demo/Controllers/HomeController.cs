using SIS.Demo.Services.Contracts;
using SIS.Demo.ViewModels;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes;
using SIS.Framework.Attributes.HttpMethod;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDummyService dummyService;

        public HomeController(IDummyService dummyService)
        {
            this.dummyService = dummyService;
        }

        public IActionResult Index()
        {
            IDictionary<string, object> viewData = new Dictionary<string, object>()
            {
                { "ServiceResult", this.dummyService.DoSomething() }
            };

            return this.View(viewData);
        }

        [HttpPost]
        public IActionResult GotIt(InputModel model)
        {
            IDictionary<string, object> viewData = new Dictionary<string, object>()
            {
                { "Number",model.NumberInput },
                { "ModelState", this.ModelState.IsValid.Value ? "valid" : "not valid" }
            };

            return this.View(viewData);
        }
    }
}
