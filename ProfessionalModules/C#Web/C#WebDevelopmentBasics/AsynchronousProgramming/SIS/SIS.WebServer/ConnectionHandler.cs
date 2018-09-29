using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }
        
        public async Task ProcessRequestAsync()
        {
            IHttpRequest request = await this.ReadRequest();

            if (request!=null)
            {
                IHttpResponse response = this.HandleRequest(request);
                await this.PrepareResponse(response);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task PrepareResponse(IHttpResponse response)
        {
            byte[] byteSegments = response.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (!this.serverRoutingTable.Routes.ContainsKey(request.RequestMethod) ||
                !this.serverRoutingTable.Routes[request.RequestMethod].ContainsKey(request.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[request.RequestMethod][request.Path].Invoke(request);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            StringBuilder result = new StringBuilder();
            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numbersOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numbersOfBytesRead==0)
                {
                    break;
                }

                string bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numbersOfBytesRead);
                result.Append(bytesAsString);

                if (numbersOfBytesRead<1023)
                {
                    break;
                }
            }

            if (result.Length==0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
    }
}
