using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            int port = 8808;
            TcpListener listener = new TcpListener(address, port);
            listener.Start();
            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening at 127.0.0.1:{port}");

            Task task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        private static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                TcpClient client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected!");

                byte[] buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message);
                byte[] data = Encoding.ASCII.GetBytes("Hello from server!");
                await client.GetStream().WriteAsync(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
