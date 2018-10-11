using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.HTTP.Sessions;
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
            if (client==null || serverRoutingTable==null)
            {
                throw new ArgumentNullException();
            }

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }
        
        public async Task ProcessRequestAsync()
        {
            IHttpRequest request = await this.ReadRequest();

            if (request!=null)
            {
                string sessionId = this.SetRequestSession(request);
                IHttpResponse response = this.HandleRequest(request);
                this.SetResponseSession(response, sessionId);
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

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse
                    .AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey
                        , $"{sessionId};HttpOnly=true"));

                Console.WriteLine(httpResponse);
            }
        }
    }
}
