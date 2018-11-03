using SIS.Framework.Api;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.WebServer;
using SIS.WebServer.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework
{
    public static class WebHost
    {
        private const int HostingPort = 8808;

        public static void Start(IMvcApplication app)
        {
            IDependencyContainer container = new DependencyContainer();
            app.ConfigureServices(container);

            var handlingContext = new HttpRouteHandlingContext(
               new ControllerRouter(container),
               new ResourceRouter());
            app.Configure();

            Server server = new Server(HostingPort, handlingContext);
            MvcEngine.Run(server);
        }
    }
}
