namespace IRunesWebApp
{
    using IRunesWebApp.Controllers;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = request => new RedirectResult("/");
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] = request => new UserController().Register();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Register"] = request => new UserController().Register(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] = request => new UserController().Login();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Login"] = request => new UserController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Logout"] = request => new UserController().Logout(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/All"] = request => new AlbumsController().All(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Create"] = request => new AlbumsController().Create(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Albums/Create"] = request => new AlbumsController().DoCreate(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Details/"] = request => new AlbumsController().Details(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Create/"] = request => new TrackController().Create(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Tracks/Create/"] = request => new TrackController().DoCreate(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Details/"] = request => new TrackController().Details(request);

            Server server = new Server(8000, serverRoutingTable);

            server.Run();

            //Здравей колега, който проверява този проект. Искам само да ти кажа че има шанс някой 
            //неща да не работят при теб защото RootDirectoryRelativePath при мен е ./ вместо../../../
            //Този път се използва за зареждане на view-та. Ако искаш да го промениш константата се намира в IRunesWebApp.Constants.GlobalConstants.
            //Благодаря :)
        }
    }
}
