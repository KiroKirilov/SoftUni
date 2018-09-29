using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";
        private readonly int port;
        private readonly TcpListener listener;
        private readonly ServerRoutingTable serverRoutingTable;
        private bool isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);

            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{port}");

            Task task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.listener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
                Task responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}
