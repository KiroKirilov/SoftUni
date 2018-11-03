using SIS.Demo.Services.Contracts;
using SIS.Demo.ViewModels;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Attributes.HttpMethod;
using SIS.Framework.Controllers;
using SIS.Framework.Security;
using SIS.Framework.Security.Contracts;
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
            this.ViewModel.Data["ServiceResult"] = this.dummyService.DoSomething();
            this.ViewModel.Data["Items"] = new List<ComplexViewModel>
            {
                new ComplexViewModel { Number=1 },
                new ComplexViewModel { Number=2 },
                new ComplexViewModel { Number=3 },
                new ComplexViewModel { Number=4 },
                new ComplexViewModel { Number=5 }
            };

            return this.View();
        }

        [HttpPost]
        public IActionResult GotIt(InputModel model)
        {
            if (model.NumberInput == 7)
            {
                this.SignIn(new IdentityUser());
            }

            IDictionary<string, object> viewData = new Dictionary<string, object>()
            {
                { "Number",model.NumberInput },
                { "ModelState", this.ModelState.IsValid.Value ? "valid" : "not valid" }
            };

            this.ViewModel.Data["Number"] = model.NumberInput;
            this.ViewModel["ModelState"] = this.ModelState.IsValid.Value ? "valid" : "not valid";

            return this.View();
        }

        [Authorize]
        public IActionResult Forbidden()
        {
            return this.View();
        }
    }
}
