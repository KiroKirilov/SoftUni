using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using System;

namespace SIS.Demo
{
    class Launcher
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/About"] = request => new HomeController().About();

            Server server = new Server(8808, serverRoutingTable);

            server.Run();
        }
    }
}
