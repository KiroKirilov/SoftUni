using SIS.Demo.Services;
using SIS.Demo.Services.Contracts;
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Api;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;

namespace SIS.Demo
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var dependancyContainer = new DependencyContainer();
            dependancyContainer.RegisterDependancy<IDummyService, DummyService>();

            var handlingContext = new HttpRouteHandlingContext(
               new ControllerRouter(dependancyContainer),
               new ResourceRouter());

            Server server = new Server(8808, handlingContext);

            MvcEngine.Run(server);
        }
    }
}
