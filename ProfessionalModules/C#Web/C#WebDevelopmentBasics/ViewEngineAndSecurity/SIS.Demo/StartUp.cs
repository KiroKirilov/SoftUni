using SIS.Framework.Api;
using System;
using System.Collections.Generic;
using System.Text;
using SIS.Framework.Services;
using SIS.Demo.Services.Contracts;
using SIS.Demo.Services;

namespace SIS.Demo
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependancyContainer)
        {
            dependancyContainer.RegisterDependancy<IDummyService, DummyService>();
        }
    }
}
